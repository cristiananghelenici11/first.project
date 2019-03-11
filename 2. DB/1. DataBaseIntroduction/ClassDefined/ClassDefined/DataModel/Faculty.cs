﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }

        public List<Course> Courses { get; set; }

        public string testFaculty { get; set; }
    }
}
