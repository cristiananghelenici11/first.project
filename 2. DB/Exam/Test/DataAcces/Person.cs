using System.Collections;
using System.Collections.Generic;

namespace DataAcces
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}