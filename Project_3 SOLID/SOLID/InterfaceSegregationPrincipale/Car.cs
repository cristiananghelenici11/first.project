using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
    public class Car : ICar
    {
        public string Transmision { get; set; }
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
