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
    public class DetailsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Details
        public async Task<ActionResult> Index()
        {
            var details = db.Details.Include(d => d.AllowanceType).Include(d => d.Employee);
            return View(await details.ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = await db.Details.FindAsync(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.AllowanceTypeId = new SelectList(db.AllowanceTypes, "AllowanceTypeId", "AllowanceName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DetailsId,EmployeeId,AllowanceTypeId,Amount")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(details);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AllowanceTypeId = new SelectList(db.AllowanceTypes, "AllowanceTypeId", "AllowanceName", details.AllowanceTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", details.EmployeeId);
            return View(details);
        }

        // GET: Details/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = await db.Details.FindAsync(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllowanceTypeId = new SelectList(db.AllowanceTypes, "AllowanceTypeId", "AllowanceName", details.AllowanceTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", details.EmployeeId);
            return View(details);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DetailsId,EmployeeId,AllowanceTypeId,Amount")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(details).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AllowanceTypeId = new SelectList(db.AllowanceTypes, "AllowanceTypeId", "AllowanceName", details.AllowanceTypeId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", details.EmployeeId);
            return View(details);
        }

        // GET: Details/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = await db.Details.FindAsync(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Details details = await db.Details.FindAsync(id);
            db.Details.Remove(details);
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
