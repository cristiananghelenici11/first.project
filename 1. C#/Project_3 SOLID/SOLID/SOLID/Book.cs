namespace SingleResponsabilityPrincipale
{
    public class Book
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
