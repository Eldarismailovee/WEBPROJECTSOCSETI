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
    public class PaymentMethodCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentMethodCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentMethodCategories.ToListAsync());
        }

        // GET: PaymentMethodCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethodCategory paymentMethodCategory = await db.PaymentMethodCategories.FindAsync(id);
            if (paymentMethodCategory == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethodCategory);
        }

        // GET: PaymentMethodCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethodCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] PaymentMethodCategory paymentMethodCategory)
        {
            if (ModelState.IsValid)
            {
                db.PaymentMethodCategories.Add(paymentMethodCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentMethodCategory);
        }

        // GET: PaymentMethodCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethodCategory paymentMethodCategory = await db.PaymentMethodCategories.FindAsync(id);
            if (paymentMethodCategory == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethodCategory);
        }

        // POST: PaymentMethodCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] PaymentMethodCategory paymentMethodCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMethodCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentMethodCategory);
        }

        // GET: PaymentMethodCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethodCategory paymentMethodCategory = await db.PaymentMethodCategories.FindAsync(id);
            if (paymentMethodCategory == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethodCategory);
        }

        // POST: PaymentMethodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PaymentMethodCategory paymentMethodCategory = await db.PaymentMethodCategories.FindAsync(id);
            db.PaymentMethodCategories.Remove(paymentMethodCategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
