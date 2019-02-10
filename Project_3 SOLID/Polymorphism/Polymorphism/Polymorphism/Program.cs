using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    // universal inclusion
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle();
            IShape triangle = new Triangle();

            circle.Drow();
            circle.Erase();

            triangle.Drow();
            triangle.Erase();
            Console.ReadKey();
        }
    }
}
