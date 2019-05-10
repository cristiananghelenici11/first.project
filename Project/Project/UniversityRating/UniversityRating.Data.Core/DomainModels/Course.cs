using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Course : Entity
    {
        public Course()
        {
            CommentCourses = new HashSet<CommentCourse>();
            CourseTeachers = new HashSet<CourseTeacher>();
            MarkCourses = new HashSet<MarkCourse>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int YearOfStudy { get; set; }

        public long FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<CommentCourse> CommentCourses { get; set; }

        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }

        public virtual ICollection<MarkCourse> MarkCourses { get; set; }
    }
}
