using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelper.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Price { get; set; }
        [MaxLength(2)]
        public string About { get; set; }
 
        [MaxLength]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
