using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy2.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace FilterSortPagingApp.Controllers
{
    public class HomeController : Controller
    {
        UsersContext db;
        public HomeController(UsersContext context)
        {
            this.db = context;

            if (db.Drugs.Count() == 0)
            {
                Drug drug1 = new Drug { Name = "Активированный уголь", Quantity = 10000, Price = 30 };
                Drug drug2 = new Drug { Name = "НО-ШПА", Quantity = 20000, Price = 60 };
                Drug drug3 = new Drug{Name = "Белый уголь",Quantity = 50000, Price = 40};
                Drug drug4 = new Drug {Name = "АЦЦ раствор",Quantity = 1000,Price = 150};
                Drug drug5 = new Drug {Name = "Атоксил гель",Quantity = 1300,Price = 400};
                

                User user1 = new User { Name = "Олег Балов", Drug = drug1, Phone_Number = "+380674568243",Adress="Боршаговская 15" };
                User user2 = new User { Name = "Александр Дергин", Drug = drug3, Phone_Number = "+380669810056", Adress = "Крещатик 33" };
                User user3 = new User { Name = "Алексей Петров", Drug = drug2, Phone_Number = "+3800968196588", Adress = "Владимирская 19" };
                User user4 = new User { Name = "Андрей Иванов", Drug = drug5, Phone_Number = "+380501111111", Adress = "Пушкинская 7" };
                User user5 = new User { Name = "Петр Княжев", Drug = drug4, Phone_Number = "+380679248894", Adress = "Льва Толстого 58" };
                User user6 = new User { Name = "Василий Абрамович", Drug = drug1, Phone_Number = "+380509107754", Adress = "Антановича 19" };
                User user7 = new User { Name = "Олег Кузнецов", Drug = drug4, Phone_Number = "+380964418134", Adress = "Проспект Победы 24" };
                User user8 = new User { Name = "Андрей Гринчич", Drug = drug2, Phone_Number = "+380995042761", Adress = "Крещатик 9" };

                db.Drugs.AddRange(drug1, drug2, drug3, drug4, drug5);
                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                db.SaveChanges();

                
            }
           
        }
        

        public async Task<IActionResult> Index(int? drug, string name, int page = 1,
            Sort sortOrder = Sort.NameAsc )
        {

            int pageSize = 3;

            //фильтрация
            IQueryable<User> users = db.Users.Include(x => x.Drug);

            if (drug != null && drug != 0)
            {
                users = users.Where(p => p.DrugId == drug);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case Sort.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case Sort.Phone_NumberAsc:
                    users = users.OrderBy(s => s.Phone_Number);
                    break;
                case Sort.Phone_NumberDesc:
                    users = users.OrderByDescending(s => s.Phone_Number);
                    break;
                case Sort.AdressAsc:
                    users = users.OrderBy(s => s.Adress);
                    break;
                case Sort.AdressDesc:
                    users = users.OrderByDescending(s => s.Adress);
                    break;
                case Sort.DrugAsc:
                    users = users.OrderBy(s => s.Drug.Name);
                    break;
                case Sort.DrugDesc:
                    users = users.OrderByDescending(s => s.Drug.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexView viewModel = new IndexView
            {
                PageViewModel = new PageView(count, page, pageSize),
                SortViewModel = new SortView(sortOrder),
                FilterViewModel = new Filter(db.Drugs.ToList(), drug, name),
                Users = items
            };
            return View(viewModel);
        }
        
    }
}
