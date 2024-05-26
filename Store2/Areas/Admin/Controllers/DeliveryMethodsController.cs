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

namespace Store2.Areas.Admin.Controllers
{
    public class DeliveryMethodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DeliveryMethods
        public ActionResult Index()
        {
            return View(db.DeliveryMethods.ToList());
        }

        // GET: Admin/DeliveryMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMethods deliveryMethods = db.DeliveryMethods.Find(id);
            if (deliveryMethods == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethods);
        }

        // GET: Admin/DeliveryMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeliveryMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cost")] DeliveryMethods deliveryMethods)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryMethods.Add(deliveryMethods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryMethods);
        }

        // GET: Admin/DeliveryMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMethods deliveryMethods = db.DeliveryMethods.Find(id);
            if (deliveryMethods == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethods);
        }

        // POST: Admin/DeliveryMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Cost")] DeliveryMethods deliveryMethods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryMethods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryMethods);
        }

        // GET: Admin/DeliveryMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMethods deliveryMethods = db.DeliveryMethods.Find(id);
            if (deliveryMethods == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethods);
        }

        // POST: Admin/DeliveryMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryMethods deliveryMethods = db.DeliveryMethods.Find(id);
            db.DeliveryMethods.Remove(deliveryMethods);
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
