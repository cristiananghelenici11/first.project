using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var car = new Car("BMW");

            car.Start();
            car.Stop();

            Console.ReadKey();
        }
    }
}
