namespace UniversityRating.DAL.Models
{
    public class CourseTeachers : Entity
    {
        public long? TeacherId { get; set; }
        public long? CourseId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
