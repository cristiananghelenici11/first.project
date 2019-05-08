using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Enums;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.Abstractions
{
    public interface IUniversityService
    {
        List<TopUniversityDto> GetTopUniversities(int numberOfTeachers);
        List<UniversityShowDto> GetAllUniversities();
        List<UniversityShowDto> GetAllUniversities(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, string search,
            int numberOfRecordsPerPage = 10, bool skipRecords = true);
    }
}