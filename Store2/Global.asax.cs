using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Store2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            var httpException = exception as HttpException;
            if (httpException != null)
            {
           //     string action;
                //switch (httpexception.gethttpcode())
                //{
                //    case 500:
                //        action = "error500";
                //        break;
                //    case 404:
                //        action = "notfound";
                //        break;
                //    default:
                //        action = "index";
                //        break;
                //}

              //  Server.ClearError();
            //    Response.Redirect(String.Format("~/Error/{0}", action));
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
