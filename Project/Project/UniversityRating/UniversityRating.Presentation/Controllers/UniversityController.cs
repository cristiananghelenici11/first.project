using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityRating.Presentation.Models.Home;
using UniversityRating.Presentation.Models.University;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Enums;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Presentation.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUniversityService _universityService;

        public UniversityController(
            IMapper mapper, 
            IUniversityService universityService)
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
                    _mapper.Map<List<UniversityShowDto>, List<UniversityShowViewModel>>(universityShowViewModels).Take(10).ToList()
            });
        }

        [HttpGet]
        public IActionResult UniversitySort(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, string search, 
            int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            List<UniversityShowDto> universities = _universityService.GetAllUniversities(universitiesSortColumn, sortType, pageNumber, search,
                numberOfRecordsPerPage = 10, skipRecords = true);
            var model = _mapper.Map<List<UniversityShowViewModel>>(universities);

            return PartialView("_UniversityTableRecords", model);
        }

        //[HttpGet]
        //public IActionResult UniversitySort(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, int numberOfRecordsPerPage = 10, bool skipRecords = true)
        //{
        //    IEnumerable<UniversityShowDto> items = _universityService.GetAllUniversities();

        //    if (universitiesSortColumn != null)
        //    {
        //        if (sortType == SortType.Asc)
        //        {
        //            items = universitiesSortColumn == UniversitiesSortColumn.Age
        //                ? items.OrderBy(x => x.Age)
        //                : items.OrderBy(x => x.AverageMark);
        //        }
        //        else
        //        {
        //            items = universitiesSortColumn == UniversitiesSortColumn.Age
        //                ? items.OrderByDescending(x => x.Age)
        //                : items.OrderByDescending(x => x.AverageMark);
        //        }
        //    }

        //    if (skipRecords)
        //        items = items.Skip((pageNumber - 1) * numberOfRecordsPerPage);

        //    items = items.Take(pageNumber * numberOfRecordsPerPage);

        //    var model = _mapper.Map<List<UniversityShowViewModel>>(items.ToList());

        //    return PartialView("_UniversityTableRecords", model);
        //}
    }
}