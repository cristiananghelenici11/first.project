using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    public class Program
    {
        private static void Main(string[] args)
        {

            var list = new List<Animal>
            {
                new Sheep(), 
                new Crocodile()
            };

            foreach (Animal animal in list)
            {
                animal.Swim();
            }
            Console.ReadKey();
        }
    }
}
