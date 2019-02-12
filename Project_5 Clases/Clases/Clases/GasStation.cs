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
        public IVehicle Vehicle { get; set; }
        string TypeFuel { get; set; }
        int NumberOfPump { get; set; }

        public GasStation(string name, int startMoney)
        {
            Name = name;
            _money = startMoney;
        }

        public void Refuel(IVehicle vehicle, int money)
        {
            if (money > 0) _money += money;
            else
            {
                throw new Exception("No money, no fuel :)");
            }
            vehicle.ToString();
            Console.WriteLine($"Refuel vehicle witch {money} lei");
        }

        public void TakeMoney(int money)
        {
            if (money > 0) _money += money;
        }
    }
}
