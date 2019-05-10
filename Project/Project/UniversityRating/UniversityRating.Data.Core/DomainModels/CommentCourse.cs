namespace UniversityRating.Data.Core.DomainModels
{
    public class CommentCourse : Comment
    {
        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}