using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenClosedPrincipale;

namespace LiskovSubstitutionPrincipale
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var driver = new Driver("Cristian ");
            IVehicle car = new Car();
            IVehicle truck = new Truck();

            driver.Drive(car);
            driver.Drive(truck);
           

            IVehicle V = new Truck();

            V.Drive();
            Console.ReadKey();
        }
    }
}
