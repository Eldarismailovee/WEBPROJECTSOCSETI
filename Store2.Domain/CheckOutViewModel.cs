using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class CheckOutViewModel
    {
        public List<ShoppingCart> CartItems { get; set; }
        public decimal TotalPrice { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Promocode promocode { get; set; }
        public List<PaymentMethod> DeliveryMethods { get; set; }
        public int SelectedDeliveryMethodId { get; set; }

    }
}
