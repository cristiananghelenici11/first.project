using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {

            Vehicle vehicle = new Bus();
            vehicle.Speed = 9;

            vehicle = new Car();
            vehicle.Speed = 8;

            Console.ReadKey();

        }
     
    }
    
}
