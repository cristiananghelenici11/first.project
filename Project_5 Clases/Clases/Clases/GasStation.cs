using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases 
{
    class GasStation : IGasStation
    {
        public string Name { get; set; }
        private int _money; 
        public string TypeFuel { get; set; }
        public int NumberOfPump { get; set; }

        public GasStation(string name)
        {
            Name = name;
        }

        public void Refuel(IVehicle vehicle)
        {
            vehicle.ToString();
            Console.WriteLine($"Refuel vehicle witch");
        }
    }
}
