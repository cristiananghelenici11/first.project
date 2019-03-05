using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    // universal inclusion
<<<<<<< HEAD
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
=======
    class Program
    {
        static void Main(string[] args)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
    class Program
    {
        static void Main(string[] args)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
