﻿using System.Collections.Generic;

namespace UniversityRating.DAL.Models
{
    public class Courses : Entity
    {
        public Courses()
        {
            Comments = new HashSet<Comment>();
            CourseTeachers = new HashSet<CourseTeachers>();
            Marks = new HashSet<Marks>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int YearOfStudy { get; set; }
        public long FacultyId { get; set; }

        public virtual Faculties Faculty { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseTeachers> CourseTeachers { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}
