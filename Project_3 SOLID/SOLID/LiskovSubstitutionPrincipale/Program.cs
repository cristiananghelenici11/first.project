using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {
            // acum Cat realizeaza doar interfata IRun
            List<Cat> list = new List<Cat>();

            list.Add(new Cat());

            foreach (Cat cats in list)
            {
                cats.Run();
            }

            Cat cat = new Cat();
            Console.WriteLine(cat.Run());
            Console.ReadKey();
        }
    }
}
