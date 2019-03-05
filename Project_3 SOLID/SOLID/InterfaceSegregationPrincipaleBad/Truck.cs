using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Truck : IVehicle
=======
    class Truck : IVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
    class Truck : IVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public string Mark { get; set; }

        public string Model { get; set; }

        public double LoadCapacity { get; set; }

        public string TypeMotorcycle { get; set; }

        public string Transmision { get; set; }


        public void Move()
        {
            Console.WriteLine("Move Truk");      
        }

        public void Stop()
        {
        Console.WriteLine("Stop Truck");    
        }
    }
}
