using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Computer
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand},\t {Model},\t {Price},\t {Ram},\t {Storage}";

        }
    }
}
