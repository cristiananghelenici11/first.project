using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var animalRunners = new List<IRun>
            {
                new Sheep(),
                new Crocodile(),
            };

            foreach (IRun runner in animalRunners)
            {
                runner.Run();
            }

            var cat = new Sheep();
            Console.WriteLine(cat.Run());

            Console.ReadKey();
        }
    }
}
