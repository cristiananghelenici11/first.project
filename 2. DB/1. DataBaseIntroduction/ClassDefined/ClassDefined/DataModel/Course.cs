using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int YearOfStudy { get; set; }

        public int Credits { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<GradeProfessor> Grades { get; set; }

        public List<Professor> Professors { get; set; }

        public List<LaboratoryWork> Laboratories{ get; set;  }

    }
}
