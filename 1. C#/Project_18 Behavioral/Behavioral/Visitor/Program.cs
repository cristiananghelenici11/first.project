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
            //var bank = new Bank();

            //bank.Add(new Person{Name = "Cristian"});
            //bank.Add(new Company{Name = "Amdaris"});

            //var company = new Company();
            //var htmlVisitor = new HtmlOperatie();
            //bank.Accept(htmlVisitor);

            //htmlVisitor.Visit(company); 

            //Console.WriteLine("Hello World!");

            M(new HtmlOperatie(), new Company(), new Person());
            M(new XmlOperatie(), new Company(), new Person());

            Console.ReadKey();
        }

        static void M(IOperatie operatie, params IAcceptOperatii[] objects)
        {
            foreach (IAcceptOperatii o in objects)
            {
                o.Accept(operatie);
            }
        }
    }
}
