using System;
using System.Collections.Generic;
using System.Text;

namespace Evolution
{
    public class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
