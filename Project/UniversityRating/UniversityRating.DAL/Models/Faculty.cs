using System.Collections.Generic;

namespace UniversityRating.DAL.Models
{
    public class Faculties : Entity
    {
        public Faculties()
        {
            Courses = new HashSet<Courses>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long UniverstityId { get; set; }

        public virtual University Universtity { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
