using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class EditMarkCourseTeacherDto
    {
        public long Id { get; set; }

        public long UniversityId { get; set; }

        public long CourseId { get; set; }

        public long TeacherId { get; set; }

        public string UniversityName { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        public double Mark { get; set; }

        public long UserId { get; set; }
    }
}
