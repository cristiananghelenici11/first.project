using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCovariantContravariant
{
    internal class Account
    {
        public virtual void DoTransfer(int sum)
        {
            Console.WriteLine($"client has deposited {sum} $");
        }
    }
}
