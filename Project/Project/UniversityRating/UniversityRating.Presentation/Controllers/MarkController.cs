using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityRating.Data.Core.DomainModels.Identity;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.Mark;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Course;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class MarkController : Controller
    {
        private IMapper _mapper;
        private IUniversityService _universityService;
        private ITeacherService _teacherService;
        private ICourseService _courseService;
        private readonly SignInManager<User> _signInManager;
        private readonly IMarkService _markService;

        public MarkController(
            IMapper mapper, 
            IUniversityService universityService, 
            ITeacherService teacherService, 
            ICourseService courseService, 
            IMarkService markService,
            SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _universityService = universityService;
            _teacherService = teacherService;
            _courseService = courseService;
            _signInManager = signInManager;
            _markService = markService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            long currentUser = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));

            List<UniversityShowDto> universities = _universityService.GetAllUniversities();
            List<EditMarkTeacherDto> editMarkTeacherViewModels = _markService.GetMarkTeacherByUserId(currentUser);
            List<EditMarkCourseDto> editMarkCourseDtos = _markService.GetMarkCourseByUserId(currentUser);
            List<EditMarkCourseTeacherDto> editMarkCourseTeacherDtos = _markService.GetMarkCourseTeacherByUserId(currentUser);

            return View(new IndexViewModel
            {
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities),
                EditMarkTeacherViewModels = _mapper.Map<List<EditMarkTeacherDto>, List<EditMarkTeacherViewModel>>(editMarkTeacherViewModels),
                EditMarkCourseViewModels = _mapper.Map<List<EditMarkCourseDto>, List<EditMarkCourseViewModel>>(editMarkCourseDtos),
                EditMarkCourseTeacherViewModels = _mapper.Map<List<EditMarkCourseTeacherDto>, List<EditMarkCourseTeacherViewModel>>(editMarkCourseTeacherDtos)
            });
        }

        [HttpGet]
        public IActionResult TeachersByUniversityId(long universityId)
        {
            if (universityId.Equals(0))
            {
                List<TeacherShowDto> teachersWithoutUniversity = _teacherService.GetAllTeachersWithoutUniversity();

                return Content(JsonConvert.SerializeObject(teachersWithoutUniversity), "application/json");
            }
            List<TeacherShowDto> teachersByUniversityId = _teacherService.GetAllTeachersByUniversityId(universityId);
            string result = JsonConvert.SerializeObject(teachersByUniversityId);

            return Content(result, "application/json");
        }

        
        [HttpGet]
        public IActionResult CoursesByUniversityId(long universityId)
        {
            List<CourseDto> courses = _courseService.GetAllCoursesByUniversityId(universityId);
            string result = JsonConvert.SerializeObject(courses);

            return Content(result, "application/json");
        }

        [HttpGet]
        public IActionResult CoursesByTeacherId(long teacherId)
        {
            List<CourseDto> courses = _courseService.GetAllCoursesByTeacherId(teacherId);
            string result = JsonConvert.SerializeObject(courses);

            return Content(result, "application/json");
        }

        [HttpPost]
        public IActionResult AddMarkTeacher(MarkTeacherViewModel markTeacher)
        {
            markTeacher.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _markService.AddMarkTeacher(_mapper.Map<MarkTeacherViewModel, MarkTeacherDto>(markTeacher));

            return Content(JsonConvert.SerializeObject($"Success add mark {markTeacher.Mark}"), "application/json");
        }

        [HttpPost]
        public IActionResult AddMarkCourse(MarkCourseViewModel markCourse)
        {
            markCourse.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _markService.AddMarkCourse(_mapper.Map<MarkCourseViewModel, MarkCourseDto>(markCourse));

            return Content(JsonConvert.SerializeObject($"Success add mark {markCourse.Mark}"), "application/json");
        }

        [HttpPost]
        public IActionResult AddMarkCourseTeacher(MarkCourseTeacherViewModel markCourseTeacher)
        {
            markCourseTeacher.UserId = Convert.ToInt32(_signInManager.UserManager.GetUserId(User));
            _markService.AddMarkCourseTeacher(_mapper.Map<MarkCourseTeacherViewModel, MarkCourseTeacherDto>(markCourseTeacher));

            return Content(JsonConvert.SerializeObject($"Success add mark {markCourseTeacher.Mark}"), "application/json");
        }

        [HttpPost]
        public IActionResult DeleteMark(int id)
        {
            if (!ModelState.IsValid) return Content(JsonConvert.SerializeObject("Not valid"));
            _markService.DeleteMarkById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditMark(long id)
        {
            EditMarkDto markDto = _markService.GetMarkById(id);
            EditMarkViewModel model = markDto == null
                ? new EditMarkViewModel()
                : _mapper.Map<EditMarkDto, EditMarkViewModel>(markDto);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMark(EditMarkViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _markService.UpdateMark(_mapper.Map<EditMarkViewModel, EditMarkDto>(model));

            return RedirectToAction("Index");
        }
    }
}
