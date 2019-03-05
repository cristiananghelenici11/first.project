using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<Cat>
            {
                new Cat()
            };
=======
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    class Program
    {
        static void Main(string[] args)
        {
            // acum Cat realizeaza doar interfata IRun
            List<Cat> list = new List<Cat>();

            list.Add(new Cat());
<<<<<<< HEAD
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            foreach (Cat cats in list)
            {
                cats.Run();
            }

<<<<<<< HEAD
<<<<<<< HEAD
            var cat = new Cat();
            Console.WriteLine(cat.Run());

=======
            Cat cat = new Cat();
            Console.WriteLine(cat.Run());
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            Cat cat = new Cat();
            Console.WriteLine(cat.Run());
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            Console.ReadKey();
        }
    }
}
