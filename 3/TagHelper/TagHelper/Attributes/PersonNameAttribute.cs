using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TagHelper.Attributes
{
    public class PersonNameAttribute : ValidationAttribute
    {
        private readonly string[] _names;
 
        public PersonNameAttribute(string[] names)
        {
            _names = names;
        }


        public override bool IsValid(object value)
        {
            return _names.Contains(value.ToString());
        }
    }
}