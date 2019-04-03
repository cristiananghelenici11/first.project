using UniversityRating.Services.Common.DTOs.Course;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkCourseDto : MarkDto
    {
        public CourseDto Course { get; set; }
    }
}