using UniversityRating.Services.Common.DTOs.User;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class MarkDto
    {
        public long Id { get; set; }
        public float Value { get; set; }
        public UserDto User { get; set; }
    }
}