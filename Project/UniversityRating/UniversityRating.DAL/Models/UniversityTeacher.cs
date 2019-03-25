namespace UniversityRating.DAL.Models
{
    public class UniversityTeachers : Entity
    {
        public long UniversityId { get; set; }
        public long TeacherId { get; set; }

        public virtual Teachers Teacher { get; set; }
        public virtual University University { get; set; }
    }
}
