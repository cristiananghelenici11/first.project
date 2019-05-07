using UniversityRating.Services.Common.DTOs.Course;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkCourseDto
    {

        public long UniversityId { get; set; }

        public long CourseId { get; set; }

        public double Mark { get; set; }

        public long UserId { get; set; }

    }
}