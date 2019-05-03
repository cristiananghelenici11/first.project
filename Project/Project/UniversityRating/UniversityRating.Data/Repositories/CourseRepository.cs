using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

        public List<Course> GetAllCoursesByUniversityId(long universityId)
        {
            return BuildQuery()
                .Where(x => x.Faculty.Universtity.Id.Equals(universityId))
                .Select(c => new Course()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToList();
        }
        
        public List<Course> GetAllCoursesByTeacherId(long teacherId)
        {
            return BuildQuery()
                .Where(x => x.CourseTeachers.Any(y => y.TeacherId.Equals(teacherId)))
                .Select(c => new Course()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToList();
        }
    }
}