using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation
{
    internal class Airport
    {
        public string Location { get; set; }
        public double Area { get; set; }

        public Aircraft Aircraft { get; set; }
    }
}
