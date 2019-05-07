using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityRating.Presentation.Models.Mark
{
    public class EditMarkViewModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        
        public double Value { get; set; }
        
    }
}
