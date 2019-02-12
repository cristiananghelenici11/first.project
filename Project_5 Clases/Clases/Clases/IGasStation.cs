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
        IVehicle Vehicle { get; set; }

        void Refuel(IVehicle vehicle, int money);
        int GetMoney();

    }
}
