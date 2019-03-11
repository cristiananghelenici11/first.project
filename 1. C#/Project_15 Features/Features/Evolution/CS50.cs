using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS50
    {
        [TestMethod]
        public void AsynchronousMethod()
        {
            Console.WriteLine("Start");
            Calculate();
            Console.WriteLine("Stop");
        }

        private static async void Calculate()
        {
            Console.WriteLine("Start Factorial");
            int n = await FactorialAsync(3);
            Console.WriteLine(n);
            Console.WriteLine("Stop Factorial");
        }

        private static int Factorial(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private static async Task<int> FactorialAsync(int n)
        {
            return await Task.Run(()=>Factorial(n));
        }

    }
}
