using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Italian Pizza")
        {

        }

        public override int GetCost()
        {
            return 80;
        }
    }
}
