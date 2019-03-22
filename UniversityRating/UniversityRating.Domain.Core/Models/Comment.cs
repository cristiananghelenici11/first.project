namespace UniversityRating.Domain.Core.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public long? CourseId { get; set; }
        public long? TeacherId { get; set; }
        public long? UserId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
        public virtual User User { get; set; }
    }
}
