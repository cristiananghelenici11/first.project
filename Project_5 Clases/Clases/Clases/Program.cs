using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car()
            {
                Mark = "BMW",
                Model = "850i",
                Color = "Blue",
                DoorCount = 3,
                HorsePower = 430,
                Year = 2019
            };

            GasStation romPetrol = new GasStation("ROM PETROL");
            Driver cristian = new Driver("Cristian", 20, car);

            cristian.Drive();
            cristian.Drive(car);

            Console.WriteLine($"{car.Mark}, {car.Model} petrol volume = {car.PetrolLevel} litres");
            romPetrol.Refuel(car, 100);
            Console.WriteLine($"{car.Mark}, {car.Model} petrol volume = {car.PetrolLevel} litres");

            Console.WriteLine(cristian.Age);


            Console.ReadKey();
        }
    }
}
