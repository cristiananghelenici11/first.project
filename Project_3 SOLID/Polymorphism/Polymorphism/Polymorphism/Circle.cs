using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Circle : IShape
    {
        public void Drow()
        {
            Console.WriteLine("Deseneaza CErc");
        }

        public void Erase()
        {
            Console.WriteLine("Sterge CErc");
        }
    }
}
