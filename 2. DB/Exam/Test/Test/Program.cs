using System;
using System.Collections.Generic;
using System.Linq;
using DataAcces;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new ApplicationContext())
            {
                var t1 = new Telephone() { Mark = "Samsung", Number = 078996456 };
                var t2 = new Telephone() { Mark = "Apple", Number = 072856456 };
                var t3 = new Telephone() { Mark = "HTC", Number = 078926456 };
                var t4 = new Telephone() { Mark = "Apple", Number = 078296456 };
                var t5 = new Telephone() { Mark = "Huawei", Number = 002626456 };
                var t6 = new Telephone() { Mark = "Nokia", Number = 078296856 };

                var p1 = new Person() { Name = "Cristian", Age = 22, Telephones = new List<Telephone>() { t1, t2, t3 } };
                var p2 = new Person() { Name = "Andrei", Age = 23, Telephones = new List<Telephone>() { t4, t5, t6 } };

                dbContext.AddRange(new List<Person>() { p1, p2 });
                //dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationContext())
            {

                var vv1 = dbContext.Persons.Include(x => x.Telephones).ToList();
                var xx2 = dbContext.Persons.SelectMany(x => x.Telephones).ToList();
                var vv3 = dbContext.Persons.Select(x => x.Telephones).ToList();

                

                //1. dami lista la toate telefoanele care persoanele au age>22
                IQueryable<Telephone> telephones = dbContext.Telephones.Where(x => x.Person.Age > 22);

                //2. da toate telefoanele la care mark e samsung
                var telephones2 = dbContext.Telephones.Where(x => x.Mark == "Samsung");
                foreach (Telephone telephone in telephones2)
                {
                    //Console.WriteLine($"{telephone.Mark}, {telephone.Number}");
                }

                //3. da toate persoanele la care numele se incepe cu C
                var persons = dbContext.Persons.Where(x => x.Name.StartsWith("C"));

                //4. da toate telefoanele la care persoana e Cristian
                var persons2 = dbContext.Telephones.Where(x => x.Person.Name.Contains("Andrei"));

                //5. da persoana la care tel e samsung 
                var persons3 = dbContext.Persons.Where(x => x.Telephones.Count() > 1);
                var test = dbContext.Telephones.Where(x => x.Person.Age == 2);
                dbContext.Persons.Select(x => x.Telephones.Select(v => v.Mark == "Samsung"));

                //6. grupeaza toate telefoanele dupa utilizatori, ( si telefoanele sa sie samsung si utilizatoru cristi)+++++++
                var group = dbContext.Persons.GroupBy(x => x.Name).Select(x => new
                {
                    Name = x.Key,
                    hh = x.SelectMany(c=> c.Telephones).Where(d=> d.Person.Name == "e"),
                    Telephone = x.SelectMany(z=>z.Telephones).Where(m=>m.Mark=="Samsung"),
                }).Where(x=>x.Name=="Cristian");

                //7. grupeaza toate tel dupa mark si afiseaza utilizatorii la aceasta marca
                var telephones3 = dbContext.Telephones.GroupBy(x => x.Mark).Select(x => new
                {
                    Mark = x.Key,
                    Person = x.Select(p=>p.Person)
                });

                //8. da fiecare utilizator si lista de elefoane
                var users = dbContext.Persons.Select(x => new
                {
                    User=x.Name,
                    CountTel = x.Telephones.Count(p => p.Mark=="Samsung")
                });
            }

            Console.ReadKey();
        }
    }
}
