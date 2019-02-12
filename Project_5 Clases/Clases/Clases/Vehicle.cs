using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Vehicle : IVehicle
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int DoorCount { get; set; }
        public int HorsePower { get; set; }
        public double PetrolLevel { get; set; }

        public virtual void ChangeDirection()
        {
            Console.WriteLine("Change Direction");
        }

        public virtual void DecreaseSpeed(int speed)
        {
            Console.WriteLine("Decrease Speed 2 m/s");
        }

        public virtual void Go()
        {
            Console.WriteLine("Go witch acceleration 2 m/s");
        }

        public virtual void IncreaseSpeed()
        {
            Console.WriteLine("Increase Speed 3 m/s");
        }

        public virtual void Stop()
        {
            Console.WriteLine("Stop vehicle");
        }

        public virtual void TurnLeft()
        {
            Console.WriteLine("Turn Left vehicle");
        }

        public virtual void TurnRight()
        {
            Console.WriteLine("Turn left vehicle");
        }

        public override string ToString()
        {
            return $"{base.ToString()} Mark: {Mark}, Model: {Model}";
        }
    }
}
