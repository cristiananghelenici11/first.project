using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
    public interface IMotorcycleVehicle : IVehicle
    {
        string TypeMotorcycle { get; set; }
    }
}
