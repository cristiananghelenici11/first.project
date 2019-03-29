using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.DAL.Models
{
    public class Address : Entity
    {

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        //[ConcurrencyCheck]
        //[Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(StudentId))]
        public long StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}