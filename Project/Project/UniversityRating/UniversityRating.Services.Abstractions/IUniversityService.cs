using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.Abstractions
{
    public interface IUniversityService
    {
        List<TopUniversityDto> GetTopUniversities(int numberOfTeachers);
        List<UniversityShowDto> GetAllUniversities();

    }
}