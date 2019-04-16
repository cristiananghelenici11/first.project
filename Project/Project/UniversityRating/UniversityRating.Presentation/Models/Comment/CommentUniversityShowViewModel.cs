namespace UniversityRating.Presentation.Models.Comment
{
    public class CommentUniversityShowViewModel
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? UniversityId { get; set; }
    }
}