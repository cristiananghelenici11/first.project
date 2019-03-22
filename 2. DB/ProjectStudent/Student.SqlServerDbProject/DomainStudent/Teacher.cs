using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class Teacher
    {
        public Teacher()
        {
            Comment = new HashSet<Comment>();
            CourseTeacher = new HashSet<CourseTeacher>();
            Mark = new HashSet<Mark>();
            UniversityTeacher = new HashSet<UniversityTeacher>();
        }

        public long Id { get; set; }
        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<CourseTeacher> CourseTeacher { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeacher { get; set; }
    }
}
