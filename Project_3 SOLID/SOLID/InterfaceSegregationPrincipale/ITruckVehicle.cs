using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
    public interface ITruckVehicle : IVehicle
    {
        double LoadCapacity { get; set; }
    }
}
