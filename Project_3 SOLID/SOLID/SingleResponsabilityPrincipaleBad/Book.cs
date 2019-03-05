using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrincipaleBad
{
<<<<<<< HEAD
    public class Book
=======
    class Book
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public string Text { get; set; }

        public void GoToFirstPage()
        {
        }

        public void GoToLastPage()
        {
        }

        public void GoToPage(int pageNumber)
        {
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
