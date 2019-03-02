using System;

namespace TemplateMethod.Payment
{
    public class CheckStrategy : PaymentStrategy
    {
        public override void Pay(int price)
        {
            Console.WriteLine($"Pay with --> Check Strategy <--, Price: {price}");
        }

    }
}