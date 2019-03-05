using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    // universal inclusion
    public class Program
    {
        private static void Main(string[] args)
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
