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
        public long Idnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TypeTeacher { get; set; }

        public IEnumerable<CommentTeacherDto> CommentTeachers { get; set; }
        public IEnumerable<CourseDto> CourseTeachers { get; set; }
        public IEnumerable<MarkTeacherDto> MarkTeachers { get; set; }
        public IEnumerable<TeacherDto> UniversityTeachers { get; set; }
    }
}