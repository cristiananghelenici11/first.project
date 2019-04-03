using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentUniversityDto : CommentDto
    {
        public virtual UniversityDto University { get; set; }

    }
}