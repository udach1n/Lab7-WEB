using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy2.Models
{
    public class User
    {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone_Number { get; set; }
            public string Adress { get; set; }
            public int DrugId { get; set; }
            public Drug Drug { get; set; }
        
    }
}
