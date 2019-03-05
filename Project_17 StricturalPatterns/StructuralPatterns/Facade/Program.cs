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
<<<<<<< HEAD
            var car = new Car("BMW", new Engine(), new Gearbox());
=======
            var car = new Car("BMW");
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            car.Start();
            car.Stop();

            Console.ReadKey();
        }
    }
}
