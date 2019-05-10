using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Course;

namespace UniversityRating.Services.Abstractions
{
    public interface ICourseService
    {
        List<CourseDto> GetAllCoursesByUniversityId(long universityId);

        List<CourseDto> GetAllCoursesByTeacherId(long teacherId);
    }
}