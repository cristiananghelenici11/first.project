using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                throw new Exception();
            }
            finally
            {
                Console.WriteLine("Exceptie");
            }

            Console.ReadKey();
        }
    }
}
