﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
    interface IVehicle
    {

        string Mark { get; set; }

        string Model { get; set; }

        double LoadCapacity { get; set; }

        string TypeMotocycle { get; set; }

        string Transmision { get; set; }

        void Move();

        void Stop();

    
    }
}
