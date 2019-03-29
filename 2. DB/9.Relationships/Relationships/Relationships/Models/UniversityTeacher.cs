using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.DAL.Models
{
    public class UniversityTeacher : Entity
    {
        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public long UniversityId { get; set; }
        public virtual University University {get; set; }
    }
}