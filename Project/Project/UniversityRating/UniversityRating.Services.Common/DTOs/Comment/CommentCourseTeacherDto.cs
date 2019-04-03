using UniversityRating.Services.Common.DTOs.CourseTeacher;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentCourseTeacherDto : CommentDto
    {
        public CourseTeacherDto CourseTeacher { get; set; }

    }
}