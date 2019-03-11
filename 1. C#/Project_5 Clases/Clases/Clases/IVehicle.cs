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
        double PetrolLevel { get; set; }

        void Go();
        void Stop();
        void ChangeDirection();
        void TurnLeft();
        void TurnRight();
        void IncreaseSpeed();
        void DecreaseSpeed(int speed);
    }
}
