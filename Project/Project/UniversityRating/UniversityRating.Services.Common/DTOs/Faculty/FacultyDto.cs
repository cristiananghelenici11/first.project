using System.Collections;
using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Course;
using UniversityRating.Services.Common.DTOs.University;

namespace UniversityRating.Services.Common.DTOs.Faculty
{
    public class FacultyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public UniversityDto Universtity { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}