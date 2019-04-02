using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class User : Entity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Marks = new HashSet<Mark>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Idnp { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
