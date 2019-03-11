using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class RanchoPizza : Pizza
    {
        public RanchoPizza() : base("Rancho pizza")
        {

        }
        public override int GetCost()
        {
            return 85;
        }
    }
}
