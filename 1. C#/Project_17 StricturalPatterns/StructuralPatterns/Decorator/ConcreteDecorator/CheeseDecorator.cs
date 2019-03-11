using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(Pizza pizza) : base(pizza.Name + "+ witch cheese",  pizza)
        {
        }

        public override int GetCost()
        {
            return pizza.GetCost() + 10;
        }
    }
}
