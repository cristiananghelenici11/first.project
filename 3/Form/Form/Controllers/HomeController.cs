using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TagHelper()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public string Form(Models.Form form)
        {
        
            return $"{form.Name}, {form.Age}, {form.Date}, {form.Tel}, {form.Password}, {form.Email}, {form.Sex}";
        }

//        [HttpPost]
//        public IActionResult Create(Models.Form form)
//        {
//            if (ModelState.IsValid)
//                return Content($"{form.Name}, {form.Age}, {form.Date}, {form.Tel}, {form.Password}, {form.Email}, {form.Sex}");
//            else
//                return View(form);
//        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            if(email == "admin@email.com" || email == "aaa@gmail.com")
                return Json(false);
            return Json(true);
        }


        [HttpPost]
        public IActionResult Create(Models.Form form)
        {
            if (form.Name == form.Password)
            {
                ModelState.AddModelError("", "name and password do not coincide");
            }
             
            if (ModelState.IsValid)

                return Content($"{form.Name} - {form.Email}");
             
            return View(form);
        }

        [HttpDelete]
        public IActionResult DeleteForm(long id)
        {
            if (ModelState.IsValid)
            {

                return Json(new { success = true, responseText = $"Expense deleted!" });
            }
            
            return Json(new { success = false, responseText = $"Model is not valid!" });
        }
    }
}
