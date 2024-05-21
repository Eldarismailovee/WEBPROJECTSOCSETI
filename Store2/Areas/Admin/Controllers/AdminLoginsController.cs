using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Store2.Domain;
using Store2.Models;

namespace Store2.Areas.Admin.Controllers
{
    public class AdminLoginsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminLogins
        public ActionResult Login()
        {
            return View();
        }
    }
}
