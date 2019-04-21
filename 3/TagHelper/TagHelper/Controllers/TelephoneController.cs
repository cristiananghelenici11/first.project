using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TagHelper.Models;

namespace TagHelper.Controllers
{
    public class TelephoneController : Controller
    {
        public IActionResult AddTel()
        {
            ViewBag.Companies = new SelectList(companies, "Id", "Name");
            return View();
        }

        [HttpPost]
        public string AddTel(Phone phone)
        {
            Company company = companies.FirstOrDefault(c => c.Id == phone.CompanyId);

            return $"Sa adaugat un nou element{phone.Name}, {company?.Name}, {phone.About}";
        }

        IEnumerable<Company> companies = new List<Company>
        {
            new Company { Id = 1, Name = "Apple" },
            new Company { Id = 2, Name = "Samsung" },
            new Company { Id = 3, Name="Microsoft" }
        };


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DayTimeViewModel model)
        {
            return Content(model.Period.ToString());
        }

        public IActionResult HtmlHelper()
        {
            return View();
        }

        [HttpPost]
        public string Create(string name, int price)
        {
            return $"nume = {name}, {price}";
        }

        public IActionResult Create()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Id=1, Name="iPhone 7 Pro", Price=680 },
                new Phone {Id=2, Name="Galaxy 7 Edge", Price=640 },
                new Phone {Id=3, Name="HTC 10", Price=500 },
                new Phone {Id=4, Name="Honor 5X", Price=400 },
            };
            ViewBag.Phones = new SelectList(phones, "Id", "Name");
            return View();
        }

    }
}