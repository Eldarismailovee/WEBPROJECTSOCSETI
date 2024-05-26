using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public FooterContact FooterContact { get; set; }
        public FooterMarket FooterMarket { get; set; }
        public IEnumerable<FooterPages> FooterPages { get; set; }
        public IEnumerable<FooterSocial> FooterSocial { get; set; }
        public IEnumerable<Slides> Slides { get; set; }
        public IEnumerable<PropertyStoreModel> PropertyStoreModels { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
