using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class Mark
    {
        public long Id { get; set; }
        public string TypeMark { get; set; }
        public float? Value { get; set; }
        public long? TeacherId { get; set; }
        public long? CourseId { get; set; }
        public long UserId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual User User { get; set; }
    }
}
