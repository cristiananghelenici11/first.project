﻿using UniversityRating.Data.Core.DomainModels.Identity;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Mark : Entity
    {
        public long UserId { get; set; }

        public double Value { get; set; }

        public virtual User User { get; set; }
    }
}