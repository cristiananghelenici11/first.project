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

            GasStation romPetrol = new GasStation("ROM PETROL", 1000);
            Driver cristian = new Driver("Cristian", 10, car);
            
            cristian.Drive(car);
            romPetrol.Refuel(car, 200);
            Console.WriteLine(romPetrol.GetMoney());


            Console.ReadKey();
        }
    }

}
