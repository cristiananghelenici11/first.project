using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    interface IGasStation
    {
        string Name { get; set; }
        void Refuel(IVehicle vehicle, double money);
    }
}
