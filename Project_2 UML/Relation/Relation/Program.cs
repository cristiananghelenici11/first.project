using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // incapsulation
            var ship = new Ship();
            ship.Move();

            var bmw = new Car();
            var driver1 = new Driver(bmw);
            bmw.Move();

            Console.ReadKey();
        }
    }
}
