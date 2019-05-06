using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.Comment
{
    public class CommentUniversityViewModel
    {
        public long Id { get; set; }

        [Required]
        public long UniversityId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string Subject { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }
    }
}