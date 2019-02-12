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

        private int _money = 0; 
        private int _bonus = 0; 
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
            TakeMoney(money);
            vehicle.ToString();
            Console.WriteLine($"Refuel vehicle witch {money} lei");
        }
        public void Refuel(IVehicle vehicle, int money, int bonus)
        {
            TakeMoney(money);
            TakeBonus(bonus);
            vehicle.ToString();
            Console.WriteLine($"Refuel vehicle witch {money} lei");
        }

        private void TakeMoney(int money)
        {
            if (money > 0) _money += money;
            else
            {
                throw new Exception("No money, no fuel :)");
            }
        }
        private void TakeBonus(int bonus)
        {
            if (bonus > 0) _bonus += bonus;
        }

        public int GetMoney()
        {
            return _money;
        }
    }
}
