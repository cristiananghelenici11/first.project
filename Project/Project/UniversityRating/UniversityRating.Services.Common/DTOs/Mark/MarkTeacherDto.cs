using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkTeacherDto : MarkDto
    {
        public TeacherDto Teacher { get; set; }
    }
}