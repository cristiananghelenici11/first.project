using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Triangle : IShape
    {
        public void Drow()
        {
            Console.WriteLine("Deseneaza Triunghi");
        }

        public void Erase()
        {
            Console.WriteLine("Sterge Triunghi");
        }
    }
}
