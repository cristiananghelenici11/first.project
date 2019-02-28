using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MeatPizza : PizzaDecorator
    {
        public MeatPizza(Pizza pizza) : base($"{pizza.Name} + meat pizza", pizza)
        {
        }
        public override int GetCost()
        {
            return pizza.GetCost() + 15;
        }
    }
}
