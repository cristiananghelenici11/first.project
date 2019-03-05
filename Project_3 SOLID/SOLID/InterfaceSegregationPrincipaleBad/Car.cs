using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
<<<<<<< HEAD
    public class Car : IVehicle
=======
    class Car : IVehicle
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public string Mark { get; set; }

        public string Model {  get; set;  }

        public double LoadCapacity {  get; set;  }

        public string TypeMotorcycle {  get; set;  }

        public string Transmision {  get; set;  }


        public void Move()
        {
            Console.WriteLine("Move Car");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Car");
        }
    }
}
