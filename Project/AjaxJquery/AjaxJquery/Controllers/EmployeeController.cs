using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AjaxJquery.Models;

namespace AjaxJquery.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            using (DBModels db = new DBModels())
            {
                return db.Employees.ToList();
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Employee emp = new Employee();
            return View();
        }


        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}