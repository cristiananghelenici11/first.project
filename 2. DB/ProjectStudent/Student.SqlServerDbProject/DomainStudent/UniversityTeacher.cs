using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class UniversityTeacher
    {
        public long Id { get; set; }
        public long UniversityId { get; set; }
        public long TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual University University { get; set; }
    }
}
