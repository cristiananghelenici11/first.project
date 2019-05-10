using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class Faculty : Entity
    {
        public Faculty()
        {
            Courses = new HashSet<Course>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public long UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
