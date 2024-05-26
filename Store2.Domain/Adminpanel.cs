using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class Adminpanel
    {
        public BlogCategory BlogCategory { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public Slides Slides { get; set; }
        public PropertyStoreModel PropertyStoreModel { get; set; }
    }
}
