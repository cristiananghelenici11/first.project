using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.Mark
{
    public class MarkCourseTeacherViewModel
    {
        public long? UniversityId { get; set; }

        [Required]
        public long TeacherId { get; set; }

        [Required]
        [Range(0, 10)]
        public double Mark { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long CourseId { get; set; }
    }
}