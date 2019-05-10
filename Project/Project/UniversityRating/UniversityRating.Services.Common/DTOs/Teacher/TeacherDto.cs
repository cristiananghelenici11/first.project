using System.Collections;
using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Course;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.Common.DTOs.Teacher
{
    public class TeacherDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string TypeTeacher { get; set; }
    }
}