using System.Collections.Generic;

namespace DomainStudent
{
    public class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Mark = new HashSet<Mark>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Idnp { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
    }
}