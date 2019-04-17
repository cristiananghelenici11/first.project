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
    }
}