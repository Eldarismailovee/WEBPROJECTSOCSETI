using Store2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store2.Models
{
    public class CheckOutViewModel
    {
        public List<ShoppingCart> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public List<DeliveryMethods> DeliveryMethods { get; set; }
        public int SelectedDeliveryMethodId { get; set; }
        public decimal DeliveryCost { get; set; }

        // Информация о пользователе
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

}