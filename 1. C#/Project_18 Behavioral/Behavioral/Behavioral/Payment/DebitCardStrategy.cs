using System;

namespace TemplateMethod.Payment
{
    public class DebitCardStrategy : PaymentStrategy
    {
        protected override void GetMoney()
        {
            Console.WriteLine("GetMoney");
        }

        protected override void PrintMessage(int price)
        {
            Console.WriteLine($"Pay with --> Debit Card Strategy <---, Price: {price}");
        }
    }
}
