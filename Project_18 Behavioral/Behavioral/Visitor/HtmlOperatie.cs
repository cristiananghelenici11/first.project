using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class HtmlOperatie : IOperatie
    {
        public void Visit(Company acc)
        {
            Console.WriteLine($"Html + Company");
        }

        public void Visit(Person acc)
        {
            Console.WriteLine("Html + Person");
        }

    }
}
