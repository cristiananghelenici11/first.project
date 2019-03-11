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
            var computer7 = new Computer{Brand = "DELL", Ram = 12, Storage = 320};
            var _computers = new List<Computer>
            {
                computer1, computer2, computer3, computer4, computer5, computer6, computer7
            };

            var _employees = new List<Employee>
            {
                new Employee(){Name = "Cristian", Id = 1234567891234, Salary = 850, Computer = computer1},
                new Employee(){Name = "Catalin", Id = 1234536791234, Salary = 500, Computer = computer2},
                new Employee(){Name = "Andrei", Id = 1232977891234, Salary = 1000, Computer = computer3},
                new Employee(){Name = "Tom", Id = 1232977891234, Salary = 1000, Computer = computer2},
                new Employee(){Name = "Oleg", Id = 1234567894234, Salary = 450, Computer = computer4},
                new Employee(){Name = "Viorel", Id = 1234567877234, Salary = 1200, Computer = computer5},
                new Employee(){Name = "Octavian", Id = 1384564891234, Salary = 600, Computer = computer7},
                new Employee(){Name = "Tudor", Id = 1234564997134, Salary = 750, Computer = computer6},
            };

            Console.WriteLine("---> Display Employee and their computer <---");
            _employees.Display();

            Console.WriteLine("---> WHERE <---");
            _computers.Where(x => x.Ram == 16).Display();

            Console.WriteLine("---> Take <---");
            _computers.Where(x => x.Storage == 512).Take(2).Display();

            Console.WriteLine("---> Skip <---");
            _computers.Where(x => x.Storage == 512).Skip(2).Display();

            Console.WriteLine("---> TAKEWHILE <---");
            //_employee.TakeWhile(x => x.Salary > 500).Display();

            Console.WriteLine("---> SKIPWHILE <---");
            //_employee.SkipWhile(x => x.Salary > 500).Display();

            Console.WriteLine("---> DISTINCT <---");
            _computers.Select(x => x.Storage).Distinct().Display();

            ///////////////////////////////////////////////////////

            Console.WriteLine("---> Select <---");
            _computers.Where(x => x.Brand != "Samsung").Select(x => x.Brand).Display();

            Console.WriteLine("---> SELECTMANY <---");
            _employees.SelectMany(e => e.Name).ToArray();
            var select = from e in _employees
                         from c in e.Computer.Brand
                         where e.Salary > 800
                         where c.ToString() == "Asus"
                         select e;
            select.Display();

            Console.WriteLine("---> JOIN <---");
            _computers.Join(_employees,
                c => c.Brand,
                e => e.Computer.Brand,
                (g, c) => g.Brand).Display();
            Console.WriteLine("-----------");
            _computers.Select(x => x.Brand).Display();

            Console.WriteLine("-----------");
            // IEnumerable<String> r2 =
            (from c in _computers
                join e in _employees
                on c.Brand equals e.Computer.Brand
                select c.Brand).Display();

            Console.ReadLine();
        }
    }
}
