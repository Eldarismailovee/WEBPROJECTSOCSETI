using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Domain.Entities.User
{
     class UserContext:DbContext
    {
        public UserContext () : base("WebMarket")
        {
        }
        public virtual DbSet<Udbtable> Users { get; set; }
    }
}
