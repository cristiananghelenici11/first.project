using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
<<<<<<< HEAD
    public interface IVehicle
=======
    interface IVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
