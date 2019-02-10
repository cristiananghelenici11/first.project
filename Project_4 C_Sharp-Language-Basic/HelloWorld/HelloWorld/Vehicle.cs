using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Vehicle
    {
        public string Mark { get; set; }
        public string Model { get; set; }

        public static int CalculateDistance(int start, int stop) => stop - start;
    }
}
