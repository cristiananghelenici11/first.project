using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCovariantContravariant
{
    internal class Bank<T> : IBank<T> where T : Account, new()
    {
        public T CreateAccount(int sum)
        {
            var acc = new T();
            acc.DoTransfer(sum);
            return acc;
        }
    }
}
