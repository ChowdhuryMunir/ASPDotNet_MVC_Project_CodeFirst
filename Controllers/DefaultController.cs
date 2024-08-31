using MVCProjectImplementationOfMasterDetails.DAL;
using MVCProjectImplementationOfMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectImplementationOfMasterDetails.Controllers
{
    public class DefaultController : Controller
    {
        public MyDbContext db = new MyDbContext();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllowanceCategories()
        {
            List<AllowanceCategory> categories = new List<AllowanceCategory>();
            categories = db.AllowanceCategories.OrderBy(a => a.AllowanceCategoryName).ToList();
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getAllowance(int AllowanceCategoryId)
        {
            List<AllowanceType> allowance = new List<AllowanceType>();
            allowance = db.AllowanceTypes.Where(b => b.AllowanceCategoryId.Equals(AllowanceCategoryId)).OrderBy(am => am.AllowanceName).ToList();
            return new JsonResult { Data = allowance, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult Save(Employee employee, HttpPostedFileBase file)
        {
            bool status = false;


            if (file != null /*&& file.ContentLength > 0*/)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);
                employee.Image = fileName;
            }

            var isValidModel = TryUpdateModel(employee);
            if (isValidModel)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}