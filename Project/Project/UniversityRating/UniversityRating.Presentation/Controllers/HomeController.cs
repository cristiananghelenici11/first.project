using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityRating.Presentation.Models;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IUniversityService _universityService;
        private readonly IMapper _mapper;

        public HomeController(ITeacherService teacherService, IUniversityService universityService ,IMapper mapper)
        {
            _universityService = universityService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TopTeacherDto> topTeacherDtos = _teacherService.GetTopTeachers(2);
            List<TopUniversityDto> topUniversityDtos = _universityService.GetTopUniversities(3);


            return View(new IndexViewModel
            {
                TopTeachers = _mapper.Map<List<TopTeacherDto>, List<TopTeacherViewModel>>(topTeacherDtos),
                TopUniversities = _mapper.Map<List<TopUniversityDto>, List<TopUniversityViewModel>>(topUniversityDtos)
            });
        }        

        [HttpGet]
        public IActionResult Universities()
        {
            List<UniversityShowDto> universityShowViewModels = _universityService.GetAllUniversities();

            return View(new IndexViewModel
            {
                UniversityShowViewModels =
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowViewModels)
            });
        }

        [HttpGet]
        public IActionResult User()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Teachers()
        {
            List<TeacherShowDto> teacherShowDtos = _teacherService.GetAllTeachers();

            return View(new IndexViewModel
            {
                TeacherShows = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(teacherShowDtos)
            });
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Maps()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Specialties()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Feedback()
        {
            List<TeacherShowDto> teacherShowDtos = _teacherService.GetAllTeachers();

            return View(new IndexViewModel
            {
                TeacherShows = 
                    _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(teacherShowDtos)
            });
        }

        [HttpPost]
        public JsonResult Feedback(long Id)
        {
            List<TeacherShowDto> teacherShowDtos = _teacherService.GetAllTeachers();
            return Json(teacherShowDtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
