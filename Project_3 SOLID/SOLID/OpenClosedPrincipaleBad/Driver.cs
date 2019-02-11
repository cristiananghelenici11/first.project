using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipaleBad
{
    class Driver
    {
        public string Name { get; set; }

        public Driver(string name)
        {
            Name = name;
        }

        public void Drive()
        {
            Console.Write($"{Name} Drive ");
            Console.WriteLine("Start and drive the car");
        }
    }
}
