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
                .Where(x => x.Faculty.University.Id.Equals(universityId))
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

        public long GetCourseTeacherId(long courseId, long teacherId)
        {
            var result = BuildQuery()
                .Where(x => x.CourseTeachers.Any(y => (y.TeacherId.Equals(teacherId)) && (y.CourseId.Equals(courseId))))
                .Select(c => new
                {
                    Id = c.CourseTeachers.Select(x => x.Id),
                }).FirstOrDefault();

            return result.Id.FirstOrDefault();

        }
    }
}