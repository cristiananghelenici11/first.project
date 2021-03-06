﻿using System;
using System.Collections.Generic;

namespace DatabaseFirstCore.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Comments = new HashSet<Comments>();
            CourseTeachers = new HashSet<CourseTeachers>();
            Marks = new HashSet<Marks>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int YearOfStudy { get; set; }
        public long FacultyId { get; set; }

        public virtual Faculties Faculty { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<CourseTeachers> CourseTeachers { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}
