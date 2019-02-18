using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCovariantContravariant
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // covariant
            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            Account account1 = depositBank.CreateAccount(100);

            IBank<Account> ordinaryBank = new Bank<DepositAccount>();
            Account account2 = ordinaryBank.CreateAccount(50);

            // contravariant
            ITransaction<Account> accTransaction = new Transaction<Account>();
            accTransaction.DoOperation(new Account(), 400);

            ITransaction<DepositAccount> depAccTransaction = new Transaction<Account>();
            depAccTransaction.DoOperation(new DepositAccount(), 450);

            Console.ReadKey();

        }
    }
}
