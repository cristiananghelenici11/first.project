using System;

namespace TemplateMethod.Payment
{
    public class CashStrategy : PaymentStrategy
    {
        protected override void GetMoney()
        {
            Console.WriteLine("GetMoney");
            
        }

        protected override void PrintMessage(int price)
        {
            Console.WriteLine($"Pay with --> Cash Strategy <--, Price: {price}");
        }
    }
}
