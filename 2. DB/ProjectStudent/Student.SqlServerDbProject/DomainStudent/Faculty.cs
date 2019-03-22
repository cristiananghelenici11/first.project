using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class Faculty
    {
        public Faculty()
        {
            Courses = new HashSet<Course>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long UniverstityId { get; set; }

        public virtual University Universtity { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
