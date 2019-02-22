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
        private int _age;
        private IVehicle _personalVehicle;

        public int Age
        {
            get => _age;
            set
            {
                if (value > 18) _age = value; 
            }
        }

        public Driver(string name, int age, IVehicle personalVehicle)
        {
            if(age >= 18) Age = age;
            Name = name;
            _personalVehicle = personalVehicle;
        }

        public void Drive(IVehicle vehicle)
        {
            Console.WriteLine("Start drive");
            Console.WriteLine(vehicle);
            vehicle.Go();
        }  
        
        public void Drive()
        {
            Console.WriteLine("Start drive");
            Console.WriteLine(_personalVehicle);
            _personalVehicle.Go();
        }
    }
}
