using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
        public static float GetMedium(float[] numbers)
        {
            if (numbers.Length == 0)
                throw new Exception("длина массива равна нулю");

            float result = numbers.Sum() / numbers.Length;

            if (result < 0)
                throw new Exception("Результат меньше нуля");
            return result;
        }
    }
    
}
