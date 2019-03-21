using System;
using System.Collections.Generic;

namespace StudentFirstCore.Models
{
    public partial class Faculties
    {
        public Faculties()
        {
            Courses = new HashSet<Courses>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long UniverstityId { get; set; }

        public virtual Universities Universtity { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
