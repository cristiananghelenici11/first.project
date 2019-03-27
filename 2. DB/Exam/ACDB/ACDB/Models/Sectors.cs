using System;
using System.Collections.Generic;

namespace ACDB.Models
{
    public partial class Sectors
    {
        public Sectors()
        {
            Packages = new HashSet<Packages>();
        }

        public int SectorId { get; set; }
        public string SectorName { get; set; }

        public virtual ICollection<Packages> Packages { get; set; }
    }
}
