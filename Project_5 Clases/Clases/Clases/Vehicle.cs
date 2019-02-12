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

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void DecreaseSpeed(int speed)
        {
            throw new NotImplementedException();
        }

        public virtual void Go()
        {
            Console.WriteLine("Go witch acceleration 2 m/s");
        }

        public void IncreaseSpeed()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new NotImplementedException();
        }

        public void TurnRight()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()} Mark: {Mark}, Model: {Model}";
        }
    }
}
