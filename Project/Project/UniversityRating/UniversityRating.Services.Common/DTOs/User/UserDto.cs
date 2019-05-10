using System.Collections.Generic;
using UniversityRating.Services.Common.DTOs.Comment;
using UniversityRating.Services.Common.DTOs.Mark;

namespace UniversityRating.Services.Common.DTOs.User
{
    public class UserDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long Idnp { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}