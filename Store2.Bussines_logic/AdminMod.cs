using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store2.Bussines_logic
{
    public class AdminMod: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole("Admin"))
            {
                // Если пользователь не администратор, перенаправляем его на страницу входа или другую страницу
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Account" },
                    { "action", "Login" }
                    }
                );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
