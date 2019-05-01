using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UniversityRating.Data.Core.DomainModels.Identity;
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
        private readonly ICommentService _commentService;

        public HomeController(ITeacherService teacherService, IUniversityService universityService, IMapper mapper, ICommentService commentService)
        {
            _universityService = universityService;
            _teacherService = teacherService;
            _mapper = mapper;
            _commentService = commentService;
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
            List<UniversityShowDto> universityShowDtos = _universityService.GetAllUniversities();

            return View(new IndexViewModel
            {
                UniversityShowViewModels = 
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowDtos)
            });
        }

        [HttpGet]
        public IActionResult UniversityFeedback(long universityId)
        {
            List<CommentUniversityShowDto> commentDtos = _commentService.GetCommentsByUniversityId(universityId);

            return Json(commentDtos);
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

        public IActionResult Teachers(int page)
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();

            int pageSize = 5;
            List<TeacherShowDto> teacherShowDtos = _teacherService.GetAllTeachers();
            int count = _teacherService.GetAllTeachers().Count();
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                TeacherShows = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(items), 
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities)
                
            };

            return View(viewModel);
        }

        public IActionResult MoreTeachers(int page)
        {
            
            int pageSize = 5;

            List<TeacherShowDto> teacherShowDtos = _teacherService.GetAllTeachers();
            int count = _teacherService.GetAllTeachers().Count();
            List<TeacherShowDto> items = _teacherService.GetAllTeachers().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = JsonConvert.SerializeObject(items);
            return Content(result, "aplication/json");

        }
    }
}
