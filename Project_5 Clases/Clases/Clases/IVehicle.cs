using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    interface IVehicle
    {
        string Mark { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        string Color { get; set; }
        int DoorCount { get; set; }
        int HorsePower { get; set; }

        void Go();
        void Stop();
        void ChangeDirection();
        void TurnLeft();
        void TurnRight();
        void IncreaseSpeed();
        void DecreaseSpeed(int speed);
    }
}
