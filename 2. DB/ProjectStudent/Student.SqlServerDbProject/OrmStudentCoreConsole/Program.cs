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

            Console.WriteLine("-----------------------------------------------");
            using (var context = new StudentContext())
            {
                //Grouping
                Console.WriteLine("\n---> Group --->");
                var universities = context.Universities.GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        AvgAge = x.Average(y => y.Age)
                    });

                var universities2 = context.Faculties.Where(x => x.Name != null)
                    .GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        Count = x.Count(m=> m.Universtity != null)
                    })
                    .Where(x => x.Count >= 1);

                //GROUPJOIN
                Console.WriteLine("\n---> Group join --->");
                var topUniversities = context.Universities.GroupBy(x => x.Name)
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

                Console.WriteLine("\n---> Subqueries: Select example <---");
                var teachers = context
                    .Teachers
                    .Select(x => new
                    {
                        Name = x.FirstName + x.LastName,
                        Marks = x.Marks.Average(y => y.Value)
                    });

                Console.WriteLine("---> Subqueries: Filter example (ALL & ANY) <---");
                Console.WriteLine("\nAll");
                var topTeachersAll = context.Teachers
                    .Where(x => x.Marks.All(y => y.Value >= 8));


                Console.WriteLine("\nAny");
                var topTeachersAny = context.Teachers
                    .Where(x => x.Marks.Any(y => y.Value >= 8));

                Console.WriteLine("\nCASE WHEN");
                var ageRangeUniversity = context.Universities
                    .Select(x => new
                    {
                        Description = x.Description ?? "mising description",
                        AgeRange =
                            x.Age >= 0 && x.Age < 10 ? "0-10" :
                            x.Age > 10 ? "old university" :
                            "default"
                    });

                //cursuri une nui nis un student(profesor) cu note mai mic de 4
                context.Courses.Where(x => x.Marks.All(c => c.Value > 4));

                //teacher care nu au note mai mari ca 4
                context.Teachers.Where(x => x.Marks.All(s => s.Value > 4));

                //teacher cite comentarii are, ++++ si media la note
                context.Teachers.Select(x => new
                {
                    Teacher = x.FirstName,
                    Comments = x.Comments.Count(),
                    AvgNote = x.Marks.Average(d=>d.Value)
                });

                var otherr = context.Universities.FromSql("SELECT * FROM Universities WHERE Age > 0")
                    .Select(x => new
                    {
                        x.Name
                    });


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
