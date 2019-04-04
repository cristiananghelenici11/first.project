﻿using UniversityRating.Data.Core.DomainModels.Identity;

namespace UniversityRating.Data.Core.DomainModels
{
    public abstract class Comment : Entity
    {
        public string Subject { get; set; }
        public string Message { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
