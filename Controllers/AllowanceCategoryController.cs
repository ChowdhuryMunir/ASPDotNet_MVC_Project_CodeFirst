using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProjectImplementationOfMasterDetails.DAL;
using MVCProjectImplementationOfMasterDetails.Models;

namespace MVCProjectImplementationOfMasterDetails.Controllers
{
    public class AllowanceCategoryController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: AllowanceCategory
        public async Task<ActionResult> Index()
        {
            return View(await db.AllowanceCategories.ToListAsync());
        }

        // GET: AllowanceCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceCategory allowanceCategory = await db.AllowanceCategories.FindAsync(id);
            if (allowanceCategory == null)
            {
                return HttpNotFound();
            }
            return View(allowanceCategory);
        }

        // GET: AllowanceCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllowanceCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AllowanceCategoryId,AllowanceCategoryName")] AllowanceCategory allowanceCategory)
        {
            if (ModelState.IsValid)
            {
                db.AllowanceCategories.Add(allowanceCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(allowanceCategory);
        }

        // GET: AllowanceCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceCategory allowanceCategory = await db.AllowanceCategories.FindAsync(id);
            if (allowanceCategory == null)
            {
                return HttpNotFound();
            }
            return View(allowanceCategory);
        }

        // POST: AllowanceCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AllowanceCategoryId,AllowanceCategoryName")] AllowanceCategory allowanceCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allowanceCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(allowanceCategory);
        }

        // GET: AllowanceCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceCategory allowanceCategory = await db.AllowanceCategories.FindAsync(id);
            if (allowanceCategory == null)
            {
                return HttpNotFound();
            }
            return View(allowanceCategory);
        }

        // POST: AllowanceCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllowanceCategory allowanceCategory = await db.AllowanceCategories.FindAsync(id);
            db.AllowanceCategories.Remove(allowanceCategory);
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
