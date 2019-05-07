using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.Mark
{
    public class EditMarkTeacherViewModel
    {
        public long Id { get; set; }
        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public string UniversityName { get; set; }

        public string TeacherName { get; set; }

        [Required]
        [Range(0, 10)]
        public double Mark { get; set; }

        public long UserId { get; set; }
    }
}