using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityRating.Presentation.Models.Comment;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.Teacher;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Enums;
using UniversityRating.Services.Common.DTOs.Teacher;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class AdminSettingController : Controller
    {
        private readonly IUniversityService _universityService;
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;

        public AdminSettingController(IUniversityService universityService, IMapper mapper, ITeacherService teacherService)
        {
            _universityService = universityService;
            _mapper = mapper;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            List<UniversityShowDto> universityShowViewModels = _universityService.GetAllUniversities();
            List<TeacherShowDto> items = _teacherService.GetAllTeachers();

            return View(new IndexViewModel
            {
                TeacherShowViewModels = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(items),

                UniversityShowViewModels =
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowViewModels)
                        .Take(10).ToList()
            });
        }

        [HttpGet]
        public IActionResult UniversitySort(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, string search, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities(universitiesSortColumn, sortType, pageNumber, search,
                numberOfRecordsPerPage = 10, skipRecords = true);
            var model = _mapper.Map<List<UniversityShowViewModel>>(universities);

            return PartialView("_UniversityTableRecordsAdmin", model);
        }


        [HttpPost]
        public IActionResult DeleteUniversity(int id)
        {
            _universityService.DeleteUniversityById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUniversity(long id)
        {
            UniversityShowDto universityShowDto = _universityService.GetAllUniversities().FirstOrDefault(x => x.Id.Equals(id));

            UniversityShowViewModel model = universityShowDto == null
                ? new UniversityShowViewModel()
                : _mapper.Map<UniversityShowDto, UniversityShowViewModel>(universityShowDto);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUniversity(UniversityViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _universityService.Update(_mapper.Map<UniversityDto>(model));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddUniversity(UniversityViewModel universityViewModel)
        {
            if (!ModelState.IsValid) return View(universityViewModel);
            _universityService.AddNewUniversity(_mapper.Map<UniversityDto>(universityViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddUniversity()
        {
            return View(new UniversityViewModel());
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View(new TeacherViewModel());
        }

        [HttpPost]
        public IActionResult AddTeacher(TeacherViewModel teacherViewModel)
        {
            if (!ModelState.IsValid) return View(teacherViewModel);
            _teacherService.AddTeacher(_mapper.Map<TeacherDto>(teacherViewModel));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTeacher(int id)
        {
            _teacherService.DeleteTeacherById(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditTeacher(TeacherViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _teacherService.Update(_mapper.Map<TeacherDto>(model));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTeacher(long id)
        {
            TeacherShowDto teacherShowDtos = _teacherService.GetAllTeachers().FirstOrDefault(x => x.Id.Equals(id));

            TeacherShowViewModel model = teacherShowDtos == null
                ? new TeacherShowViewModel()
                : _mapper.Map<TeacherShowDto, TeacherShowViewModel>(teacherShowDtos);

            return View(model);
        }
        
    }
}