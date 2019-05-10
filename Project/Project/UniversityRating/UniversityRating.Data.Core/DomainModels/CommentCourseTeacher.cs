namespace UniversityRating.Data.Core.DomainModels
{
    public class CommentCourseTeacher : Comment
    {
        public long? CourseTeacherId { get; set; }

        public virtual CourseTeacher CourseTeacher { get; set; }
    }
}