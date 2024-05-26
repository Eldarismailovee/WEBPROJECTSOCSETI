using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class Discount
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountedPrice
        {
            get
            {
                return OriginalPrice - (OriginalPrice * (DiscountPercentage / 100));
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
