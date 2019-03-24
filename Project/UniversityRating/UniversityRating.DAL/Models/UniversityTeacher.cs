namespace UniversityRating.DAL.Models
{
    public class UniversityTeachers
    {
        public long Id { get; set; }
        public long UniversityId { get; set; }
        public long TeacherId { get; set; }

        public virtual Teachers Teacher { get; set; }
        public virtual Universities University { get; set; }
    }
}
