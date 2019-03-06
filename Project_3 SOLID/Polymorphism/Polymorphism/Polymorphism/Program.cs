using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IShape circle = new Circle();
            IShape triangle = new Triangle();

            circle.Draw();
            circle.Erase();

            triangle.Draw();
            triangle.Erase();
            Console.ReadKey();
        }
    }
}
