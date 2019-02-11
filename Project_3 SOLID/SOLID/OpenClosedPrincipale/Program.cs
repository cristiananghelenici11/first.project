using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenClosedPrincipale;

namespace LiskovSubstitutionPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver("Cristian ");
            IVehicle car = new Car();
            IVehicle truck = new Truck();

            driver.Drive(car);
            driver.Drive(truck);

            Console.ReadKey();
        }
    }
}
