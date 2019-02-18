using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCovariantContravariant
{
    internal interface ITransaction<in T>
    {
        void DoOperation(T account, int sum);
    }
}
