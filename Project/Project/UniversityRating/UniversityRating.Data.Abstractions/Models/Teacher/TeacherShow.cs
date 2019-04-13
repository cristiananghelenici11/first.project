using System.Collections.Generic;

namespace UniversityRating.Data.Abstractions.Models.Teacher
{
    public class TeacherShow
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