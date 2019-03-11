using System;
using TemplateMethod.Payment;

namespace TemplateMethod
{
    public class Program
    {
        private static void Main(string[] args)
        {
            PaymentStrategy paymentStrategy1 = new CashStrategy();
            PaymentStrategy paymentStrategy2 = new CheckStrategy();
            PaymentStrategy paymentStrategy3 = new DebitCardStrategy();

            paymentStrategy1.Pay(100);
            paymentStrategy2.Pay(150);
            paymentStrategy3.Pay(300);

            Console.ReadKey();
        }
    }
}
