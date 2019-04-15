using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataTable.Models;
using Microsoft.EntityFrameworkCore;

namespace DataTable.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


                //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (MvcCRUDDBContext db = new MvcCRUDDBContext())
            {
                List<Employee> empList = db.Employee.ToList<Employee>();
                return Json(new { data = empList });
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                using (MvcCRUDDBContext db = new MvcCRUDDBContext())
                {
                    return View(db.Employee.FirstOrDefault(x => x.EmployeeId==id));
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (MvcCRUDDBContext db = new MvcCRUDDBContext())
            {
                if (emp.EmployeeId == 0)
                {
                    db.Employee.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" });
                }
                else {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" });
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (MvcCRUDDBContext db = new MvcCRUDDBContext())
            {
                Employee emp = db.Employee.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                db.Employee.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" });
            }
        }

    }
}
