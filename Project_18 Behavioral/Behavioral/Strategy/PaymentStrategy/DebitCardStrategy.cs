using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.PaymentStrategy
{
    public class DebitCardStrategy : IPaymentStrategy
    {
        public void Pay(int price)
        {
            Console.WriteLine($"Pay with --> Debit Card Strategy <---, Price: {price}");
        }
    }
}
