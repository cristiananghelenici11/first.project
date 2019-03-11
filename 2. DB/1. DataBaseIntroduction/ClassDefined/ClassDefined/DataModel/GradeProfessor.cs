using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class GradeProfessor : BaseEntity
    {
        public int Grade { get; set; }

        public long ProfessorId { get; set; }
        
        public long CourseId { get; set; }

    }
}
