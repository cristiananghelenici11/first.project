using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class Driver
    {
        public string Name { get; set; }

        public Driver (string name)
        {
            Name = name;
        }

        public void DriveCar (ICar car)
        {
            Console.Write($"{Name} Drive ");
            car.Drive();
        }
    }
}
