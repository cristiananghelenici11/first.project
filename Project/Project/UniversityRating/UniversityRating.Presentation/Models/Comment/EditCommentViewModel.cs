using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Presentation.Models.Comment
{
    public class EditCommentViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public long UserId { get; set; }
    }
}