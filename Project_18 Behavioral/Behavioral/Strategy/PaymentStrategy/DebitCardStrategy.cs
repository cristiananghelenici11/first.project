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
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    }
}
