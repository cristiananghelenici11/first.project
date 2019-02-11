using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("drive truck");
        }
    }
}
