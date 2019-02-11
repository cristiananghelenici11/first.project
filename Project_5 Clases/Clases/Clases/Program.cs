using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "JohnSmitch";

            string name = user.Name;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    class User
    {
        public  string A { get; set; }
        private int a;
        public int BirthYear;

        public int Age
        {
            get { return DateTime.Now.Year - BirthYear; }
            set { BirthYear = DateTime.Now.Year - value; }
        }
    }
}
