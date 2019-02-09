using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class PassengerCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Passenger Car");
        }
    }
}
