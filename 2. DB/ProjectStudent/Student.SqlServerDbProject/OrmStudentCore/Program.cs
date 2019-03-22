using System;
using System.Linq;
using CodeFirst;
using DomainStudent.Core;

namespace OrmStudentCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var dbContext2 = new StudentDbContext();
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
            dbContext.Address.Add(address);
            dbContext.SaveChanges();
            Console.WriteLine("Save Person");
            using (var db = new StudentDbContext())
            {
                var persons = db.Persons.ToList();
                foreach (var p in persons)
                {
                    Console.WriteLine($"{p.Id}, {p.FirstName}, {p.LastName}");
                }
            }

            Console.WriteLine("END PROJECT!");
            Console.ReadKey();
        }
    }
}
