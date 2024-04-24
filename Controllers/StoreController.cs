using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.App_Start
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Products()
        {
            return View();
        }
    }
}