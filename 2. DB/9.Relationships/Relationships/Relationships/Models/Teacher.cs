using System;
using System.Collections.Generic;
using System.Text;

namespace Relationships.DAL.Models
{
    public class Teacher : Entity
    {

        public long Idnp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }

        public virtual ICollection<MarkTeacher> MarkTeachers { get; set; }

    }
}
