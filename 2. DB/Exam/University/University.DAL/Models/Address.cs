using System;
using System.Collections.Generic;
using System.Text;

namespace University.DAL.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string ZipCode { get; set; }
        public string strada { get; set; }
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
