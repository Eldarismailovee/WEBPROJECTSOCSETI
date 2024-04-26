using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TermsAndRulesController : Controller
    {
        public ActionResult Rules()
        {
            return View();
        }
        public ActionResult Confidencial()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
    }
}