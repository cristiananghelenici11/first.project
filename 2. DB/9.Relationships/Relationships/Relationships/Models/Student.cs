using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Relationships.DAL.Models
{
    [Table("Student")]
    public class Student : Entity
    {
        public long Idnp { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        //[ForeignKey(nameof(UniversityId))]
        public long UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual Address Address { get; set; }
    }
}
