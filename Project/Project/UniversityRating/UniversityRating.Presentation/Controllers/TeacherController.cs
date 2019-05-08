using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityRating.Presentation.Models;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;
        private readonly IUniversityService _universityService;

        public TeacherController(IMapper mapper, ITeacherService teacherService, IUniversityService universityService)
        {
            _mapper = mapper;
            _teacherService = teacherService;
            _universityService = universityService;
        }

        public IActionResult Index(int page)
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * 5).Take(5).ToList();

            var viewModel = new IndexViewModel
            {
                TeacherShowViewModels = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(items),
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities)

            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult MoreTeachers(int page)
        {
            const int pageSize = 5;
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            string result = JsonConvert.SerializeObject(items);
            return Content(result, "application/json");
        }

        [HttpGet]
        public IActionResult TeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            IEnumerable<TeacherShowDto> items2;
            IEnumerable<TeacherShowDto> items;
            if (search == null)
            {
                items2 = _teacherService.GetAllTeachersByUniversityId(universityId);
                items = _teacherService.GetAllTeachers();
            }
            else
            {
                items2 = _teacherService.GetAllTeachersByUniversityId(universityId).Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()));
                items = _teacherService.GetAllTeachers().Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()));
            }

            if (universityId.Equals(0))
            {
                if (skipRecords)
                    items = items.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                items = items.Take(numberOfRecordsPerPage);
                var model = _mapper.Map<List<TeacherShowViewModel>>(items.ToList());
                return PartialView("_TeacherTableRecords", model);
            }

            if (skipRecords)
                items2 = items2.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            items2 = items2.Take(pageNumber * numberOfRecordsPerPage);
            var model2 = _mapper.Map<List<TeacherShowViewModel>>(items2.ToList());
            return PartialView("_TeacherTableRecords", model2);
        }

    }
}