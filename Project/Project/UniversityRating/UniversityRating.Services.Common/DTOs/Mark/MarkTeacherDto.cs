using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkTeacherDto
    {
        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public double Mark { get; set; }

        public long UserId { get; set; }
    }
}