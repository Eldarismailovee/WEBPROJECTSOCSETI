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
    public class FooterContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FooterContacts
        public ActionResult Index()
        {
            return View(db.FooterContacts.ToList());
        }

        // GET: FooterContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContact footerContact = db.FooterContacts.Find(id);
            if (footerContact == null)
            {
                return HttpNotFound();
            }
            return View(footerContact);
        }

        // GET: FooterContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FooterContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PhoneNumber,HomeNumber,Email,Address")] FooterContact footerContact)
        {
            if (ModelState.IsValid)
            {
                db.FooterContacts.Add(footerContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerContact);
        }

        // GET: FooterContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContact footerContact = db.FooterContacts.Find(id);
            if (footerContact == null)
            {
                return HttpNotFound();
            }
            return View(footerContact);
        }

        // POST: FooterContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PhoneNumber,HomeNumber,Email,Address")] FooterContact footerContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerContact);
        }

        // GET: FooterContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterContact footerContact = db.FooterContacts.Find(id);
            if (footerContact == null)
            {
                return HttpNotFound();
            }
            return View(footerContact);
        }

        // POST: FooterContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FooterContact footerContact = db.FooterContacts.Find(id);
            db.FooterContacts.Remove(footerContact);
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
