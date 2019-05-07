using UniversityRating.Services.Common.DTOs.User;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }

    }
}