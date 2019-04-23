using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Form.Controllers
{
    public class CrudController : Controller
    {
        // GET
        public IActionResult AddForm()
        {
            return View();
        }


        //        [HttpPost]
        //        public string AddForm([FromBody]Models.Form form)
        //        {
        //            if (ModelState.IsValid)
        //            {
        ////                return Json(new { success = true, responseText = $"Form {form.Name} added!" });
        //                return "success";
        //            }

        ////            return Json(new { success = false, responseText = $"Form {form.Name} not added!" });
        //            return "Not success";
        //        }

        [HttpPost]
        public string AddForm([FromBody] Models.Form form)
        {
            if (ModelState.IsValid)
            {

                if (form.Name == form.Password)
                {
                    ModelState.AddModelError("", "name and password do not coincide");
                }

            }

            return "success";
        }

        [HttpGet]
        public ActionResult MoreTables(int id)
        {
            var model = new Models.Form()
            {
                Name = "Name",
                Age = 22,
                Tel = 0277468,
                Email = "an.cris@mail.ru",
                Sex = true,
                Date = DateTime.Now,
                Password = "ttt"
            };

            var items = new List<Models.Form>();
            items.Add(model);


            var result = JsonConvert.SerializeObject(items);
            return Content(result, "application/json");
        }


    }
}