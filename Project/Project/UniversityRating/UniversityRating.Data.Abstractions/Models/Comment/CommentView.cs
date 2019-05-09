namespace UniversityRating.Data.Abstractions.Models.Comment
{
    public class CommentView
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Type { get; set; }
    }
}