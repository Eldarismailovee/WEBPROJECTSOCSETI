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
    public class CatalogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catalog
        public async Task<ActionResult> Index(int? categoryId, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.CurrentCategory = categoryId;

            var products = db.Products.Include(p => p.Category);
            string categoryName = "Все продукты"; // Значение по умолчанию

            if (categoryId.HasValue)
            {
                var category = await db.Categories.FindAsync(categoryId.Value);
                if (category != null)
                {
                    categoryName = category.Name;
                    products = products.Where(p => p.CategoryId == categoryId.Value);
                }
            }

            ViewBag.CategoryName = categoryName;
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.CurrentCategory = categoryId;
            return View(await products.ToListAsync());
        }
        // GET: Catalog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Price,Description,Quantity,ImageUrl,Brand,IsAvailable,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Catalog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Price,Description,Quantity,ImageUrl,Brand,IsAvailable,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Catalog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Fruits()
        {
            var fruits = db.Products.Include(p => p.Category).Where(p => p.Category.Name == "Фрукты");
            return View("Index", await fruits.ToListAsync());
        }

        // GET: Catalog/Vegetables
        public async Task<ActionResult> Vegetables()
        {
            var vegetables = db.Products.Include(p => p.Category).Where(p => p.Category.Name == "Овощи");
            return View("Index", await vegetables.ToListAsync());
        }
        [HttpGet]
        public ActionResult Search(string query)
        {
            var products = db.Products
                .Where(p => p.Name.Contains(query) || p.Description.Contains(query))
                .ToList();

            return View(products);
        }

        [HttpGet]
        public JsonResult Autocomplete(string term)
        {
            var productNames = db.Products
                .Where(p => p.Name.Contains(term))
                .Select(p => new { label = p.Name, value = p.Id })
                .ToList();

            return Json(productNames, JsonRequestBehavior.AllowGet);
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
