namespace UniversityRating.Data.Core.DomainModels
{
    public class CommentUniversity : Comment
    {
        public long UniversityId { get; set; }

        public virtual University University { get; set; }
    }
}