using System.Collections.Generic;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetAllCoursesByUniversityId(long universityId);
        List<Course> GetAllCoursesByTeacherId(long teacherId);
        long GetCourseTeacherId(long courseId, long teacherId);
    }
}