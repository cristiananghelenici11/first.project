using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class CourseTeacher
    {
        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
