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
            var bank = new Bank();

            bank.Add(new Person{Name = "Cristian"});
            bank.Add(new Company{Name = "Amdaris"});

            var company = new Company();
            var htmlVisitor = new HtmlVisitor();
            bank.Accept(htmlVisitor);

            htmlVisitor.VisitCompanyAcc(company); 

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
