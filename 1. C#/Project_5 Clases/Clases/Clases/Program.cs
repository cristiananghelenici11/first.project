using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Clases
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Vehicle car = new Car
            {
                Mark = "BMW",
                Model = "850i",
                Color = "Blue",
                DoorCount = 3,
                HorsePower = 430,
                Year = 2019
            };

            var romPetrol = new GasStation("ROM PETROL");
            var driver1 = new Driver("Cristian", 20, car);

            driver1.Drive();
            driver1.Drive(car);

            Console.WriteLine($"{car.Mark}, {car.Model} petrol volume = {car.PetrolLevel} litres");
            romPetrol.Refuel(car, 100);
            Console.WriteLine($"{car.Mark}, {car.Model} petrol volume = {car.PetrolLevel} litres");

            car.TurnLeft();

            Console.ReadKey();


            var test = new MyClass1();
        }
    }
}
