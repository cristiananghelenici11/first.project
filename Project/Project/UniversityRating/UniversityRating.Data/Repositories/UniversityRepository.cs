using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Models.University;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Common.DTOs.Enums;

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
                        ? u.UniversityTeachers.Average(x => x.Teacher.MarkTeachers.Any()
                            ? x.Teacher.MarkTeachers.Average(y => y.Value) : 0) : 0,
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

                })
                .OrderByDescending(am => am.AvgMark)
                .Take(numberOfUniversities)
                .ToList();
        }


        public List<UniversityShow> GetAllUniversities(UniversitiesSortColumn? universitiesSortColumn, SortType sortType, int pageNumber, string search,
            int numberOfRecordsPerPage = 10, bool skipRecords = true)
        {
            IEnumerable<UniversityShow> items;
            if (!string.IsNullOrEmpty(search))
            {
                items = BuildQuery()
                    .Where(x => x.Name.ToUpper().Contains(search.ToUpper()) || x.Description.ToUpper().Contains(search.ToUpper()))
                    .Select(u => new UniversityShow
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Description = u.Description,
                        Contact = u.Contact,
                        Age = u.Age,
                        AverageMark = u.UniversityTeachers.Any()
                            ? u.UniversityTeachers.Average(x => x.Teacher.MarkTeachers.Any()
                                ? x.Teacher.MarkTeachers.Average(y => y.Value) : 0) : 0,
                    });
            }
            else
            {
                items = BuildQuery()
                .Select(u => new UniversityShow
                {
                    Id = u.Id,
                    Name = u.Name,
                    Description = u.Description,
                    Contact = u.Contact,
                    Age = u.Age,
                    AverageMark = u.UniversityTeachers.Any()
                        ? u.UniversityTeachers.Average(x => x.Teacher.MarkTeachers.Any()
                            ? x.Teacher.MarkTeachers.Average(y => y.Value) : 0) : 0,
                });
            }

            if (universitiesSortColumn != null)
            {
                if (sortType == SortType.Asc)
                {
                    items = universitiesSortColumn == UniversitiesSortColumn.Age
                        ? items.OrderBy(x => x.Age)
                        : items.OrderBy(x => x.AverageMark);
                }
                else
                {
                    items = universitiesSortColumn == UniversitiesSortColumn.Age
                        ? items.OrderByDescending(x => x.Age)
                        : items.OrderByDescending(x => x.AverageMark);
                }
            }

            if (skipRecords)
                items = items.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            items = items.Take(numberOfRecordsPerPage);
            List<UniversityShow> result = items.ToList();

            return result;
        }

        public void DeleteUniversityById(int id)
        {
            University university = GetById(id);
            Remove(university);
            SaveChanges();
        }
    }
}