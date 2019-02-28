using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Gearbox
    {
        public void SetOnDrive()
        {
            Console.WriteLine("Gearbox on drive");
        }

        public void SetOnParking()
        {
            Console.WriteLine("Gearbox on parking");

        }
    }
}
