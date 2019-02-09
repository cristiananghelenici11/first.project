using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
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

        public void Print(IPrinter printer)
        {
            printer.Print(Text);
        }
    }
}
