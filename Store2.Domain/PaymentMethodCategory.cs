using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class PaymentMethodCategory
    {
        public int Id { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
