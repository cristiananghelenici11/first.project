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

                

                //dami lista la toate telefoanele care persoanele au age>22
                //1
                IQueryable<Telephone> telephones = dbContext.Telephones.Where(x => x.Person.Age > 22);
                foreach (Telephone telephone in telephones)
                {
                    //Console.WriteLine($"{telephone.Mark}, {telephone.Number}");
                }

                //da toate telefoanele la care mark e samsung
                //2

                var telephones2 = dbContext.Telephones.Where(x => x.Mark == "Samsung");
                foreach (Telephone telephone in telephones2)
                {
                    //Console.WriteLine($"{telephone.Mark}, {telephone.Number}");
                }

                //da toate persoanele la care numele se incepe cu C
                //3
                var persons = dbContext.Persons.Where(x => x.Name.StartsWith("C"));
                foreach (Person person in persons)
                {
                    //Console.WriteLine($"{person.Id}, {person.Name}, {person.Age}");
                }

                // da toate telefoanele la care persoana e Cristian
                //4
                var persons2 = dbContext.Telephones.Where(x => x.Person.Name.Contains("Andrei"));
                foreach (Telephone telephone in persons2)
                {
                    //Console.WriteLine($"{telephone.Mark}, {telephone.Number}");
                }

                //da persoana la care tel e samsung 
                //5
                var persons3 = dbContext.Persons.Where(x => x.Telephones.Count() > 1);
                var test = dbContext.Telephones.Where(x => x.Person.Age == 2);
                var test2 = dbContext.Telephones.Where(x => x.Mark == "Samsung").Include(x => x.Person);
                foreach (var v in test2)
                {
                    //Console.WriteLine($"{v.Person.Name}, {v.Person.Age}");
                }

                //grupeaza toate telefoanele dupa utilizatori, ( si telefoanele sa sie samsung si utilizatoru cristi)

                var group = dbContext.Persons.GroupBy(x => x.Name).Select(x => new
                {
                    Name = x.Key,
                    Telephone = x.SelectMany(z=>z.Telephones).Where(m=>m.Mark=="Samsung")
                }).Where(x=>x.Name=="Cristian");

                foreach (var g in group)
                {
                    //Console.WriteLine($"{g.Name}");
                    foreach (var v in g.Telephone)
                    {
                        //Console.WriteLine($"\t{v.Mark}, {v.Number}");
                    }
                }

                //Console.WriteLine("0000000000000000000");
                //grupeaza toate tel dupa mark si afiseaza utilizatorii la aceasta marca
                var telephones3 = dbContext.Telephones.GroupBy(x => x.Mark).Select(x => new
                {
                    Mark = x.Key,
                    Person = x.Select(p=>p.Person)
                });

                foreach (var telephone in telephones3)
                {
                    //Console.WriteLine($"{telephone.Mark}");
                    foreach (var p in telephone.Person)
                    {
                        //Console.WriteLine($"\t{p.Name}");
                    }
                }

                // da fiecare utilizator si lista de elefoane
                var users = dbContext.Persons.Select(x => new
                {
                    User=x.Name,
                    CountTel = x.Telephones.Where(p => p.Mark=="Samsung").Count()
                });

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.User}, {user.CountTel}");
                }



                //-----valoare sa sie mai mare de cit valoarea la totote

//                var group = dbContext.Telephones.Select(x => new
//                {
//                    Name = x.,
//                    CountTelephone = x.
//                })


                //var persons3 = dbContext.Persons.Where(x=> x.Telephones)

            }





            Console.ReadKey();
        }
    }
}
