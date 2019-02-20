using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var computer1 = new Computer{Brand = "Samsung", Ram = 16, Storage = 256};
            var computer2 = new Computer{Brand = "Apple", Ram = 24, Storage = 512};
            var computer3 = new Computer{Brand = "DELL", Ram = 8, Storage = 128};
            var computer4 = new Computer{Brand = "Acer", Ram = 12, Storage = 512};
            var computer5 = new Computer{Brand = "Asus", Ram = 32, Storage = 512};
            var computer6 = new Computer{Brand = "HP", Ram = 4, Storage = 256};
            var computer7 = new Computer{Brand = "Dell", Ram = 12, Storage = 320};

            var _employee = new List<Employee>
            {
                new Employee(){Name = "Cristian", Id = 1234567891234, Salary = 850, Computer = computer1},
                new Employee(){Name = "Catalin", Id = 1234536791234, Salary = 850, Computer = computer2},
                new Employee(){Name = "Andrei", Id = 1232977891234, Salary = 850, Computer = computer3},
                new Employee(){Name = "Oleg", Id = 1234567894234, Salary = 850, Computer = computer4},
                new Employee(){Name = "Viorel", Id = 1234567877234, Salary = 850, Computer = computer5},
                new Employee(){Name = "Octavian", Id = 1384564891234, Salary = 850, Computer = computer7},
                new Employee(){Name = "Tudor", Id = 1234564997134, Salary = 850, Computer = computer6},
            };
            Console.ReadLine();
        }
    }
}
