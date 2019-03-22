using System;
using System.Collections.Generic;
using System.Text;

namespace DomainStudent.Core
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    
        public string LastName { get; set; }

        List<Address> Address { get; set; }
    }
}
