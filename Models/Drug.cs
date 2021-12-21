using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy2.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public List<User> Users { get; set; }
        public Drug()
        {
            Users = new List<User>();
        }
    }
}
