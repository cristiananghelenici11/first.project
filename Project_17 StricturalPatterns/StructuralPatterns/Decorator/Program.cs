using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Pizza p1 = new RanchoPizza();
            p1 = new CheesePizza(p1);
            p1 = new MeatPizza(p1);
            Console.WriteLine($"Name: {p1.Name}, Cost: {p1.GetCost()}");

            Pizza p2 = new ItalianPizza();
            p2 = new MeatPizza(p2);
            Console.WriteLine($"Name: {p2.Name}, Cost: {p2.GetCost()}");

            
            Console.ReadKey();
        }
    }
}
