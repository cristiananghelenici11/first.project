using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Course;
using UniversityRating.Services.Common.DTOs.Mark;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.Common.DTOs.CourseTeacher
{
    public class CourseTeacherDto
    {
        public virtual CourseDto Course { get; set; }
        public virtual TeacherDto Teacher { get; set; }
        public virtual ICollection<MarkCourseTeacherDto> MarkCourseTeachers { get; set; }
        public virtual ICollection<CommentCourseTeacherDto> CommentCourseTeachers { get; set; }
    }
}