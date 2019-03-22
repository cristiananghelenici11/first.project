using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public partial class Course
    {
        public Course()
        {
            Comments = new HashSet<Comment>();
            CourseTeachers = new HashSet<CourseTeacher>();
            Marks = new HashSet<Mark>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int YearOfStudy { get; set; }
        public long FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
