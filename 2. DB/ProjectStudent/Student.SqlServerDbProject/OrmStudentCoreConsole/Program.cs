using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StudentFirstCore.Models;
using StudentFirstCore.Repositories;
using DomainStudent;
using Microsoft.EntityFrameworkCore;
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
            foreach (StudentFirstCore.Models.Universities university  in universities29)
            {
                Console.WriteLine($"{university.Name} ({university.Description}) Faculties:");
                foreach (var f in university.Faculties)
                {
                    Console.WriteLine($"\t{f.Name}, {f.Description}, {f.Address}");
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////// by default val, cum pot la int sa adaugi nul
          
            
            Console.WriteLine("-----------------------------------------------");
            using (var context = new StudentContext())
            {
                //Grouping
                var universities = context
                    .Universities.Include(x => x.Faculties)
                    .GroupBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        AvgAge = x.Average(y => y.Age)                    });

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
                    .Where(x=> x.Count >= 1);
                foreach (var university in universities2)
                {
                    Console.WriteLine($"{university.Name}, {university.Count}");
                }

                //GROUPJOIN
                var topFaculties = context.Faculties
                    .GroupBy(x => x.Universtity.Name)
                    .Select(x => new
                    {
                        Name = x.Key,
                        CountFaculties = x.Count()
                    })
                    .OrderByDescending(x => x.Name);

            }

            Console.WriteLine("End Program");
            Console.ReadKey();
        }
    }
}
