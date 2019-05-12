using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public TeacherController(
            IMapper mapper, 
            ITeacherService teacherService, 
            IUniversityService universityService)
        {
            _mapper = mapper;
            _teacherService = teacherService;
            _universityService = universityService;
        }

        public IActionResult Index(int page)
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities();
            List<TeacherShowDto> items = _teacherService.GetAllTeachersByUniversityId(0, 1, null, 10, true);

            var viewModel = new IndexViewModel
            {
                TeacherShowViewModels = _mapper.Map<List<TeacherShowDto>, List<TeacherShowViewModel>>(items),
                UniversityShowViewModels = _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universities)

            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult TeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<TeacherShowDto> teacherDtos = _teacherService.GetAllTeachersByUniversityId(universityId, pageNumber, search, numberOfRecordsPerPage = 10, skipRecords = true);
            var teacherViewModel = _mapper.Map<List<TeacherShowViewModel>>(teacherDtos);

            return PartialView("_TeacherTableRecords", teacherViewModel);
        }
    }
}