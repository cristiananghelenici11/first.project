namespace UniversityRating.Data.Core.DomainModels
{
    public class Comment : Entity
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public long? CourseId { get; set; }
        public long? TeacherId { get; set; }
        public long? UserId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual User User { get; set; }
    }
}
