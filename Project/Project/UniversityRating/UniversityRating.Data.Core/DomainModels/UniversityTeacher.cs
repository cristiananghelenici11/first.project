namespace UniversityRating.Data.Core.DomainModels
{
    public class UniversityTeacher : Entity
    {
        public long UniversityId { get; set; }
        public long TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual University University { get; set; }
    }
}
