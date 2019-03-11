using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MeatDecorator : PizzaDecorator
    {
        public MeatDecorator(Pizza pizza) : base($"{pizza.Name} + meat pizza", pizza)
        {
        }
        public override int GetCost()
        {
            return pizza.GetCost() + 15;
        }
    }
}
