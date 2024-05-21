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
    public class DifficultBlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DifficultBlogs
        public async Task<ActionResult> Index()
        {
            return View(await db.DifficultBlogs.ToListAsync());
        }

        // GET: DifficultBlogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifficultBlog difficultBlog = await db.DifficultBlogs.FindAsync(id);
            if (difficultBlog == null)
            {
                return HttpNotFound();
            }
            return View(difficultBlog);
        }

        // GET: DifficultBlogs/Create
        public ActionResult Create()
        {
            ViewBag.Difficulty = db.DifficultBlogs.ToList();
            return View();
        }

        // POST: DifficultBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Difficult")] DifficultBlog difficultBlog)
        {
            if (ModelState.IsValid)
            {
                db.DifficultBlogs.Add(difficultBlog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(difficultBlog);
        }

        // GET: DifficultBlogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.Difficulty=db.DifficultBlogs.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifficultBlog difficultBlog = await db.DifficultBlogs.FindAsync(id);
            if (difficultBlog == null)
            {
                return HttpNotFound();
            }
            return View(difficultBlog);
        }

        // POST: DifficultBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Difficult")] DifficultBlog difficultBlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(difficultBlog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(difficultBlog);
        }

        // GET: DifficultBlogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifficultBlog difficultBlog = await db.DifficultBlogs.FindAsync(id);
            if (difficultBlog == null)
            {
                return HttpNotFound();
            }
            return View(difficultBlog);
        }

        // POST: DifficultBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DifficultBlog difficultBlog = await db.DifficultBlogs.FindAsync(id);
            db.DifficultBlogs.Remove(difficultBlog);
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
