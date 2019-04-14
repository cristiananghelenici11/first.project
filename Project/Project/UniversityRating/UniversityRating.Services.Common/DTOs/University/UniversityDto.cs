using System.Collections;
using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Faculty;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.University
{
    public class UniversityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }

        public virtual IEnumerable<FacultyDto> Faculties { get; set; }
        public virtual IEnumerable<TeacherDto> UniversityTeachers { get; set; }
    }
}