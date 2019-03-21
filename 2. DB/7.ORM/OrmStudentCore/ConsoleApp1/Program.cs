using System;
using CodeFirst;
using Domain.Core;

namespace OrmStudentCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starts...");
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var address = new Address
            {
                Person = person,
                PostCode = "MD-123",
                Street = "str1"
            };

            var dbContext = new StudentDbContext();
            dbContext.Persons.Add(person);
            dbContext.SaveChanges();
            Console.WriteLine("Save Person");


            Console.WriteLine("Hello World!");
        }
    }
}
