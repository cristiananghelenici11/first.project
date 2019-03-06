using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrincipale
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            var book = new Book {Text = "Book Number 1"};
            book.Print(printer);

            Console.ReadLine();
        }

    }
}
