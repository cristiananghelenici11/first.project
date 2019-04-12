using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Abstractions
{
    public interface ITeacherService
    {
        List<TopTeacherDto> GetTopTeachers(int numberOfTeachers);
        List<TeacherShowDto> GetAllTeachers();
    }
}