using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityRating.Presentation.Models.Mark
{
    public class EditMarkCourseViewModel
    {
        public long Id { get; set; }

        public long UniversityId { get; set; }

        public long CourseId { get; set; }

        public string UniversityName { get; set; }

        public string CourseName { get; set; }

        [Required]
        [Range(0, 10)]
        public double Mark { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
