using Microsoft.Owin;
using Owin;
using Store2.Models;

[assembly: OwinStartup(typeof(Store2.Startup))]
namespace Store2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            ConfigureAuth(app);
        }
    }
}
