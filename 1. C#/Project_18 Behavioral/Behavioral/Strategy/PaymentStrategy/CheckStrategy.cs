using System;

namespace Strategy.PaymentStrategy
{
    public class CheckStrategy : IPaymentStrategy
    {
        public void Pay(int price)
        {
            Console.WriteLine($"Pay with --> Check Strategy <--, Price: {price}");
        }
    }
}