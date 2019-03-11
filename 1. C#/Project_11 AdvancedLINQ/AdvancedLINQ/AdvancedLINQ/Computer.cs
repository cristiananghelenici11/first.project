using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ
{
    public class Computer
    {
        public string Brand { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand}, Ram: {Ram}, Storage: {Storage}";
        }
    }
}
