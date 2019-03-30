using System;
using System.Collections.Generic;
using System.Text;

namespace University.DAL.Models
{
    public class StudentCourse
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }

        public long CourseId { get; set; }
        public virtual Course Course{get; set;}

        public int Mark { get; set; }
    }
}
