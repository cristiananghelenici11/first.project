using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniversityRating.Data.Core.DomainModels.Identity
{
    public class User : IdentityUser<long>
    {
        public User() : base()
        {
            Comments = new HashSet<Comment>();
            Marks = new HashSet<Mark>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}