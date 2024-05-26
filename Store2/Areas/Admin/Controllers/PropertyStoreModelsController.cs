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

namespace Store2.Areas.Admin.Controllers
{
    public class PropertyStoreModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyStoreModels
        public async Task<ActionResult> Index()
        {
            return View(await db.PropertyStoreModels.ToListAsync());
        }

        // GET: PropertyStoreModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStoreModel propertyStoreModel = await db.PropertyStoreModels.FindAsync(id);
            if (propertyStoreModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyStoreModel);
        }

        // GET: PropertyStoreModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyStoreModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,value,imageUrl")] PropertyStoreModel propertyStoreModel)
        {
            if (ModelState.IsValid)
            {
                db.PropertyStoreModels.Add(propertyStoreModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(propertyStoreModel);
        }

        // GET: PropertyStoreModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStoreModel propertyStoreModel = await db.PropertyStoreModels.FindAsync(id);
            if (propertyStoreModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyStoreModel);
        }

        // POST: PropertyStoreModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,value,imageUrl")] PropertyStoreModel propertyStoreModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyStoreModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(propertyStoreModel);
        }

        // GET: PropertyStoreModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStoreModel propertyStoreModel = await db.PropertyStoreModels.FindAsync(id);
            if (propertyStoreModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyStoreModel);
        }

        // POST: PropertyStoreModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyStoreModel propertyStoreModel = await db.PropertyStoreModels.FindAsync(id);
            db.PropertyStoreModels.Remove(propertyStoreModel);
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
