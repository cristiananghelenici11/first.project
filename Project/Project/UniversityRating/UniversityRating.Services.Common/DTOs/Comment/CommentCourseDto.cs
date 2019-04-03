using UniversityRating.Services.Common.DTOs.Course;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentCourseDto : CommentDto
    {
            public CourseDto Course { get; set; }
    }
}