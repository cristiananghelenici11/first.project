using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrincipale
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class Program
    {
        private static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            var book = new Book{Text = "Book Number 1"};
            book.Print(printer);

            Console.ReadLine();
=======
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            Book book = new Book(){Text = "Book Number 1"};
            book.Print(printer);
            Console.ReadLine();

<<<<<<< HEAD
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        }
    }
    
}
