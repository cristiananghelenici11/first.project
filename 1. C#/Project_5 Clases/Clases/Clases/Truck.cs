using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Truck : Vehicle
    {
        public override void ChangeDirection()
        {
            Console.WriteLine("Change Direction Truck");
        }

        public override void DecreaseSpeed(int speed)
        {
            Console.WriteLine("Decrease Speed Truck");
        }

        public override void Go()
        {
            Console.WriteLine("Accelerate Truck witch 1 m/s");
        }

        public override void IncreaseSpeed()
        {
            Console.WriteLine("Increase Speed Truck");
        }

        public override void Stop()
        {
            Console.WriteLine("Stop Truck");
        }

        public override void TurnLeft()
        {
            Console.WriteLine("Turn Left Truck");
        }

        public override void TurnRight()
        {
            Console.WriteLine("Turn Right Truck");
        }
    }
}
