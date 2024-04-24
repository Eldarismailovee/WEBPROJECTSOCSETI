using System;
using System.Web.Mvc;
using WebApplication1.Models;
using Webmarket.BussinessLogic;
using Webmarket.BussinessLogic.Interfaces;
using WebMarket.Domain.Entities.User;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _sessionBL;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _sessionBL = bl.GetSessionBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                UloginData data = new UloginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now

                };
                var userLogin = _sessionBL.UserLogin(data) 
                if(userLogin.Status)
                {
                   return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("",userLogin.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}