using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Models;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(DbContext context) : base(context)
        {
        }

        public List<UniversityShow> GetAllUniversities()
        {
            return BuildQuery()
                .Select(u => new UniversityShow()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Description = u.Description,
                    Contact = u.Contact,
                    Age = u.Age,
                    AverageMark = u.UniversityTeachers.Any()
                        ? u.UniversityTeachers.Average(x =>
                            x.Teacher.MarkTeachers.Any() 
                                ? x.Teacher.MarkTeachers.Average(y => y.Value) 
                                : 0)
                        : 0
                })
                .ToList();
        }

        public List<TopUniversity> GetTopUniversities(int numberOfUniversities)
        {
            return BuildQuery()
                .Select(u => new TopUniversity()
                {
                    Name = u.Name,
                    Contact = u.Contact,
                    Address = u.Address,
                    Age = u.Age,
                    Description = u.Description,
                    AvgMark = u.UniversityTeachers.Any() 
                        ? u.UniversityTeachers.Average(x => x.Teacher.MarkTeachers.Any()
                        ? x.Teacher.MarkTeachers.Average(y => y.Value) : 0) : 0 

                    //AvgMark = 0// u.UniversityTeachers.Select(x => x.Teacher.MarkTeachers.Any()).Any() ? u.UniversityTeachers.Average(x => x.Teacher.MarkTeachers.Average(m => m.Value)) : 0
                })
                .OrderByDescending(am => am.AvgMark)
                .Take(numberOfUniversities)
                .ToList();
        }
    }
}
