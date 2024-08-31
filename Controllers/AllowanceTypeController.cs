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
    public class AllowanceTypeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: AllowanceType
        public async Task<ActionResult> Index()
        {
            var allowanceTypes = db.AllowanceTypes.Include(a => a.AllowanceCategory);
            return View(await allowanceTypes.ToListAsync());
        }

        // GET: AllowanceType/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceType allowanceType = await db.AllowanceTypes.FindAsync(id);
            if (allowanceType == null)
            {
                return HttpNotFound();
            }
            return View(allowanceType);
        }

        // GET: AllowanceType/Create
        public ActionResult Create()
        {
            ViewBag.AllowanceCategoryId = new SelectList(db.AllowanceCategories, "AllowanceCategoryId", "AllowanceCategoryName");
            return View();
        }

        // POST: AllowanceType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AllowanceTypeId,AllowanceName,AllowanceCategoryId")] AllowanceType allowanceType)
        {
            if (ModelState.IsValid)
            {
                db.AllowanceTypes.Add(allowanceType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AllowanceCategoryId = new SelectList(db.AllowanceCategories, "AllowanceCategoryId", "AllowanceCategoryName", allowanceType.AllowanceCategoryId);
            return View(allowanceType);
        }

        // GET: AllowanceType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceType allowanceType = await db.AllowanceTypes.FindAsync(id);
            if (allowanceType == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllowanceCategoryId = new SelectList(db.AllowanceCategories, "AllowanceCategoryId", "AllowanceCategoryName", allowanceType.AllowanceCategoryId);
            return View(allowanceType);
        }

        // POST: AllowanceType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AllowanceTypeId,AllowanceName,AllowanceCategoryId")] AllowanceType allowanceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allowanceType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AllowanceCategoryId = new SelectList(db.AllowanceCategories, "AllowanceCategoryId", "AllowanceCategoryName", allowanceType.AllowanceCategoryId);
            return View(allowanceType);
        }

        // GET: AllowanceType/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceType allowanceType = await db.AllowanceTypes.FindAsync(id);
            if (allowanceType == null)
            {
                return HttpNotFound();
            }
            return View(allowanceType);
        }

        // POST: AllowanceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllowanceType allowanceType = await db.AllowanceTypes.FindAsync(id);
            db.AllowanceTypes.Remove(allowanceType);
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
