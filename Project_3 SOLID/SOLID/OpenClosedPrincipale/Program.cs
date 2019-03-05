using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenClosedPrincipale;

namespace LiskovSubstitutionPrincipale
{
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {
            var driver = new Driver("Cristian ");
            IVehicle car = new Car();
            IVehicle truck = new Truck();

=======
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

>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            driver.Drive(car);
            driver.Drive(truck);
           
            Console.ReadKey();
        }
    }
<<<<<<< HEAD
=======

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
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
}
