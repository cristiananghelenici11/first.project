using System.Collections.Generic;

namespace UniversityRating.Data.Core.DomainModels
{
    public class University : Entity
    {
        public University()
        {
            Faculties = new HashSet<Faculty>();
            UniversityTeachers = new HashSet<UniversityTeacher>();
            CommentUniversities = new HashSet<CommentUniversity>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
        public virtual ICollection<CommentUniversity> CommentUniversities { get; set; }
    }
}
