using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            Book book = new Book(){Text = "Hi"};
            book.Print(printer);
            Console.ReadLine();
        }
    }
    
}
