using System.Collections.Generic;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IMarkRepository : IRepository<Mark>
    {
        void AddMarkTeacher(MarkTeacher markTeacher);

        void AddMarkCourse(MarkCourse markCourse);

        void AddMarkCourseTeacher(MarkCourseTeacher markCourseTeacher);

        void DeleteMarkById(long id);
    }
}