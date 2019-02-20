using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class GenericListExtension
    {
        public static void DisplayItems<T>(this IEnumerable<T> items)
        {
            Console.WriteLine("\n---> Display items Extension method <---");
            foreach (T item in items)
            {
                Console.WriteLine(item);

            }

        }
        public static void DisplayItems<T>(this IEnumerable<T> items, string delimitator)
        {
            Console.WriteLine("\n---> Display items Extension method <---");
            foreach (T item in items)
            {
                Console.WriteLine(item + delimitator);

            }

        }
    }
}
