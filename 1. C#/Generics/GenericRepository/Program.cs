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
            
            IGenericRepository<Phone> phones = new GenericRepository<Phone>(new List<Phone>
            {
                new Phone
                {
                    Company = new Company(),
                    CompanyId = 1,
                    Name = "HTC"
                }
            });


            phones.Get();

            Console.ReadKey();
        }
    }
}
