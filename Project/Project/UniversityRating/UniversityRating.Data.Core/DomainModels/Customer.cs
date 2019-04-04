using System;
using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Customer : Entity
    {
        public Customer()
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
