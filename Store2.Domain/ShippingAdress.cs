using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class ShippingAdress
    {
        public int Id { get; set; }

        public string Region { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public string NomerDoma { get; set; }

        public string NomerKvartiry { get; set; }

        public string Podiezd { get; set; }

        public string Etazh { get; set; }

        public string Domophone { get; set; }

        public string Comment { get; set; }
    }
}
