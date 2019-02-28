using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Pizza
    {
        protected Pizza(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public abstract int GetCost();
    }
}
