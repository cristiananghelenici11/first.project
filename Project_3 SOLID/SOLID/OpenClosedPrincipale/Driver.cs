﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Driver
=======
    class Driver
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
    class Driver
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public string Name { get; set; }

        public Driver(string name)
        {
            Name = name;
        }

        public void Drive(IVehicle vehicle)
        {
            Console.Write(Name);
            vehicle.Drive();
        }
    }
}
