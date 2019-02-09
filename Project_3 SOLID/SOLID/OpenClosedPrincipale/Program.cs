using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car1 = new PassengerCar();
            ICar car2 = new TruckCar();
            Driver driver1 = new Driver("Andrei");
            driver1.DriveCar(car1);
            driver1.DriveCar(car2);

            Console.ReadKey();
        }
    }
}
