using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class FooterContact
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
