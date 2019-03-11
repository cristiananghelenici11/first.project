using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCovariantContravariant
{
    internal class Transaction<T> : ITransaction<T> where T : Account
    {
        public void DoOperation(T account, int sum)
        {
            account.DoTransfer(sum);
        }
    }
}
