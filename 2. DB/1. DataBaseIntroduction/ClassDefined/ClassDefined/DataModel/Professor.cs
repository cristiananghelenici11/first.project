using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.DataModel
{
    public class Professor : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long Phone { get; set; }

        public string Email { get; set; }

        public int? Likes { get; set; }

        public int? Dislikes { get; set; }

        public int Dislike { get; set; }

        public List<GradeProfessor> Grades { get; set; }

        public List<Comment> Comments { get; set; }

        public List<University> Universities { get; set; }

    }
}
