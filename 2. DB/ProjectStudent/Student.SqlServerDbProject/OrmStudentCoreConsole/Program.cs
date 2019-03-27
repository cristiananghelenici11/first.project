using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StudentFirstCore.Models;
using StudentFirstCore.Repositories;
using DomainStudent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Universities = StudentFirstCore.Models.Universities;

namespace OrmStudentCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Program ...\n");
            Console.WriteLine("-----> University <--------");
            using (StudentContext sc = new StudentContext())
            {
                var universities = sc.Universities.ToList();

                foreach (var university in universities)
                {
                    Console.WriteLine($"{university.Id}, {university.Name}, {university.Description}");
                }
            }

            Console.WriteLine("\n-----> Course <--------");
            using (StudentContext sc = new StudentContext())
            {
                var courses = sc.Courses.ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.Id}, {course.Name}, {course.Description}, {course.Faculty?.Name}");
                }
            }
            ////////////////////////////

            EFGenericRepository<StudentFirstCore.Models.Universities> universityRepo = new EFGenericRepository<StudentFirstCore.Models.Universities>(new StudentContext());

            IEnumerable<StudentFirstCore.Models.Universities> universities29 = universityRepo.GetWithInclude(u => u.Faculties);
            foreach (StudentFirstCore.Models.Universities university in universities29)
            {
                Console.WriteLine($"{university.Name} ({university.Description}) Faculties:");
                foreach (var f in university.Faculties)
                {
                    Console.WriteLine($"\t{f.Name}, {f.Description}, {f.Address}");
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////


            Console.WriteLine("-----------------------------------------------");
            using (var context = new StudentContext())
            {
                //Grouping
                Console.WriteLine("\n---> Group --->");
                var universities = context
                    .Universities.Include(x => x.Faculties)
                    .GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        AvgAge = x.Average(y => y.Age)
                    });

                foreach (var university in universities)
                {
                    Console.WriteLine($"{university.Name}, {university.AvgAge}");
                }

                var universities2 = context
                    .Faculties
                    .Where(x => x.Name != null)
                    .GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        Count = x.Count()
                    })
                    .Where(x => x.Count >= 1);
                foreach (var university in universities2)
                {
                    Console.WriteLine($"{university.Name}, {university.Count}");
                }

                //GROUPJOIN
                Console.WriteLine("\n---> Group join --->");
                var topUniversities = context.Universities
                    .GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        CountFaculties = x.Average(y => y.Faculties.Count)
                    })
                    .OrderByDescending(x => x.Name);

                var Universities2 = topUniversities.GroupJoin(
                    context.Universities,
                    x => x.Name,
                    x => x.Name,
                    (u, Descriptions) => new
                    {
                        u.Name,
                        Descriptions = Descriptions.Select(y => y.Description).ToList()
                    });

                foreach (var university in Universities2)
                {
                    Console.WriteLine($"{university.Name}");
                    foreach (string description in university.Descriptions)
                    {
                        Console.WriteLine($"{description}");
                    }
                }

                //Ienumerable vs Iqueryable
                IEnumerable<Faculties> faculties = context
                    .Faculties
                    .Where(x => x.UniverstityId == 1);
                IEnumerable<Faculties> facultiesWithIEnumerable = faculties.Where(x => x.Universtity.Age > 29);

                IQueryable<Faculties> faculties2 = context
                    .Faculties
                    .Where(x => x.UniverstityId == 1);
                IQueryable<Faculties> facultiesWithIQueryable = faculties2.Where(x => x.Universtity.Age > 29);


                // AsNoTracking()
                Universities firstUniversity = context.Universities.AsNoTracking().FirstOrDefault();
                if (firstUniversity != null) firstUniversity.Name = "---";
                context.SaveChanges();

                Console.WriteLine("\n---> Subqueries: Select example <---");
                var teachers = context
                    .Teachers
                    .Select(x => new
                    {
                        Name = x.FirstName + x.LastName,
                        Marks = x.Marks.Average(y => y.Value)
                    });
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.Name}, {teacher.Marks}");
                }

                Console.WriteLine("---> Subqueries: Filter example (ALL & ANY) <---");
                Console.WriteLine("\nAll");
                IQueryable<Teachers> topTeachersAll = context
                    .Teachers
                    .Where(x => x.Marks.All(y => y.Value >= 8));
                foreach (Teachers teacher in topTeachersAll)
                {
                    Console.WriteLine($"{teacher.FirstName + teacher.LastName}");
                }

                Console.WriteLine("\nAny");
                IQueryable<Teachers> topTeachersAny = context
                    .Teachers
                    .Where(x => x.Marks.Any(y => y.Value >= 8));
                foreach (Teachers teacher in topTeachersAny)
                {
                    Console.WriteLine($"{teacher.FirstName + teacher.LastName}");
                }

                Console.WriteLine("\nCASE WHEN");
                var ageRangeUniversity = context
                    .Universities
                    .Select(x => new
                    {
                        Description = x.Description ?? "mising description",
                        AgeRange =
                            x.Age >= 0 && x.Age < 10 ? "0-10" :
                            x.Age > 10 ? "old university" :
                            "default"
                    });
                foreach (var u in ageRangeUniversity)
                {
                    Console.WriteLine($"{u.Description}, {u.AgeRange}");
                }

                //
                IQueryable<Universities> query = context.Universities;
                var page = 100;
                var pageSize = 10;

                context
                    .Universities
                    .OrderBy(x => x.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

                Console.WriteLine("---> SQL statements <---");
                var other = context
                    .Universities
                    .FromSql("SELECT * FROM Universities WHERE Age > 0")
                    .Where(x => x.Age > 0)
                    .Select(x => new
                    {
                        x.Name
                    });
                foreach (var o in other)
                {
                    Console.WriteLine($"{o.Name}");
                }

                Console.WriteLine("---> paginating <---");
                var pageExemple = context
                    .Universities
                    .Where(x => x.Age > 0)
                    .Page();

                foreach (var p in pageExemple)
                {
                    Console.WriteLine($"{p.Name},{p.Description}");
                }


                Console.WriteLine("---> dynamic <---");
                IQueryable<Universities> queryUniversity = context.Universities;
                IQueryable<Universities> universityDynamic = FilterDeviceList(queryUniversity, new Universities{Name = "UTM"});
                foreach (Universities university in universityDynamic)
                {
                    Console.WriteLine($"{university.Name}, {university.Description}, {university.Age}");
                }

            }

            Console.WriteLine("\n---> End Program <---");
            Console.ReadKey();

        }
        private static IQueryable<Universities> FilterDeviceList(IEnumerable<Universities> devices, Universities device)
        {
            IQueryable<Universities> query = devices.AsQueryable();

            if (device.Name != null)
                query = query.Where(d => d.Name == device.Name);

            if (device.Description != null)
                query = query.Where(d => d.Description == device.Description);

            if (device.Age > 0)
                query = query.Where(d => d.Age == device.Age);

            if (device.Contact != null)
                query = query.Where(d => d.Contact == device.Contact);

            return query;
        }
    }
}
