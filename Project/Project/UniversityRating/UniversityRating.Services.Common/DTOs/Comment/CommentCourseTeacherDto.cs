﻿
namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentCourseTeacherDto
    {
        public long Id { get; set; }

        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public long CourseId { get; set; }

        public long UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}