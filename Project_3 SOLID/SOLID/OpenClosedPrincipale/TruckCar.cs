using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class TruckCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Truck Car");
        }
    }
}
