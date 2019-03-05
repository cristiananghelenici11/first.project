using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismParametric
{
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
=======
    class Program
    {
        static void Main(string[] args)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        {
            Display(32);
            Display("text");
            Display("text", 100);
            Display(100, "Text");
            Console.ReadKey();
        }

<<<<<<< HEAD
        private static void Display<T>(T value)
=======
        static void Display<T>(T value)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        {
            Console.WriteLine(value);
        }

<<<<<<< HEAD
        private static void Display<T, U>(T firstValue, U secondValue)
=======
        static void Display<T, U>(T firstValue, U secondValue)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        {
            Console.WriteLine($"{firstValue} {secondValue}");

        }
    }
}
