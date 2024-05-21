using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store2.Domain;
using Store2.Models;

namespace Store2.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingCarts
        public async Task<ActionResult> Index()
        {
            var shoppingCarts = db.ShoppingCarts.Include(s => s.Product);
            return View(await shoppingCarts.ToListAsync());
        }

        // GET: ShoppingCarts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,Quantity")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCarts.Add(shoppingCart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,Quantity")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(id);
            db.ShoppingCarts.Remove(shoppingCart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //добавление продукта в корзину AddToCart
        public async Task<ActionResult> AddToCart(int id, int quantity)
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
                        Quantity = quantity // Используем переданное количество
                    };
                    db.ShoppingCarts.Add(cart);
                }
                await db.SaveChangesAsync();
            }
            return Json(new { success = true });
        }

        //checkout
        public async Task<ActionResult> Checkout()
        {
            var deliveryMethods = db.PaymentMethods.ToList();
            var checkoutViewModel = new CheckOutViewModel
            {
                // Заполните другие свойства модели...
            };
            var cart = Session["Cart"] as ShoppingCart;
            var shoppingCart = db.ShoppingCarts.Include(c => c.Product);
            return View(await shoppingCart.ToListAsync());
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
