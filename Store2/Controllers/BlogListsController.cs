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
    public class BlogListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogLists
        public async Task<ActionResult> Index()
        {
            return View(await db.BlogLists.ToListAsync());
        }

        // GET: BlogLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogList blogList = await db.BlogLists.FindAsync(id);
            if (blogList == null)
            {
                return HttpNotFound();
            }
            return View(blogList);
        }

        // GET: BlogLists/Create
        public ActionResult Create()
        {
            ViewBag.Difficulties = db.DifficultBlogs.ToList();
            ViewBag.Categories = db.BlogCategories.ToList();
            return View();
        }

        // POST: BlogLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Content,Date,ImageUrl,PreparationTime,Category.Id,Difficulty.Id")] BlogList blogList)
        {
            if (ModelState.IsValid)
            {
                db.BlogLists.Add(blogList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Difficulties = db.DifficultBlogs.ToList();
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blogList);
        }

        // GET: BlogLists/Edit/5
            public async Task<ActionResult> Edit(int? id)
            {
                ViewBag.Difficulties = db.DifficultBlogs.ToList();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BlogList blogList = await db.BlogLists.FindAsync(id);
                if (blogList == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Categories = db.BlogCategories.ToList();
                return View(blogList);
            }

        // POST: BlogLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Content,Date,ImageUrl,PreparationTime,Category.Id,Difficulty.Id")] BlogList blogList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Difficulties = db.DifficultBlogs.ToList();
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blogList);
        }

        // GET: BlogLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogList blogList = await db.BlogLists.FindAsync(id);
            if (blogList == null)
            {
                return HttpNotFound();
            }
            return View(blogList);
        }

        // POST: BlogLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BlogList blogList = await db.BlogLists.FindAsync(id);
            db.BlogLists.Remove(blogList);
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
