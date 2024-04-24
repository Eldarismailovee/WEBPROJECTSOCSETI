using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        // GET: Error
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            return View("Errorsts");
        }
    }
}