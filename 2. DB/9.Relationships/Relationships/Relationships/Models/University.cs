using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Relationships.DAL.Models
{
    public class University : Entity
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Contact { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}