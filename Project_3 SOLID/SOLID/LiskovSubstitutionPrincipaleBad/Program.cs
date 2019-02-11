using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> list = new List<Animal>();

            list.Add(new Cat());
            list.Add(new Crocodile());

            foreach (Animal animal in list)
            {
                animal.Swim();
            }
            Console.ReadKey();

        }
    }
}
