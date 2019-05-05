using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentTeacherDto
    {
        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }

    }
}