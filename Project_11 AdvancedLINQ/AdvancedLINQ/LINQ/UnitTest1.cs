using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    [TestClass]
    public class UnitTest1
    {
        private static List<Employee> _employees;
        private static List<Computer> _computers = new List<Computer>();

        public UnitTest1()
        {
            var pc1 = new Computer { Brand = "Samsung", Ram = 16, Storage = 256 };
            var pc2 = new Computer { Brand = "Apple", Ram = 24, Storage = 512 };
            var pc3 = new Computer { Brand = "DELL", Ram = 8, Storage = 128 };
            var pc4 = new Computer { Brand = "Acer", Ram = 12, Storage = 512 };
            var pc5 = new Computer { Brand = "Asus", Ram = 32, Storage = 512 };
            var pc6 = new Computer { Brand = "HP", Ram = 4, Storage = 256 };
            var pc7 = new Computer { Brand = "DELL", Ram = 12, Storage = 320 };
            _computers.AddRange(new List<Computer> { pc1, pc2, pc3, pc4, pc5, pc6, pc7});

            _employees = new List<Employee>
            {
                new Employee(){Name = "Cristian", Id = 1234567891234, Salary = 850, Computer = pc1},
                new Employee(){Name = "Catalin", Id = 1234536791234, Salary = 500, Computer = pc2},
                new Employee(){Name = "Andrei", Id = 1232977891234, Salary = 1000, Computer = pc3},
                new Employee(){Name = "Tom", Id = 1232977891234, Salary = 1000, Computer = pc2},
                new Employee(){Name = "Oleg", Id = 1234567894234, Salary = 450, Computer = pc4},
                new Employee(){Name = "Viorel", Id = 1234567877234, Salary = 1200, Computer = pc5},
                new Employee(){Name = "Octavian", Id = 1384564891234, Salary = 600, Computer = pc7},
                new Employee(){Name = "Tudor", Id = 1234564997134, Salary = 750, Computer = pc6},
            };
        }

        [TestMethod]
        public void Filtering()
        {
            Console.WriteLine("---> Display Employee and their computer <---");
            _employees.Display();

            Console.WriteLine("---> WHERE <---");
            _computers.Where(x => x.Ram == 16).Display();

            Console.WriteLine("---> Take <---");
            _computers.Where(x => x.Storage == 512).Take(2).Display();

            Console.WriteLine("---> Skip <---");
            _computers.Where(x => x.Storage == 512).Skip(2).Display();

            Console.WriteLine("---> TAKEWHILE <---");
            _employees.TakeWhile(x => x.Salary > 500).Display();

            Console.WriteLine("---> SKIPWHILE <---");
            _employees.SkipWhile(x => x.Salary > 500).Display();

            Console.WriteLine("---> DISTINCT <---");
            _computers.Select(x => x.Storage).Distinct().Display();
        }




    }
}
