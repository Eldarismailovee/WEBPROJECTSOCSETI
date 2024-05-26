using Store2.Domain;
using Store2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Store2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                FooterContact = db.FooterContacts.FirstOrDefault(),
                FooterMarket = db.FooterMarkets.FirstOrDefault(),
                FooterPages = db.FooterPages.ToList(),
                FooterSocial = db.FooterSocials.ToList(),
                Slides = db.Slides.ToList(),
                PropertyStoreModels = db.PropertyStoreModels.ToList(),
                Products = db.Products.ToList(), // Пример получения одного продукта
                Categories = db.Categories.ToList()
            };

            // Возвращение viewModel в представление
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}