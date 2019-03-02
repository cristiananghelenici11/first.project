using System;

namespace TemplateMethod.Payment
{
    public class CashStrategy : PaymentStrategy
    {
        public override void Pay(int price)
        {
            Console.WriteLine($"Pay with --> Cash Strategy <--, Price: {price}");
        }
    }
}
