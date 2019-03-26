using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent
{
    public class University
    {
        public University()
        {
            Faculties = new HashSet<Faculty>();
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public double Age { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
