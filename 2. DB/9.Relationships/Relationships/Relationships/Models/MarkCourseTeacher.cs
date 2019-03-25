using System;
using System.Collections.Generic;
using System.Text;

namespace Relationships.DAL.Models
{
    public class MarkCourseTeacher : Mark
    {
        public long? CourseId { get; set; }
        public long? TeacherId { get; set; }


    }
}
