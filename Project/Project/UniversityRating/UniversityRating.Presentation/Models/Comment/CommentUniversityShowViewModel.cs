namespace UniversityRating.Presentation.Models.Comment
{
    public class CommentUniversityShowViewModel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? UniversityId { get; set; }
    }
}