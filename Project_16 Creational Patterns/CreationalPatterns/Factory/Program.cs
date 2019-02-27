using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var maternityHome = new MaternityHome();

            Console.WriteLine("-----> Generate New Person <-----");
            Print(maternityHome.GenerateNewPerson(5));

            Console.WriteLine("\n-----> Generate Child Person <-----");
            Print(maternityHome.GenerateChildPerson(5));

            Console.WriteLine("\n-----> Generate Big Person <-----");
            Print(maternityHome.GenerateBigPerson(5));

            Console.ReadKey();
        }

        private static void Print<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

}
