using System;
using System.Collections.Generic;
using System.Text;

namespace University.DAL.Models
{
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
