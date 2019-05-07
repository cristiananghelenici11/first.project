using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityRating.Services.Common.DTOs.Mark
{
    public class EditMarkDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public double Value { get; set; }
    }
}
