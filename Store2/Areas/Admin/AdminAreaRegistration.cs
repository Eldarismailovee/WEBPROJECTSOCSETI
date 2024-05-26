using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Admin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Store2.Areas.Admin.Controllers" }
            ).RouteHandler = new AdminRouteHandler(); // Добавляем этот обработчик
        }
    }

    public class AdminRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var controller = requestContext.RouteData.Values["controller"].ToString();
            if (controller.StartsWith("Admin"))
            {
                var user = requestContext.HttpContext.User;
                if (!user.Identity.IsAuthenticated || !user.IsInRole("Admin"))
                {
                    requestContext.RouteData.Values["controller"] = "Account";
                    requestContext.RouteData.Values["action"] = "Login";
                }
            }
            return base.GetHttpHandler(requestContext);
        }
    }
}
