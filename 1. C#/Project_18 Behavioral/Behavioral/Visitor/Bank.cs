using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Bank
    {
        List<IAcceptOperatii> accounts = new List<IAcceptOperatii>();

        public void Add(IAcceptOperatii acc)
        {
            accounts.Add(acc);
        }

        public void Remove(IAcceptOperatii acc)
        {
            accounts.Remove(acc);
        }

        public void Accept(IOperatie operatie)
        {
            foreach (IAcceptOperatii acc in accounts)
                acc.Accept(operatie);
        }

    }
}
