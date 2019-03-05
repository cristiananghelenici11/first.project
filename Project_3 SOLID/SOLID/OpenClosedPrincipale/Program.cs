using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenClosedPrincipale;

namespace LiskovSubstitutionPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {
            var driver = new Driver("Cristian ");
            IVehicle car = new Car();
            IVehicle truck = new Truck();

=======
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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

<<<<<<< HEAD
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            driver.Drive(car);
            driver.Drive(truck);
           
            Console.ReadKey();
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

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
<<<<<<< HEAD
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
}
