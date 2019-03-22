using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DomainStudent;
using StudentFirstCore.Models;
using StudentFirstCore.Repositories;

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
            
            EFGenericRepository<Universities> universityRepo = new EFGenericRepository<Universities>(new StudentContext());
     
            IEnumerable<Universities> universities2 = universityRepo.GetWithInclude(u => u.Faculties);
            foreach (Universities university  in universities2)
            {    
                Console.WriteLine($"{university.Name} ({university.Description}) Faculties:");
                foreach (var f in university.Faculties)
                {
                    Console.WriteLine($"\t{f.Name}, {f.Description}, {f.Address}");
                }
            }

            Console.WriteLine("End Program");
            Console.ReadKey();
        }
    }
}
