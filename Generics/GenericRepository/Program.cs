using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class Program
    {
        private static void Main(string[] args)
        {
            EFGenericRepository<Phone> phoneRepo = new EFGenericRepository<Phone>(new ApplicationContext());

            phoneRepo.Create(new Phone{Company = new Company(), Name = "iPhone"});
            phoneRepo.Create(new Phone{Company = new Company(), Name = "iPhone"});
            phoneRepo.Create(new Phone{Company = new Company(), Name = "iPhone"});
            
//            IGenericRepository<Phone> phones1 = new EFGenericRepository<Phone>(new ApplicationContext())
//            {
//                
//            };

            //IEnumerable<Phone> phones = phoneRepo.GetWithInclude(p=>p.Company);

            IEnumerable<Phone> phones = phoneRepo.GetWithInclude(x=>x.Company.Name.StartsWith("S"), p=>p.Company);
            foreach (Phone p in phones)
            {    
                Console.WriteLine($"{p.Name} ({p.Company.Name}) - {p.Price}");
            }

            Console.ReadKey();
        }
    }
}
