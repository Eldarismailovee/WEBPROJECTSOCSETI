using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store2.Domain;
using Store2.Models;

namespace Store2.Controllers.Footer
{
    public class FooterMarketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FooterMarkets
        public ActionResult Index()
        {
            return View(db.FooterMarkets.ToList());
        }

        // GET: FooterMarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterMarket footerMarket = db.FooterMarkets.Find(id);
            if (footerMarket == null)
            {
                return HttpNotFound();
            }
            return View(footerMarket);
        }

        // GET: FooterMarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FooterMarkets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Name,reflink")] FooterMarket footerMarket)
        {
            if (ModelState.IsValid)
            {
                db.FooterMarkets.Add(footerMarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerMarket);
        }

        // GET: FooterMarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterMarket footerMarket = db.FooterMarkets.Find(id);
            if (footerMarket == null)
            {
                return HttpNotFound();
            }
            return View(footerMarket);
        }

        // POST: FooterMarkets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Name,reflink")] FooterMarket footerMarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerMarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerMarket);
        }

        // GET: FooterMarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterMarket footerMarket = db.FooterMarkets.Find(id);
            if (footerMarket == null)
            {
                return HttpNotFound();
            }
            return View(footerMarket);
        }

        // POST: FooterMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FooterMarket footerMarket = db.FooterMarkets.Find(id);
            db.FooterMarkets.Remove(footerMarket);
            db.SaveChanges();
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
