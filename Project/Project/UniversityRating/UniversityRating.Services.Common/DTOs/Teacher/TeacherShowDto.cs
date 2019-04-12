using System.Collections.Generic;

namespace UniversityRating.Services.Common.DTOs.Teacher
{
    public class TeacherShowDto
    {
        public long Id { get; set; }
        public double AverangeMarks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TypeTeacher { get; set; }
        public List<string> Universities { get; set; }
    }
}