using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Teacher : Entity
    {
        public Teacher()
        {
            CommentTeachers = new HashSet<CommentTeacher>();
            CourseTeachers = new HashSet<CourseTeacher>();
            MarkTeachers = new HashSet<MarkTeacher>();
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CommentTeacher> CommentTeachers { get; set; }
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
        public virtual ICollection<MarkTeacher> MarkTeachers { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
