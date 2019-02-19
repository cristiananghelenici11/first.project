using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal static class Print
    {
        public static void Display(IEnumerable<Computer> computers)
        {
            foreach(Computer computer in computers)
            {
                Console.WriteLine(computer);

            }
            Console.WriteLine();

        }
    }
}
