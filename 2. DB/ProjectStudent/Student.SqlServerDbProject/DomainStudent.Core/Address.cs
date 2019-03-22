using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public Person Person { get; set; }
    }

}
