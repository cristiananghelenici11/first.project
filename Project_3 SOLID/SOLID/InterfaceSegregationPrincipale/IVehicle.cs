using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
    interface IVehicle
    {
        void Move();
        void Stop();
        string Mark { get; set; }
        string Model { get; set; }
    }
}
