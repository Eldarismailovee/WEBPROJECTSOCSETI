﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserData user = new UserData();
            user.Username= "Customer";
            user.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
            return View(user);

        }
        public ActionResult About()
        {
            return View();
        }
    }
}