namespace UniversityRating.Presentation.Models.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Type { get; set; }
    }
}