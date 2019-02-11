using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
    class Motorcycle : IMotorcycleVehicle
    {
        public string TypeMotorcycle { get; set; }
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
