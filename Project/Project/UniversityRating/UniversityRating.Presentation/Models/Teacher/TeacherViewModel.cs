using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.Teacher
{
    public class TeacherViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string TypeTeacher { get; set; }
    }
}