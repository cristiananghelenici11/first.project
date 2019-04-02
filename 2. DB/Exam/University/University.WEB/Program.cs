using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using University.DAL;
using University.DAL.Models;

namespace University.WEB
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new UniversityContext())
            {

                var s1 = new Student { FName = "Cristian", LName = "Anghelenici" };
                var s2 = new Student { FName = "Eliodor", LName = "Tralala" };
                var s3 = new Student { FName = "Ramil", LName = "Abdullaev" };

                var a1 = new Address { strada = "Studenilor", ZipCode = "retg", Student = s1 };
                var a2 = new Address { strada = "Moscova 2/1", ZipCode = "dsfg", Student = s2 };

                var c1 = new Course { Name = "OOP" };
                var c2 = new Course { Name = "AAC" };
                var c3 = new Course { Name = "SQL" };

                var sc11 = new StudentCourse { Course = c1, Student = s1, Mark = 9 };
                var sc12 = new StudentCourse { Course = c1, Student = s2, Mark = 8 };
                var sc13 = new StudentCourse { Course = c1, Student = s3, Mark = 10 };

                var sc21 = new StudentCourse { Course = c2, Student = s1, Mark = 6 };
                var sc22 = new StudentCourse { Course = c2, Student = s2, Mark = 9 };
                var sc23 = new StudentCourse { Course = c2, Student = s3, Mark = 8 };

                dbContext.AddRange(new List<StudentCourse> { sc11, sc12, sc13, sc21, sc22, sc23 });
                dbContext.AddRange(new List<Address> { a1, a2 });
                dbContext.AddRange(new List<Course> { c3 });
                //dbContext.SaveChanges();

            }

            using (var dbContext = new UniversityContext())
            {

                //1. Da toti studentii si adresele lor dar daca nu au adrese dai una orsicare;
                IEnumerable<Student> students1 = dbContext.Students.Include(x => x.Address);
                var students2 = students1.Select(x => new
                {
                    Name = x.FName + " " + x.LName,
                    Address = x.Address ?? new Address { strada = "re", ZipCode = "dsf", StudentId = x.Id }
                });
                foreach (var s in students2)
                {
                    Console.WriteLine($"{s.Name}, {s.Address.strada}, {s.Address.ZipCode}");
                }

                //2. select all course  name witch have students that live on "Studentilor"
                var s1 = dbContext.StudentCourses.Where(x => x.Student.Address.strada == "Studenilor").Select(x => x.Course.Name).ToList();

                var s11 = dbContext.StudentCourses
                    .Include(x => x.Course)
                    .Include(x => x.Student)
                        .ThenInclude(x => x.Address)
                    .Where(x => x.Student.Address.strada == "Studenilor")
                    .Select(x => x.Course.Name).ToList();

                //3. show all address of student that attend course "oop"
                var s32 = dbContext.StudentCourses.Where(x => x.Course.Name == "OOP").Select(x => x.Student.Address);

                //show student and avg of mark 
                var f38 = dbContext.Students
                    .Select(x => new
                    {
                        student = x,
                        AvgMark = x.StudentCourses.Average(y => y.Mark)
                    }).ToList();

                var f39 = dbContext.Students.GroupBy(x => x.LName).Select(x => new
                {
                    Student = x.Key,
                    AvgMark = x.Average(p => p.StudentCourses.Average(d => d.Mark))
                });

                //4. show student and avg of mark where mark > avg(Mark)
                var f40 = dbContext.Students.GroupBy(x => x.LName).Select(x => new
                {
                    Student = x.Key,
                    AvgMark = x.Average(p => p.StudentCourses.Average(d => d.Mark))
                }).Where(x => x.AvgMark > dbContext.StudentCourses.Average(p => p.Mark));

                //5. show all address of students that attend more than 2 courses
                var s22 = dbContext.Students
                    .Where(x => x.StudentCourses.Count() > 2).Select(x => x.Address).ToList();

                //6. show haow many courses each student attend 
                var v4 = dbContext.Students.Select(x => new
                {
                    Name = x.FName,
                    CountCourse = x.StudentCourses.Count()
                });

                //7. show all student that attend "sql" course
                var v55 = dbContext.StudentCourses.Where(x => x.Course.Name == "OOP").Select(x => x.Student).ToList();

                //show min mark for each student
                var v6 = dbContext.Students.Select(x => new
                {
                    Name = x.FName,
                    MinMark = x.StudentCourses.Min(p => p.Mark),
                    MaxMark = x.StudentCourses.Max(p => p.Mark)
                }).ToList();


                //8. show all students and list of marks
                var v7 = dbContext.Students.Select(x => new
                {
                    Student = x,
                    CoursesAndMark = x.StudentCourses.Select(y => new { Mark = y.Mark, Cours = y.Course.Name })
                });

                //9. select avg mark for all courses si chiar daca nari noti

                var f4r = dbContext.Courses.Select(x => new
                {
                    Course = x,
                    AvgMark = x.StudentCourses.Count() > 0 ? x.StudentCourses.Average(p => p.Mark) : 0
                }).ToList();

                //10. selecteaza toate numele la student  , curs , nota
                var tto = dbContext.StudentCourses.Select(x => new
                {
                    NameStudent = x.Student.FName,
                    Curs = x.Course.Name,
                    Mark = x.Mark
                }).Where(x => x.Mark > dbContext.StudentCourses.Average(p => p.Mark)).ToList();

                //11. toate adresele la fiecare student
                var hhh = dbContext.Students.Select(x => new
                {
                    Student = x,
                    Adresa = x.Address.strada
                });

                //12. grup join  dintre studentcurses si student
                var groupJoin = dbContext.StudentCourses.GroupJoin(dbContext.Students,
                    x => x.StudentId,
                    x => x.Id,
                    (sc, s) => new
                    {
                        hz = s.Select(m => m.LName),
                        Nume = sc.Mark
                    });


                //13. selecteaza toti studentii cu notele lui
                var groupJoin2 = dbContext.Students.GroupJoin(dbContext.StudentCourses,
                    x => x.Id,
                    x => x.StudentId,
                    (s, sc) => new
                    {
                        Name = s.FName,
                        Nume = sc.Select(p => p.Mark)
                    }).ToList();

                var groupJoin2Suquery = dbContext.Students.Select(x => new
                {
                    Name = x.FName,
                    Marks = x.StudentCourses.Select(p => p.Mark)
                });

                //14. toti studentii care nu au adresa 
                var bnn = dbContext.Students.Where(x => x.Address == null);

                //15. toti studentii care nu au adresa si dai adresa 
                var bnn2 = dbContext.Students.Where(x => x.Address == null).Select(x => new
                {
                    Studen = x,
                    Address = new Address { strada = "cei mai buna ", ZipCode = "fartovii" }
                });

                //16. afisiaza toti studentii media la note ordonate descresc dupa nota si (si cu cit e mai mica decit nota precedenta)
                var studentDto = dbContext.Students.Select(x => new StudentDto
                {
                    Name = x.FName,
                    AvgMark = x.StudentCourses.Average(p => p.Mark),
                }).OrderByDescending(x => x.AvgMark).ToList();

                for (int i = 1; i < studentDto.Count; i++)
                { studentDto[i].Diferenta = studentDto[i].AvgMark - studentDto[i - 1].AvgMark; }

                //17. notele la studenc la care numele se incepe cu "C"
                var students = dbContext.Students.Where(x => x.FName.StartsWith("C")).Select(x => new
                {
                    Student = x,
                    Mark = x.StudentCourses.Select(p => p.Mark)
                });

                foreach (var s in studentDto)
                {
                    Console.WriteLine($"Name: {s.Name}, AvgMark: {s.AvgMark}, Diferenta: {s.Diferenta}");
                }




                //toate datele pentru pentru id =1

            }



            Console.ReadKey();
        }

        class StudentDto
        {
            public string Name { get; set; }
            public double AvgMark { get; set; }
            public double Diferenta { get; set; }
        }
    }
}
