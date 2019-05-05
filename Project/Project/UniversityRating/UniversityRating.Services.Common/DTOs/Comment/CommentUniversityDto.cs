namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentUniversityDto
    {
        public long UniversityId { get; set; }

        public long UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}