using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy2.Models
{
    public class SortView
    {
        public Sort NameSort { get; private set; } // значение для сортировки по имени
        public Sort AdressSort { get; private set; }    // значение для сортировки по адрессу
        public Sort Phone_NumberSort { get; private set; }   // значение для сортировки по номеру телефона
        public Sort DrugSort { get; private set; } // значение для сортировки по лекарствам
        public Sort Current { get; private set; }     // текущее значение сортировки

        public SortView(Sort sortOrder)
        {
            NameSort = sortOrder == Sort.NameAsc ? Sort.NameDesc : Sort.NameAsc;
            AdressSort = sortOrder == Sort.AdressAsc ? Sort.AdressDesc : Sort.AdressAsc;
            Phone_NumberSort = sortOrder == Sort.Phone_NumberAsc ? Sort.Phone_NumberDesc : Sort.Phone_NumberAsc;
            DrugSort = sortOrder == Sort.DrugAsc ? Sort.DrugDesc : Sort.DrugAsc;
            Current = sortOrder;
        }
    }
}
