using System.Collections.Generic;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetTopTeachers(int numberOfTeachers);

        List<Teacher> GetAllTeachers();

        List<Teacher> GetAllTeachersByUniversityId(long universityId);

        List<Teacher> GetAllTeachersWithoutUniversity();

        void DeleteTeacherById(int id);

        List<TeacherShow> GetAllTeachersByUniversityId(long universityId, int pageNumber, string search,
            int numberOfRecordsPerPage, bool skipRecords);
    }
}