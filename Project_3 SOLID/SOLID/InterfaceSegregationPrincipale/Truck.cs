using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Truck : ITruckVehicle
=======
    class Truck : ITruckVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
    class Truck : ITruckVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public double LoadCapacity { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }

        public void Move()
        {
        }

        public void Stop()
        {
        }
    }
}
