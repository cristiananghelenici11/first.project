using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    static class Print
    {
        public static void Display<T>(this IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine();
        }
    }
}
