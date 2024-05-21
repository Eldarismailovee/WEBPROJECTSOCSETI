using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Domain.Product> Products { get; set; }

        public DbSet<Domain.ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Domain.Category> Categories { get; set; }

        public DbSet<Domain.BlogList> BlogLists { get; set; }

        public DbSet<Domain.BlogCategory> BlogCategories { get; set; }

        public DbSet<Domain.DifficultBlog> DifficultBlogs { get; set; }

        public DbSet<Domain.PaymentMethodCategory> PaymentMethodCategories { get; set; }

        public DbSet<Domain.PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Domain.PropertyStoreModel> PropertyStoreModels { get; set; }

        public DbSet<Domain.FooterContact> FooterContacts { get; set; }

        public DbSet<Domain.FooterMarket> FooterMarkets { get; set; }

        public DbSet<Domain.FooterPages> FooterPages { get; set; }

        public DbSet<Domain.FooterSocial> FooterSocials { get; set; }

        public DbSet<Domain.AdminLogin> AdminLogins { get; set; }

        public System.Data.Entity.DbSet<Store2.Domain.Slides> Slides { get; set; }

        public System.Data.Entity.DbSet<Store2.Domain.HomeViewModel> HomeViewModels { get; set; }
    }
}