using System.Linq.Dynamic.Core;
using System.Web.Mvc;
using System.Linq;
using WebApplication1.Models;
using System;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using System.Web;
namespace WebApplication1.Controllers

{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Registration([Bind(Exclude= "isEmailVerified,ActivationCode")]Users user)
        {
            bool Status=false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region 
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "E-mail уже зарегистрирован");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                user.Password=Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                user.isEmailVerified = false;

                #region Save to DataBase
                using (UsersEntities4 dc = new UsersEntities4())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
                    message = "Регистрация Успешно завершена. Ссылка для активации" + "Будет отправлена вам на почту:" + user.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Некорректный Запрос";
            }
            ViewBag.Message= message;
            ViewBag.Status = Status;
            return View(user);
        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool status = false;
            using(UsersEntities4 dc = new UsersEntities4())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                
                var v=dc.Users.Where(a=>a.ActivationCode==new Guid(id)).FirstOrDefault();
                if (v!=null)
                {
                    v.isEmailVerified=true;
                    dc.SaveChanges();
                    status= true;
                }
                else
                {
                    ViewBag.Message = "Некоректный Запрос";
                }
            }
            ViewBag.Status= status;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(UserLogin login,string ReturnUrl)
        {
            string message = "";
            using(UsersEntities4 dc=new UsersEntities4())
            {
                var v = dc.Users.Where(a => a.Email == login.Email).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password),v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 1;
                        var ticket=new FormsAuthenticationTicket(login.Email,login.RememberMe,timeout);
                        string encrypted=FormsAuthentication.Encrypt(ticket);
                        var cookie=new HttpCookie(FormsAuthentication.FormsCookieName,encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    message = "Введены Неверные данные";
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {
            using (UsersEntities4 dc = new UsersEntities4())
            {
                var v=dc.Users.Where(a=>a.Email==email).FirstOrDefault();
                return v!= null;
            }
        }
        [NonAction]
        public void SendVerificationLinkEmail(string email,string activationCode)
        {
            var verifyUrl = "/Login/VerifyAccount/" + activationCode;
            var link=Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var toEmail=new MailAddress(email);
            var fromEmail = new MailAddress("fgghyk51@gmail.com");
            var fromEmailPassword = "rmtv vqdv ezgt wfld";
            string subject = "Аккаунт Успешно Создан";
            string body="<br>/<br/> Здравствуйте! Рады собщить вам что аккаунт на сайте Магазина N2"+ "Успешно создан. Пожалуйста нижмите на ссытк для подтверждения аккаунта"+" <br/><br/><a href= '"+link+"' > "+link+"  </a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials=new NetworkCredential(fromEmail.Address,fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(message);
        }
    }

}
