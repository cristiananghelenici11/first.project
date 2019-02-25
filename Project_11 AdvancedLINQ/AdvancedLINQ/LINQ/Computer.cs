using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
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
