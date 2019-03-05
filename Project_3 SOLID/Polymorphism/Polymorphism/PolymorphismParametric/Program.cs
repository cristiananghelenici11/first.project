using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismParametric
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Display(32);
            Display("text");
            Display("text", 100);
            Display(100, "Text");
            Console.ReadKey();
        }

        private static void Display<T>(T value)
        {
            Console.WriteLine(value);
        }

        private static void Display<T, U>(T firstValue, U secondValue)
        {
            Console.WriteLine($"{firstValue} {secondValue}");

        }
    }
}
