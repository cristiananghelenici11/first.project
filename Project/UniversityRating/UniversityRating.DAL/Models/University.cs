using System.Collections.Generic;

namespace UniversityRating.DAL.Models
{
    public class University : Entity
    {
        public University()
        {
            Faculties = new HashSet<Faculties>();
            UniversityTeachers = new HashSet<UniversityTeachers>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Faculties> Faculties { get; set; }
        public virtual ICollection<UniversityTeachers> UniversityTeachers { get; set; }
    }
}
