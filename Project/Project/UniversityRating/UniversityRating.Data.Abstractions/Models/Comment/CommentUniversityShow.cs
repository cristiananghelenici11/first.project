namespace UniversityRating.Data.Abstractions.Models.Comment
{
    public class CommentUniversityShow
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? UniversityId { get; set; }
        
    }
}