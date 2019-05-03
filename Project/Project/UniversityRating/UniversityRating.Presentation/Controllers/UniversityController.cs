using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUniversityService _universityService;

        public UniversityController(IMapper mapper, IUniversityService universityService)
        {
            _mapper = mapper;
            _universityService = universityService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<UniversityShowDto> universityShowViewModels = _universityService.GetAllUniversities();

            return View(new IndexViewModel
            {
                UniversityShowViewModels =
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowViewModels)
            });
        }


        [HttpGet]
        public IActionResult UniversitySort(int sort, int page)
        {
            const int pageSize = 5;
            if (sort.Equals(0))
            {
                int count = _universityService.GetAllUniversities().Count;
                List<UniversityShowDto> items = _universityService.GetAllUniversities().Skip((page - 1) * pageSize).Take(pageSize).ToList();

                return Content(JsonConvert.SerializeObject(items.OrderByDescending(x => x.AverageMark)), "application/json");
            }

            IOrderedEnumerable<UniversityShowDto> universityShow = _universityService.GetAllUniversities().OrderByDescending(x => x.Age);
            string result = JsonConvert.SerializeObject(universityShow);

            return Content(result, "application/json");
        }

        [HttpGet]
        public IActionResult UniversitySearch(string search)
        {
            IEnumerable<UniversityShowDto> universities = _universityService.GetAllUniversities().Where(x => x.Name.ToUpper().Equals(search.ToUpper()));
            string result = JsonConvert.SerializeObject(universities);
            return Content(result, "application/json");
        }

    }
}