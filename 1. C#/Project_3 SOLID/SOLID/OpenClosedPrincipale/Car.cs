using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("drive car");
        }

        public void OpenDoor()
        {
            Console.WriteLine("Open door");
        }
    }
}
