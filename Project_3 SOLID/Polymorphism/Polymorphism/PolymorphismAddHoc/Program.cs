using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismAddHoc
{
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {
            var operation = new Operation();
=======
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            operation.Add(2, 4);
            operation.Add(2, 4, 5);
            operation.Add(2, 4, 5.5);

<<<<<<< HEAD
=======

            Console.ReadKey();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            // coercing 
            int a = 45;
            double b = a;
            long c = a;
<<<<<<< HEAD

            Console.ReadKey();

=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        }
    }
}
