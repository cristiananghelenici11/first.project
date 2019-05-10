namespace UniversityRating.Data.Core.DomainModels
{
    public class MarkTeacher : Mark
    {
        public long? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}