using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelper.Attributes;

namespace TagHelper.Models
{
    public class Person
    {
        [PersonName(new string[] {"Tom", "Sam", "Alice" }, ErrorMessage ="Недопустимое имя")]
        public string Name { get; set; }
 
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
