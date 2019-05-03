using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IMarkRepository : IRepository<Mark>
    {
        void AddMarkTeacher(MarkTeacher markTeacher);
        void AddMarkCourse(MarkCourse markCourse);
    }
}