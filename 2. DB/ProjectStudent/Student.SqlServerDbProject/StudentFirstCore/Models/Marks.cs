﻿using System;
using System.Collections.Generic;

namespace StudentFirstCore.Models
{
    public partial class Marks
    {
        public long Id { get; set; }
        public string TypeMark { get; set; }
        public float? Value { get; set; }
        public long? TeacherId { get; set; }
        public long? CourseId { get; set; }
        public long UserId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Teachers Teacher { get; set; }
        public virtual Users User { get; set; }
    }
}
