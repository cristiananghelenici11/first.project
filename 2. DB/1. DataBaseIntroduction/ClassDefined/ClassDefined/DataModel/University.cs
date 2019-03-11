using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class University : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Faculty> Faculties { get; set; }

    }
}
