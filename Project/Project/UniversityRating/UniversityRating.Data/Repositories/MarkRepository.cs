using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class MarkRepository : Repository<Mark>, IMarkRepository
    {

        public MarkRepository(DbContext context) : base(context)
        {
        }

        public void AddMarkCourse(MarkCourse markCourse)
        {
            Add(markCourse);
            SaveChanges();
        }

        public void AddMarkTeacher(MarkTeacher markTeacher)
        {
            Add(markTeacher);
            SaveChanges();
        }

        public void AddMarkCourseTeacher(MarkCourseTeacher markCourseTeacher)
        {
            Add(markCourseTeacher);
            SaveChanges();
        }

        public void DeleteMarkById(long id)
        {
            Mark mark = GetById(id);
            Remove(mark);
            SaveChanges();
        }
    }
}