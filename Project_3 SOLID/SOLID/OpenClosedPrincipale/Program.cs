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
            //upcast
            IVehicle car = new Car();
            IVehicle truck = new Truck();

            // down cast
            //((Car) car).OpenDoor();

            driver.Drive(car);
            driver.Drive(truck);
           
            Console.ReadKey();
        }
    }

    interface IExemple
    {
        void Drow();
    }

    abstract class Test : IExemple
    {
        public void Drow()
        {
            throw new NotImplementedException();
        }
    }
}
