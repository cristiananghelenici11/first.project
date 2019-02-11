using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
    class Car : IVehicle
    {
        public string Mark { get; set; }

        public string Model {  get; set;  }

        public double LoadCapacity {  get; set;  }

        public string TypeMotocycle {  get; set;  }

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
