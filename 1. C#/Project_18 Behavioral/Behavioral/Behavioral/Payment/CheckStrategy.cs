using System;

namespace TemplateMethod.Payment
{
    public class CheckStrategy : PaymentStrategy
    {
        protected override void GetMoney()
        {
            Console.WriteLine("GetMoney");
        }

        protected override void PrintMessage(int price)
        {
            Console.WriteLine($"Pay with --> Check Strategy <--, Price: {price}");
        }
    }
}