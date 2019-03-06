using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var structure = new Bank();

            structure.Add(new Person{Name = "Cristian"});
            structure.Add(new Company{Name = "Amdaris"});

            var company = new Company();
            var htmlVisitor = new HtmlVisitor();
            structure.Accept(htmlVisitor);

            htmlVisitor.VisitCompanyAcc(company); 

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
