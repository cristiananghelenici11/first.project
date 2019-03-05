using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {

            var list = new List<Animal>
            {
                new Cat(), 
                new Crocodile()
            };

=======
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> list = new List<Animal>();

            list.Add(new Cat());
            list.Add(new Crocodile());
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            foreach (Animal animal in list)
            {
                animal.Swim();
            }
<<<<<<< HEAD

            Console.ReadKey();
=======
            Console.ReadKey();

>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        }
    }
}
