using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentTeacherDto : CommentDto
    {
        public virtual TeacherDto Teacher { get; set; }
    }
}