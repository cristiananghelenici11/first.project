using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.PaymentStrategy;

namespace Strategy
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var customer = new Customer("Cristian", 123456, new DebitCardStrategy());
            customer.Pay(100);

            customer.PaymentStrategy = new CashStrategy();
            customer.Pay(300);

            Console.ReadKey();
        }
    }
}