using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class LaboratoryWork : BaseEntity
    {
        public string Name { get; set; }

        public int NumberOfVariants { get; set; }
   
        public FileStream File { get; set; }

    }
}
