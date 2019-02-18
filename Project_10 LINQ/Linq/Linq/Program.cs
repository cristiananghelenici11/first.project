using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
     
    class Program
    {
        static void Main(string[] args)
        {
            var computers = new List<Computer>()
            {
                new Computer("Apple", "2018      ", 2400, 16, 512),
                new Computer("ASUS", "Zenbook   ", 1800, 24, 256),
                new Computer("DEL", "XPS       ", 2100, 24, 256),
                new Computer("HP", "Chromebook", 1900, 16, 256)
            };
            Print.Display(computers);

            Console.ReadKey();
        }
    }
}
