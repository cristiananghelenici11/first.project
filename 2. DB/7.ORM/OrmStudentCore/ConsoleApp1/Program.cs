using System;
using System.Linq;
using CodeFirst;
using DatabaseFirstCore.Models;
using Domain.Core;

namespace OrmStudentCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starts...");
//            var person = new Person
//            {
//                FirstName = "John",
//                LastName = "Doe"
//            };
//
//            var address = new Address
//            {
//                Person = person,
//                PostCode = "MD-123",
//                Street = "str1"
//            };
//
//            var dbContext = new StudentDbContext();
//            dbContext.Persons.Add(person);
//            dbContext.SaveChanges();
//            Console.WriteLine("Save Person");

            var dbContext2 = new StudentContext();

            var t = dbContext2.Universities.FirstOrDefault();
            Console.WriteLine($"{t.Address}, {t.Age}, {t.Contact}, {t.Name}");



            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
