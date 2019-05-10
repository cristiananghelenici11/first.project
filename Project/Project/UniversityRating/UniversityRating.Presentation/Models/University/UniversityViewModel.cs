using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.University
{
    public class UniversityViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public int Age { get; set; }
    }
}