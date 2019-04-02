using System.Collections;
using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class CourseTeacher : Entity
    {
        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<MarkCourseTeacher> MarkCourseTeachers { get; set; }
        public virtual ICollection<CommentCourseTeacher> CommentCourseTeachers { get; set; }
    }
}
