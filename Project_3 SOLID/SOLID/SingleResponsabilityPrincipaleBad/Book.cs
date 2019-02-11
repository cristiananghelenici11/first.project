using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrincipaleBad
{
    class Book
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
