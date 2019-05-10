using System.ComponentModel.DataAnnotations;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkCourseTeacherDto
    {
        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public double Mark { get; set; }

        public long UserId { get; set; }

        public long CourseId { get; set; }

    }
}