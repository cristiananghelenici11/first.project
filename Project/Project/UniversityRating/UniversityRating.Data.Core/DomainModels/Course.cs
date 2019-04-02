using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Course : Entity
    {
        public Course()
        {
            Comments = new HashSet<Comment>();
            CourseTeachers = new HashSet<CourseTeacher>();
            Marks = new HashSet<Mark>();
        }

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
