﻿namespace UniversityRating.Data.Core.DomainModels
{
    public class MarkCourseTeacher : Mark
    {
        public long CourseTeacherId { get; set; }

        public virtual CourseTeacher CourseTeacher { get; set; }
    }
}