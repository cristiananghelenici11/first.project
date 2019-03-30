using System;
using System.Collections.Generic;
using System.Text;

namespace University.DAL.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
    