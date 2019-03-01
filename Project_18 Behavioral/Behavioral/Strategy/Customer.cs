using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Customer
    {
        private readonly string _name;
        private readonly long _id;
        public IPaymentStrategy PaymentStrategy { private get; set; }

        public Customer(string name, long id, IPaymentStrategy paymentStrategy)
        {
            _name = name;
            _id = id;
            PaymentStrategy = paymentStrategy;
        }
        
        public void Pay(int price)
        {
            PaymentStrategy.Pay(price);
        }

    }
}
