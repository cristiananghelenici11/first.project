using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Teacher : Entity
    {
        public Teacher()
        {
            Comments = new HashSet<Comment>();
            CourseTeachers = new HashSet<CourseTeacher>();
            Marks = new HashSet<Mark>();
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
