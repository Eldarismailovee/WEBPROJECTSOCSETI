using System.Collections.Generic;

namespace Store2.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
