using System;

namespace TemplateMethod.Payment
{
    public class DebitCardStrategy : PaymentStrategy
    {
        public override void Pay(int price)
        {
            Console.WriteLine($"Pay with --> Debit Card Strategy <---, Price: {price}");
        }
    }
}
