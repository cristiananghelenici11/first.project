using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Car : Vehicle
    {
        public override void Go()
        {
            Console.WriteLine("Accelerate Car witch 10 m/s");
        }
    }
}
