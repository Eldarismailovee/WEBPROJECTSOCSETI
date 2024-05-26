using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Store2.Domain;
using Store2.Models;

namespace Store2.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: ShoppingCarts
        public async Task<ActionResult> Index()
        {
            var shoppingCarts = db.ShoppingCarts.Include(s => s.Product);
            ViewBag.DeliveryMethods = db.DeliveryMethods.ToList();
            return View(await shoppingCarts.ToListAsync());
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart(int id, int quantity)
        {
            var product = await db.Products.FindAsync(id);
            if (product != null)
            {
                // Проверяем, есть ли уже товар в корзине
                var cartItem = db.ShoppingCarts.FirstOrDefault(c => c.ProductId == id);
                if (cartItem != null)
                {
                    // Если товар уже в корзине, увеличиваем количество
                    cartItem.Quantity += quantity;
                }
                else
                {
                    // Если товара нет в корзине, добавляем новый элемент с указанным количеством
                    var cart = new ShoppingCart
                    {
                        ProductId = product.Id,
                        Quantity = quantity,
                    };
                    db.ShoppingCarts.Add(cart);
                }
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "Товар добавлен в корзину." });
            }
            return Json(new { success = false, message = "Ошибка при добавлении товара в корзину." });
        }

        [HttpPost]
        public async Task<JsonResult> RemoveFromCart(int id)
        {
            var cartItem = await db.ShoppingCarts.FindAsync(id);
            if (cartItem != null)
            {
                db.ShoppingCarts.Remove(cartItem);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<JsonResult> ClearCart()
        {
            var cartItems = db.ShoppingCarts.ToList();
            db.ShoppingCarts.RemoveRange(cartItems);
            await db.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Checkout(int deliveryMethodId)
        {
            var cartItems = await db.ShoppingCarts.Include(s => s.Product).ToListAsync();
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            if (cartItems.Count == 0)
            {
                return Json(new { success = false, message = "Корзина пуста." });
            }

            var totalAmount = cartItems.Sum(c => c.Product.Price * c.Quantity);

            var checkoutViewModel = new Models.CheckOutViewModel
            {
                CartItems = cartItems,
                TotalPrice = totalAmount,
                SelectedDeliveryMethodId = deliveryMethodId,
                DeliveryMethods = db.DeliveryMethods.ToList()
            };

            return View("Payment", checkoutViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProcessPayment(Models.CheckOutViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика для обработки платежа

                // Очистка корзины после успешного платежа
                var cartItems = await db.ShoppingCarts.ToListAsync();
                db.ShoppingCarts.RemoveRange(cartItems);
                await db.SaveChangesAsync();

                return RedirectToAction("OrderConfirmed");
            }

            model.DeliveryMethods = db.DeliveryMethods.ToList();
            return View("Payment", model);
        }

        public ActionResult OrderConfirmed()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
