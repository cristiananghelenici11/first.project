using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismAddHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();

            operation.Add(2, 4);
            operation.Add(2, 4, 5);
            operation.Add(2, 4, 5.5);


            Console.ReadKey();
            // coercing 
            int a = 45;
            double b = a;
            long c = a;
        }
    }
}
