﻿namespace UniversityRating.Services.Common.DTOs.Comment
{
    public class CommentDto
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Type { get; set; }
    }
}