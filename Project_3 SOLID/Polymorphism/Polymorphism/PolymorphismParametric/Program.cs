using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismParametric
{
    class Program
    {
        static void Main(string[] args)
        {
            Display(32);
            Display("text");
            Display("text", 100);
            Display(100, "Text");
            Console.ReadKey();
        }

        static void Display<T>(T value)
        {
            Console.WriteLine(value);
        }

        static void Display<T, U>(T firstValue, U secondValue)
        {
            Console.WriteLine($"{firstValue} {secondValue}");

        }
    }
}
