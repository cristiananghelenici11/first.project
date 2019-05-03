using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<TopTeacher> GetTopTeachers(int numberOfTeachers);
        List<TeacherShow> GetAllTeachers();
        List<TeacherShow> GetAllTeachersByUniversityId(long UniversityId);
    }
}