using System;
using System.Collections.Generic;

namespace StudentFirstCore.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Marks = new HashSet<Marks>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Idnp { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}
