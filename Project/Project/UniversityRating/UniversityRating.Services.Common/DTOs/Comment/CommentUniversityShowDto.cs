using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentUniversityShowDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? UniversityId { get; set; }

    }
}