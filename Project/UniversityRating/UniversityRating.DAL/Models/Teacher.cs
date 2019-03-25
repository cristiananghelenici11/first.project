using System.Collections.Generic;

namespace UniversityRating.DAL.Models
{
    public class Teachers : Entity
    {
        public Teachers()
        {
            Comments = new HashSet<Comment>();
            CourseTeachers = new HashSet<CourseTeachers>();
            Marks = new HashSet<Marks>();
            UniversityTeachers = new HashSet<UniversityTeachers>();
        }

        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseTeachers> CourseTeachers { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
        public virtual ICollection<UniversityTeachers> UniversityTeachers { get; set; }
    }
}
