using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var mathProxy = new MathProxy();

            Console.WriteLine($"4 + 10 = {mathProxy.Add(4, 10)}");
            Console.WriteLine($"7 - 2 = {mathProxy.Sub(7, 2)}");
            Console.WriteLine($"8 * 5 = {mathProxy.Mul(8, 5)}");
            Console.WriteLine($"10 / 5 = {mathProxy.Div(10, 5)}");
            Console.WriteLine($"Sqrt(100) = {mathProxy.Sqrt(100)}");
            Console.WriteLine($"Pow(10, 2) = {mathProxy.Pow(10, 2)}");

            Console.ReadKey();
        }
    }
}
