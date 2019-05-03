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

            const int pageSize = 5;

            int count = _teacherService.GetAllTeachers().Count;
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                TeacherShows = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(items),
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities)

            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult MoreTeachers(int page)
        {
            const int pageSize = 5;

            int count = _teacherService.GetAllTeachers().Count;
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            string result = JsonConvert.SerializeObject(items);
            return Content(result, "application/json");
        }

        [HttpGet]
        public IActionResult TeachersByUniversityId(long universityId, int page)
        {
            const int pageSize = 5;
            if (universityId.Equals(0))
            {
                int count = _teacherService.GetAllTeachers().Count();
                List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

                return Content(JsonConvert.SerializeObject(items), "application/json");
            }
            
            List<TeacherShowDto> teachersByUniversityId = _teacherService.GetAllTeachersByUniversityId(universityId);
            string result = JsonConvert.SerializeObject(teachersByUniversityId);

            return Content(result, "application/json");
        }
    }
}