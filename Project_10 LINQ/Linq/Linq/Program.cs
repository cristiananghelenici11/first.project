using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
     
    public class Program
    {
        private delegate bool DisplayCondition(Computer computer);
        public static void Main(string[] args)
        {
            var computers = new GenericList<Computer>
            {
                new Computer { Brand = "Apple", Model = "2018      ", Price = 2400, Ram = 16, Storage = 512},
                new Computer{ Brand = "ASUS", Model = "Zenbook   ", Price = 1800, Ram = 24, Storage = 256},
                new Computer {Brand = "ASUS", Model = "Zenbook   ", Price = 2000, Ram = 32, Storage = 256},
                new Computer{Brand = "DEL", Model = "XPS       ", Price = 2100, Ram = 24, Storage = 256},
                new Computer{Brand = "HP", Model = "Chromebook", Price = 1900, Ram = 16, Storage = 256}
            };

            // using Delegate
            DisplayComputer(computers, ComputerRamCapability);
            Console.WriteLine("------------------------");
            DisplayComputer(computers, ComputerStorageCapability);

            // using Extension method
            computers.DisplayItems();

            //using anonymous functions
            AnonymousFunctions(computers);

            //lambda expressions
            Console.WriteLine("\n---> lambda expressions (price>2300 )<---");
            DisplayComputer(computers, c => c.Price>2300);

            // Select and Where
            IEnumerable<string> brands = computers.Where(x => x.Ram > 24).Select(x => x.Model);
            foreach (string s in brands)
            {
                Console.WriteLine("Brands where ram > 24 is: " + s + " ");
            }

            Console.ReadKey();
        }

        private static void AnonymousFunctions(IEnumerable<Computer> computers)
        {
            Console.WriteLine("\n---> anonymous functions <---");
            DisplayComputer(computers, delegate
            {
                return true;
            });
            Console.WriteLine("\n---> anonymous functions (Price<1900) <---");
            DisplayComputer(computers, delegate(Computer computer)
            {
                return computer.Price < 1900; 

            });
        }

        private static bool ComputerRamCapability(Computer computer)
        {
            return computer.Ram >= 20;

        }        
        private static bool ComputerStorageCapability(Computer computer)
        {
            return computer.Storage > 256;

        }

        private static void DisplayComputer(IEnumerable<Computer> computers, DisplayCondition condition)
        {
            foreach (Computer computer in computers)
            {
                if(condition(computer)) Console.WriteLine(computer);

            }
        }
    }
}
