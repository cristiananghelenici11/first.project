using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Models;
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

        public List<TeacherShow> GetAllTeachers()
        {
            return BuildQuery()
                .Select(t => new TeacherShow()
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    TypeTeacher = t.TypeTeacher,
                    AverageMarks = t.MarkTeachers.Any() ? t.MarkTeachers.Average(x => x.Value) : 0,
                    Universities = t.UniversityTeachers.Select(x => x.University.Name).ToList()
                })
                .ToList();
        }

        public List<TopTeacher> GetTopTeachers(int numberOfTeachers)
        {
            return BuildQuery()
                .Select(t => new TopTeacher
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    MarkAvg = t.MarkTeachers.Any() ? t.MarkTeachers.AsQueryable().Average(x => x.Value) : 0
                })
                .OrderByDescending(tt => tt.MarkAvg)
                .Take(numberOfTeachers)
                .ToList();
        }

        public List<TeacherShow> GetAllTeachersByUniversityId(long universityId)
        {
            return BuildQuery()
                .Where(x => x.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId)))
                .Select(t => new TeacherShow
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    TypeTeacher = t.TypeTeacher,
                    AverageMarks = t.MarkTeachers.Any() ? t.MarkTeachers.Average(x => x.Value) : 0,
                    Universities = t.UniversityTeachers.Select(x => x.University.Name).ToList()
                })
                .ToList();
        }

        public List<TeacherShow> GetAllTeachersWithoutUniversity()
        {
            return BuildQuery()
                .Where(x => x.UniversityTeachers.Count().Equals(0))
                .Select(t => new TeacherShow
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    TypeTeacher = t.TypeTeacher,
                    AverageMarks = t.MarkTeachers.Any() ? t.MarkTeachers.Average(x => x.Value) : 0,
                    Universities = t.UniversityTeachers.Select(x => x.University.Name).ToList()
                })
                .ToList();
        }

        public void DeleteTeacherById(int id)
        {
            Teacher teacher = GetById(id);
            Remove(teacher);
            SaveChanges();
        }

        public List<TeacherShow> GetAllTeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage,
            bool skipRecords)
        {

            var spec = new Specification<Teacher> {Predicate = user => user.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId))};
            IEnumerable<Teacher> items2 = null;
            IEnumerable<Teacher> items = null;
            if (search == null)
            {
                items2 = Find(spec);
                items = Find();
            }
            else
            {
                items2 = items2.Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()));
                items = items.Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()));
            }

            List<TeacherShow> teacherShows = new List<TeacherShow>();
            if (universityId.Equals(0))
            {
                if (skipRecords)
                    items = items.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                items = items.Take(numberOfRecordsPerPage);

                foreach (Teacher teacher in items)
                {
                    teacherShows.Add(new TeacherShow
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        Email = teacher.Email,
                        TypeTeacher = teacher.TypeTeacher,
                        Id = teacher.Id
                    });
                }
                return teacherShows;
            }

            if (skipRecords)
                items2 = items2.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            items2 = items2.Take(numberOfRecordsPerPage);

            foreach (Teacher teacher in items)
            {
                teacherShows.Add(new TeacherShow
                {
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    TypeTeacher = teacher.TypeTeacher,
                    Id = teacher.Id
                });
            }

            return teacherShows;
        }
    }
}