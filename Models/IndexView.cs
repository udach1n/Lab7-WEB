using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy2.Models
{
    public class IndexView
    {
        public IEnumerable<User> Users { get; set; }
        public PageView PageViewModel { get; set; }
        public Filter FilterViewModel { get; set; }
        public SortView SortViewModel { get; set; }
    }
}
