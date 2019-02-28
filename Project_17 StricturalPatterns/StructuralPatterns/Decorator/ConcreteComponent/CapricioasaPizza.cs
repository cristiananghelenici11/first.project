using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class CapricioasaPizza : Pizza
    {
        public CapricioasaPizza() : base("Capricioasa pizza")
        {
        }

        public override int GetCost()
        {
            return 90;
        }
    }
}
