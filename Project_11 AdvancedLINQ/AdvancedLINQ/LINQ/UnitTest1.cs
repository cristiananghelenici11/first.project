using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace LINQ
{
    [TestClass]
    public class UnitTest1
    {
        private static List<Employee> _employees;
        private static readonly List<Computer> _computers = new List<Computer>();

        public UnitTest1()
        {
            var pc1 = new Computer { Brand = "Samsung", Ram = 16, Storage = 256 };
            var pc2 = new Computer { Brand = "Apple", Ram = 24, Storage = 512 };
            var pc3 = new Computer { Brand = "DELL", Ram = 8, Storage = 128 };
            var pc4 = new Computer { Brand = "Acer", Ram = 12, Storage = 512 };
            var pc5 = new Computer { Brand = "Asus", Ram = 32, Storage = 512 };
            var pc6 = new Computer { Brand = "HP", Ram = 4, Storage = 256 };
            _computers.AddRange(new List<Computer> { pc1, pc2, pc3, pc4, pc5, pc6});

            _employees = new List<Employee>
            {
                new Employee{Name = "Cristian", Id = 1234567891234, Salary = 850, Computer = pc1},
                new Employee{Name = "Catalin", Id = 1234536791234, Salary = 500, Computer = pc2},
                new Employee{Name = "Andrei", Id = 1232977891234, Salary = 1000, Computer = pc3},
                new Employee{Name = "Tom", Id = 1232977891234, Salary = 1000, Computer = pc2},
                new Employee{Name = "Oleg", Id = 1234567894234, Salary = 450, Computer = pc4},
                new Employee{Name = "Viorel", Id = 1234567877234, Salary = 1200, Computer = pc5},
                new Employee{Name = "Octavian", Id = 1384564891234, Salary = 600, Computer = pc4},
                new Employee{Name = "Tudor", Id = 1234564997134, Salary = 750, Computer = pc6},
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

        [TestMethod]
        public void Projection()
        {
            Console.WriteLine("---> Select <---");
            _employees.Select(x => x.Name).Display();

            Console.WriteLine("---> SelectMany <---");
            char[] person = _employees.SelectMany(x => x.Name).ToArray();
            foreach (char p in person)
            {
                Console.Write(p);
            }
        }

        [TestMethod]
        public void Joining()
        {
            Console.WriteLine("---> JOIN <---");
            _computers.Join(_employees,
                c => c.Brand,
                e => e.Computer.Brand,
                (c, e) => c.Brand).Display();

            Console.WriteLine("---> JOIN <---");
            IEnumerable<string> brands = from c in _computers
                join e in _employees
                    on c.Brand equals e.Computer.Brand
                select c.Brand;

            Console.WriteLine("-->GROUPJOIN<--");
            var computerBrands = _computers.GroupJoin(_employees,
                c => c.Brand,
                e => e.Computer.Brand,
                (computers, employees) => new {ComputerBrand = computers.Brand, Employees = employees});
            foreach (var c in computerBrands)
            {
                Console.WriteLine("--->" + c.ComputerBrand);
                c.Employees.Display();
            }

            Console.WriteLine("-->GROUPJOIN<--");
            var computerBrands2 = from c in _computers
                join e in _employees
                    on c.Brand equals e.Computer.Brand
                    into employes
                select new {GrouBrands = c.Brand, Employees = employes};
            foreach (var i in computerBrands2)
            {
                Console.WriteLine($"---------->{i.GrouBrands}");
                i.Employees.Display();
            }

            Console.WriteLine("-->ZIP<--");
            var zip = _employees.Zip(_computers,
                (employee, computer) => new {employee.Name, computer.Ram});

            foreach (var i in zip)
            {
                Console.WriteLine($"{i.Name} <->Memory Ram: {i.Ram}");
            }
        }

        [TestMethod]
        public void Ordering()
        {
            Console.WriteLine("-->ORDERBY & THENBY");
            _employees.OrderBy(e => e.Computer.Ram).
                ThenBy(e => e.Computer.Storage).Display();

            Console.WriteLine("-->ORDERBYDESCENDING & THENBYDESCENDING");
            _employees.OrderByDescending(e => e.Salary).
                ThenByDescending(e => e.Name).Display();

            Console.WriteLine("-->REVERSE<--");
            _employees.OrderByDescending(e => e.Salary).
                ThenByDescending(e => e.Name).Reverse().Display();
        }

        [TestMethod]
        public void Grouping()
        {
            Console.WriteLine("-->GROUPBY<--");
            IEnumerable<IGrouping<string, Employee>> EC1 = _employees.GroupBy(x => x.Computer.Brand, s => s);
            foreach (IGrouping<string, Employee> i in EC1)
            {
                Console.WriteLine(i.Key);
                foreach (Employee employee in i)
                {
                    Console.WriteLine(employee);
                }
            }

            Console.WriteLine("-->GROUPBY<--");
            var brands = from e in _employees
                group e by e.Computer.Brand
                into g
                select new {Brand = g.Key, Count = g.Count()};
            foreach (var b in brands)
            {
                Console.WriteLine($"{b.Brand}:, {b.Count}");
            }
        }

        [TestMethod]
        public void SetOperators()
        {
            IEnumerable<Computer> computers1 = _computers.Where(c => c.Ram > 16);
            IEnumerable<Computer> computers2 = _computers.Where(c => c.Ram > 24);

            Console.WriteLine("---> ce1 <---");
            computers1.Display();

            Console.WriteLine("---> ce2 <---");
            computers2.Display();

            Console.WriteLine("--> CONCAT <--");
            computers1.Concat(computers2).Display();

            //concatenarea fara duplicate
            Console.WriteLine("--> UNION <--");
            computers1.Union(computers2).Display();

            Console.WriteLine("--> Intersect <--");
            computers1.Intersect(computers2).Display();

            //Returns elements present in the first, but not the second sequence
            Console.WriteLine("--> EXCEPT <--");
            computers1.Except(computers2).Display();
        }

        [TestMethod]
        public void ConversionMethods()
        {
            IEnumerable<object> obj = new  object[] {1, 3.6f, 6.6, 5, "fc", 4, 8};

            Console.WriteLine("---> OFTYPE <---");
            obj.OfType<int>().Display();

            Console.WriteLine("--> CAST <--");
            try
            {
                obj.Cast<int>().Display();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("InvalidCastException");
            }

            Console.WriteLine("--> TOARRAY <--");
            object[] arr = obj.ToArray();
            arr.Display();

            Console.WriteLine("--> TOLIST <--");
            arr.ToList().Display();

            Console.WriteLine("--> TODICTIONARY <--");
            Dictionary<string, Computer> _computers2 = _computers.ToDictionary(c => c.Brand);
            foreach (KeyValuePair<string, Computer> c in _computers2)
            {
                Console.WriteLine($"Key: {c.Key}, Value: {c.Value}");
            }

            Console.WriteLine("--> TOLOOKUP <--");
            ILookup<string, Employee> _employees2 = _employees.ToLookup(e => e.Name);
            foreach (IGrouping<string, Employee> employee in _employees2)
            {
                Console.WriteLine($" Group: {employee.Key}");
                foreach (Employee e in employee)
                {
                    Console.WriteLine($"---> {e}");
                }
            }

            Console.WriteLine("--> ASENUMERABLE <--");
            IEnumerable<IGrouping<string, Employee>> _computers3 = _employees2.AsEnumerable();

            Console.WriteLine("--> ASQUERYABLE <--");
            IQueryable<IGrouping<string, Employee>> _computers4 = _employees2.AsQueryable();
        }

        [TestMethod]
        public void ElementOperators()
        {
            var _emptyList = new List<Computer>();

            Console.WriteLine("--> FIRST<--");
            Console.WriteLine(_computers.First());

            Console.WriteLine("--> FIRSTORDEFAULT <--");
            Console.WriteLine(_computers.FirstOrDefault());

            Console.WriteLine("--> LAST <--");
            Console.WriteLine(_computers.Last());

            Console.WriteLine("--> LASTORDEFAULT <--");
            Console.WriteLine(_computers.LastOrDefault());

            Console.WriteLine("-->SINGLE<--");
            Console.WriteLine(_computers.Single(x => x.Ram > 30));

            Console.WriteLine("--> SINGLEORDEFAULT <--");
            Console.WriteLine(_emptyList.SingleOrDefault());

            Console.WriteLine("--> ELEMENTAT <--");
            Console.WriteLine(_computers.ElementAt(3));

            Console.WriteLine("-->ELEMENTATORDEFAULT<--");
            Console.WriteLine(_emptyList.ElementAtOrDefault(100));

            Console.WriteLine("--> DEFAULTIFEMPTY <--");
            Console.WriteLine(_computers.DefaultIfEmpty().First());

            Console.WriteLine("--> DEFAULTIFEMPTY <--");
            Console.WriteLine(_emptyList.DefaultIfEmpty().First());
        }

        [TestMethod]
        public void AggregationMethods()
        {
            Console.WriteLine("--> COUNT <--");
            Console.WriteLine(_computers.Count);

            Console.WriteLine("--> LONGCOUNT <--");
            Console.WriteLine(_computers.LongCount());
            
            Console.WriteLine("--> MIN <--");
            Console.WriteLine(_computers.Min(x => x.Ram));

            Console.WriteLine("--> MAX <--");
            Console.WriteLine(_computers.Max(x => x.Ram));

            Console.WriteLine("--> SUM <--");
            Console.WriteLine(_computers.Sum(x => x.Storage));            
            
            Console.WriteLine("--> Average <--");
            Console.WriteLine(_computers.Average(x => x.Storage));    
            
            Console.WriteLine("--> AGGREGATE <--");
            Console.WriteLine(_computers.Select(x => x.Storage).Aggregate((seed, storage) => storage + seed));
        }

        [TestMethod]
        public void Quantifiers()
        {
            Console.WriteLine("--> CONTAINS <--");
            Console.WriteLine(_employees.Contains(new Employee{Name = "Tom", Id = 1232977891234, Salary = 1000}, new Comparer()));

            Console.WriteLine("--> ANY <--");
            Console.WriteLine(_computers.Any(x => x.Ram >30));

            Console.WriteLine("--> ALL <--");
            Console.WriteLine(_computers.All(x => x.Ram >5));

            Console.WriteLine("-->SEQUENCEEQUAL<--");
            Console.WriteLine(_computers.SequenceEqual(_computers));
        }

        [TestMethod]
        public void GenerationMethod()
        {
            Console.WriteLine("--> EMPTY <--");
            Enumerable.Empty<int>().Display();

            Console.WriteLine("--> REPEAT <--");
            Enumerable.Repeat(new Computer {Brand = "Other", Ram = 2, Storage = 64}, 4).Display();

            Console.WriteLine("--> RANGE <--");
            Enumerable.Range(1, 20).Display();
        }

        [TestMethod]
        public void Closure()
        {
            /// Adauga 4 gb ram la pc.ram < 12
            
            Func<Computer, Computer> computerAddRam = UpgradeRam();
            IEnumerable<Computer> computers2 = _computers.Where(x => x.Ram < 12);

            Console.WriteLine("---> Before Upgrade RAM <---");
            computers2.Display();

            Console.WriteLine("---> After Upgrade RAM <---");
            foreach (Computer computer in computers2)
            {
                computerAddRam(computer);
                Console.WriteLine(computer);
            }
        }
        
        private class Comparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee x, Employee y)
            {
                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(Employee obj)
            {
                throw new NotImplementedException();
            }
        }

        private static Func<Computer, Computer> UpgradeRam()
        {
            var ram = 0;
            Func<Computer, Computer> computerAddRam = delegate(Computer computer)
            {
                ram = ram + 4;
                computer.Ram += ram;
                return computer;
            };
            return computerAddRam;
        }
    }
}
