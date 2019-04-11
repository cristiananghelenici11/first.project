using System;
using Relationships;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Relationships.DAL.Context;
using Relationships.DAL.Models;
using Relationships.DAL.Repositories;

namespace Relationships
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
//                var university = new University()
//                {
//                    Address = "grgter",
//                    Age = 45,
//                    Contact = "35345",
//                    Name = "utm"
//                };
//                var student = new Student()
//                {
//                    FirstName = "Cristian",
//                    LastName = "Anghelenici",
//                    Idnp = 1225278372,
//                    Phone = 232433,
//                    Email = "ere",
//                    UniversityId = 1
//                };
//                var studentRepository = new Repository<Student>(db);
//
//                //Console.WriteLine(db.Entry(new University()).State);
//                //studentRepository.Create(student);
//                var address = new Address()
//                {
//                    City = "sfgsd",
//                    Street = "erwer",
//                    ZipCode = "235",
//                    StudentId = 2
//                };
//                var addressRepository = new Repository<Address>(db);
//                //addressRepository.Create(address);
//

                db.Add(new MarkTeacher()
                {
                    Teacher = new Teacher(){FirstName = "Anghelenici", LastName = "Cristian"},
                    Value = 8
                });
                db.SaveChanges();


            }
//
//            var client1 = new Thread(ChangeZipCode);
//            client1.Start();
//
//            var client2 = new Thread(ChangeZipCode);
//            client2.Start();
//
//            var dbContext = new ApplicationContext();

//            //Polymorphic query 
//            var query = dbContext.Marks.ToList();
//
//            //Non-polymorphic query 
//            var query2 = dbContext.Marks.OfType<MarkCourse>().ToList();

            //var teacher = new Teacher(){FirstName = "Anghelenici", LastName = "Cristian"};

            //dbContext.SaveChanges();
//            dbContext.MarkCourses.Add(new MarkCourse { CourseId = 1, Value = 10 });
//            var s = dbContext.Marks.OfType<MarkCourse>().ToList();
//            foreach (MarkCourse markCourse in s)
//            {
//                Console.WriteLine($"{markCourse.Id}, {markCourse.Value}");
//            }

            //Selecting();
            Console.WriteLine("....");
            Console.ReadKey();
        }

        private static void ChangeZipCode()
        {
            var applicationContext = new ApplicationContext();
            Address address = applicationContext.Addresses.FirstOrDefault();

            if (address != null)
            {
                address.ZipCode = "444";
                applicationContext.Update(address);
            }

            applicationContext.SaveChanges();
        }

        private static void Transaction()
        {
            //Share connection and transaction
            using (var context = new ApplicationContext())
            {
                using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Universities.Add(new University()
                        {
                            Name = "utm",
                            Age = 25,
                            Contact = "43543",
                            Description = "tttt"
                        });
                        context.SaveChanges();

                        using (var context2 = new ApplicationContext())
                        {
                            context2.Database.UseTransaction(dbContextTransaction.GetDbTransaction());
                            List<University> universities = context2.Universities
                                .OrderBy(x => x.Age)
                                .ToList();
                            foreach (University university in universities)
                            {
                                System.Console.WriteLine($"{university.Id}, {university.Name}");
                            }
                        }

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            // Using System.Transactions
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                string connectionString = @"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=Relationships;Integrated Security=True";
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        var options = new DbContextOptionsBuilder<ApplicationContext>()
                            .UseSqlServer(connection)
                            .Options;

                        using (var context = new ApplicationContext())
                        {
                            context.Universities.Add(new University { Name = "hq", Age = 11 });
                            context.SaveChanges();
                        }
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e);
                        throw;
                    }
                }
            }
            //It is also possible to enlist in an explicit transaction.

            using (var transaction = new CommittableTransaction(
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    using (var context = new ApplicationContext())
                    {
                        context.Database.OpenConnection();
                        context.Database.EnlistTransaction(transaction);

                        context.Universities.Add(new University { Name = "Enlistment", Age = 100 });
                        context.SaveChanges();
                        context.Database.CloseConnection();
                    }
                    transaction.Commit();
                }
                catch
                {

                }
            }

        }

        private static void Loading()
        {
            using (var context = new ApplicationContext())
            {
                //Eager loading
                Console.WriteLine("---> Eager loading <---");
                var universities = context.Universities.Include(x => x.Students).ThenInclude(x => x.Address);
                foreach (var university in universities)
                {
                    Console.WriteLine($"{university.Name}");
                    foreach (var student in university.Students)
                    {
                        Console.WriteLine($"\t{student?.FirstName}, {student?.LastName}, {student?.Idnp},Address---: {student?.Address?.State}");
                    }
                }

                //Lazy loading
                Console.WriteLine("---> Lazy loading <---");
                var universities2 = context.Universities.ToList();
                foreach (var university in universities2)
                {
                    Console.WriteLine($"{university.Name}");
                    foreach (var student in university.Students)
                    {
                        Console.WriteLine($"\t{student?.FirstName}, {student?.LastName}, {student?.Idnp},Address---: {student?.Address?.State}");
                    }
                }

                //Explicit loading
                Console.WriteLine("---> Explicit loading <---");
                var teachers = context.Teachers
                    .FirstOrDefault();

                context.Entry(teachers)
                    .Collection(t => t.MarkTeachers)
                    .Load();
                foreach (var t in teachers.MarkTeachers)
                {
                    Console.WriteLine($"Nota: {t.Value}");
                }
            }
        }

        private static void Selecting()
        {
            using (var db = new ApplicationContext())
            {
                //db.Students.Add(new Student {FirstName = "Anghelenici", LastName = "Cristian", UniversityId = 1});
                //db.SaveChanges();
                //Find
                Student student = db.Students.Find((long)7);
                Console.WriteLine($"{student.FirstName}, {student.LastName}");

                University s1 = (from s in db.Universities
                                 where s.Name == "UTM"
                                 select s).FirstOrDefault();

                University s12 = db.Universities.FirstOrDefault(x => x.Name == "UTM");

                //Ordering
                IEnumerable<University> s2 = from s in db.Universities
                                             orderby s.Name ascending
                                             select s;

                IEnumerable<University> s21 = db.Universities.OrderBy(s => s.Name);
                foreach (University university in s21)
                {
                    Console.WriteLine($"{university.Name}");
                }

                //Anonymous object result
                var s3 = from s in db.Universities
                         where s.Name == "UTM"
                         select new
                         {
                             Id = s.Id,
                             Name = s.Name
                         };

                var s31 = db.Universities.Where(x => x.Name == "UTM").Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                });

                //JOIN
                //JOIN Types - INNER JOIN
                IQueryable<University> outer = db.Universities;
                IQueryable<Teacher> inner = db.Teachers;

                var categorySubcategories = outer.Join(inner, 
                    category => category.Id,
                    subcategory => subcategory.Id,
                    (category, subcategory) =>
                        new { Category = category.Name, Subcategory = subcategory.FirstName });
                foreach (var subcategory in categorySubcategories)
                {
                    Console.WriteLine($"{subcategory.Category}, {subcategory.Subcategory}");
                }

                //INNER JOIN
                var v1 = from x in db.Universities
                    join Teacher in db.Teachers on x.Id equals Teacher.Id
                    select new { Category = x.Name, Subcategory = Teacher.Email };

                //

            }

        }
    }
}
