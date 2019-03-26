using System;
using Relationships.Console;
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

namespace Relationships.Console
{
    public class Program
    {
        public static string connectionString = @"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=Relationships;Integrated Security=True";
        private static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                var university = new University()
                {
                    Address = "grgter",
                    Age = 45,
                    Contact = "35345",
                    Name = "utm"
                };
                var student = new Student()
                {
                    FirstName = "Cristian",
                    LastName = "Anghelenici",
                    Idnp = 1225278372,
                    Phone = 232433,
                    Email = "ere",
                    UniversityId = 1
                };
                var studentRepository = new Repository<Student>(db);
                //studentRepository.Create(student);
                var address = new Address()
                {
                    City = "sfgsd",
                    Street = "erwer",
                    ZipCode = "235",
                    StudentId = 2
                };
                var addressRepository = new Repository<Address>(db);
                //addressRepository.Create(address);

            }

            var client1 = new Thread(ChangeZipCode);
            //client1.Start();    
            
            var client2 = new Thread(ChangeZipCode);
            //client2.Start();

            Transaction();
            System.Console.WriteLine("....");
            System.Console.ReadKey();
        }

        private static void ChangeZipCode()
        {
            using (var applicationContext = new ApplicationContext())
            {
                Address address = applicationContext.Addresses.FirstOrDefault();
                address.ZipCode = "444";
                applicationContext.Update(address);
                applicationContext.SaveChanges();
            }
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
                    catch(Exception)
                    {

                    }
                }
            }

            // Using System.Transactions
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        var options = new DbContextOptionsBuilder<ApplicationContext>()
                            .UseSqlServer(connection)
                            .Options;

                        using (var context = new ApplicationContext())
                        {
                            context.Universities.Add(new University { Name = "hq", Age = 11});
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
                new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted}))
            {
                try
                {
                    using (var context = new ApplicationContext())
                    {
                        context.Database.OpenConnection();
                        context.Database.EnlistTransaction(transaction);

                        context.Universities.Add(new University {Name = "Enlistment", Age = 100});
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
    }
}
