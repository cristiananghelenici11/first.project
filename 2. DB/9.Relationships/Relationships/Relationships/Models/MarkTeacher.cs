using System;
using System.Collections.Generic;
using System.Text;

namespace Relationships.DAL.Models
{
    public class MarkTeacher : Mark
    {
        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
