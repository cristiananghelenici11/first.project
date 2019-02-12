using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Driver
    {
        public string Name { get; set; }

        public int Age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value > 18) Age = value; 
            }
        }

        private Vehicle _vehicle;

        public Driver(string name, int age, Vehicle vehicle)
        {
            Age = age;
            Name = name;
            _vehicle = vehicle;
        }

        public void Drive(IVehicle vehicle)
        {
            Console.WriteLine("Start drive");
            Console.WriteLine(vehicle);
            vehicle.Go();
        }
    }
}
