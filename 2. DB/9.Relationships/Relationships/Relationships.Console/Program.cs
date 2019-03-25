using System.Threading;
using System.Threading.Tasks;
using Relationships.DAL.Context;
using Relationships.DAL.Models;
using Relationships.DAL.Repositories;

namespace Relationships.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
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

            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var repositories = new Repository<Address>(applicationContext);
                Address address1 = repositories.FindById(1);
                Address address2 = repositories.FindById(1);

                address1.ZipCode = "111";
                address2.ZipCode = "2422";


                applicationContext.Update(address1);
                applicationContext.SaveChanges();

                applicationContext.Update(address2);
                applicationContext.SaveChanges();

            }

            System.Console.ReadKey();
        }
    }
}
