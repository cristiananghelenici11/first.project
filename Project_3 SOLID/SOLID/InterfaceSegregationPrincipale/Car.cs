using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Car : ICar
=======
    class Car : ICar
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
    class Car : ICar
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
