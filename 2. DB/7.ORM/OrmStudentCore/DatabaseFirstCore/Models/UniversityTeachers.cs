using System;
using System.Collections.Generic;

namespace DatabaseFirstCore.Models
{
    public partial class UniversityTeachers
    {
        public long Id { get; set; }
        public long UniversityId { get; set; }
        public long TeacherId { get; set; }

        public virtual Teachers Teacher { get; set; }
        public virtual Universities University { get; set; }
    }
}
