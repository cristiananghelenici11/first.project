using System.Collections;
using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.CourseTeacher;
using UniversityRating.Services.Common.DTOs.Faculty;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.Common.DTOs.Course
{
    public class CourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}