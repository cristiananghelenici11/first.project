namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class EditMarkTeacherDto
    {
        public long Id { get; set; }

        public long UniversityId { get; set; }

        public long TeacherId { get; set; }

        public string UniversityName { get; set; }

        public string TeacherName { get; set; }

        public double Mark { get; set; }

        public long UserId { get; set; }
    }
}