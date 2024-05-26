using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store2.Controllers
{
    public class KeepAliveController : Controller
    {
        // GET: KeepAlive
        public ActionResult KeepAlive()
        {
            return new HttpStatusCodeResult(200);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}