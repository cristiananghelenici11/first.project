namespace UniversityRating.Data.Core.DomainModels
{
    public class MarkCourse : Mark
    {
        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}