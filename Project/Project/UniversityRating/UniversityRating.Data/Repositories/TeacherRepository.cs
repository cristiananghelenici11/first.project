using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public List<Teacher> GetAllTeachers()
        {
            return BuildQuery()
                .ToList();
        }

        public List<TopTeacher> GetTopTeachers(int numberOfTeachers)
        {
            return BuildQuery()
                .Select(x => new TopTeacher
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MarkAvg =  x.MarkTeachers.Any() ? x.MarkTeachers.Average(y => y.Value) : 0
                })
                .OrderByDescending(x => x.MarkAvg)
                .Take(numberOfTeachers)
                .ToList();
        }

        public List<Teacher> GetAllTeachersByUniversityId(long universityId)
        {
            return BuildQuery()
                .Where(x => x.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId)))
                .ToList();
        }

        public List<Teacher> GetAllTeachersWithoutUniversity()
        {
            return BuildQuery()
                .Where(x => x.UniversityTeachers.Count.Equals(0))
                .ToList();
        }

        public void DeleteTeacherById(int id)
        {
            Teacher teacher = GetById(id);
            if (teacher == null) return;
            Remove(teacher);
            SaveChanges();
        }

        public List<TeacherShow> GetAllTeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage,
            bool skipRecords)
        {
            //IQueryable<Teacher> items = BuildQuery().OfType<Teacher>().Where(x => x.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId)));
            IQueryable<TeacherShow> items;

            if (!string.IsNullOrEmpty(search))
            {
                items = BuildQuery()
                    .Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()))
                    .Select(u => new TeacherShow
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Universities = u.UniversityTeachers.Select(x => x.University.Name).ToList(),
                        TypeTeacher = u.TypeTeacher,
                        Email = u.Email,
                        AverageMarks =  u.MarkTeachers.Any() ? u.MarkTeachers.AsQueryable().Average(x => x.Value) : 0
                    });
            }
            else
            {
                items = BuildQuery()
                    .Select(u => new TeacherShow
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Universities = u.UniversityTeachers.Select(x => x.University.Name).ToList(),
                        TypeTeacher = u.TypeTeacher,
                        Email = u.Email,
                        AverageMarks =  u.MarkTeachers.Any() ? u.MarkTeachers.AsQueryable().Average(x => x.Value) : 0
                    });
            }

            if (skipRecords)
                items = items.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            items = items.Take(numberOfRecordsPerPage);
            List<TeacherShow> teacherShows = items.ToList();

            return teacherShows;
        }
    }
}
