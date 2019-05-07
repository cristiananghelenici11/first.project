namespace UniversityRating.Data.Core.DomainModels
{
    public class CommentTeacher : Comment
    {
        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}