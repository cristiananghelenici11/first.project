using System;
using System.Collections.Generic;

namespace StudentFirstCore.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Comments = new HashSet<Comments>();
            CourseTeachers = new HashSet<CourseTeachers>();
            Marks = new HashSet<Marks>();
            UniversityTeachers = new HashSet<UniversityTeachers>();
        }

        public long Id { get; set; }
        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<CourseTeachers> CourseTeachers { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
        public virtual ICollection<UniversityTeachers> UniversityTeachers { get; set; }
    }
}
