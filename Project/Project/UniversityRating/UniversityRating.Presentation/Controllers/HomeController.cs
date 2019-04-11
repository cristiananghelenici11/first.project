using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityRating.Presentation.Models;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public HomeController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TopTeacherDto> topTeacherDtos = _teacherService.GetTopTeachers(2);

            return View(new IndexViewModel
            {
                TopTeachers = _mapper.Map<List<TopTeacherDto>, List<TopTeacherViewModel>>(topTeacherDtos)
            });
        }

        [HttpGet]
        public IActionResult Courses()
        {
            return View();
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
