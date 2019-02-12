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
        private const double _pricePerLitre = 19.5; 
        public string TypeFuel { get; set; }
        public int NumberOfPump { get; set; }

        public GasStation(string name)
        {
            Name = name;
        }

        public void Refuel(IVehicle vehicle, double money)
        {
            vehicle.PetrolLevel = money / _pricePerLitre;
            vehicle.ToString();
            Console.WriteLine($"Refuel vehicle witch {vehicle.PetrolLevel} litres");
        }
    }
}
