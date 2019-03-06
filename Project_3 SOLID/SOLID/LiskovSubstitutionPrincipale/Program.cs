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
            var list = new List<Cat>
            {
                new Cat()
            };

            foreach (Cat cats in list)
            {
                cats.Run();
            }

            var cat = new Cat();
            Console.WriteLine(cat.Run());

            Console.ReadKey();
        }
    }
}
