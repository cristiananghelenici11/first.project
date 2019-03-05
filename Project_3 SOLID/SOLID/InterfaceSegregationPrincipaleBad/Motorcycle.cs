using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipaleBad
{
    public class Motorcycle : IVehicle
    {
        public string Mark { get; set; }

        public string Model { get; set;  }

        public double LoadCapacity { get; set;  }

        public string TypeMotorcycle { get; set;  }

        public string Transmision { get; set;  }


        public void Move()
        {
            Console.WriteLine("Move Motorcyle");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Motorcyle");      }
        }
    }
}
