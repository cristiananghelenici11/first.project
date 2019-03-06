using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
    public interface IVehicle
    {

        string Mark { get; set; }

        string Model { get; set; }

        double LoadCapacity { get; set; }

        string TypeMotorcycle { get; set; }

        string Transmision { get; set; }

        void Move();

        void Stop();

    
    }
}
