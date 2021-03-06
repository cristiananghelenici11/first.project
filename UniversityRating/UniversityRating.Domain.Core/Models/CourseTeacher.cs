﻿namespace UniversityRating.Domain.Core.Models
{
    public partial class CourseTeachers
    {
        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? CourseId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
