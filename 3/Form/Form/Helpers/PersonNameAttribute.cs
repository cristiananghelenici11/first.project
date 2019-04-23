using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Form.Helpers
{
    public class PersonNameAttribute : ValidationAttribute
    {
        private string[] _names;

        public PersonNameAttribute(string[] names)
        {
            _names = names;
        }

        public override bool IsValid(object value)
        {
            if ( _names.ToList().Contains(value.ToString()))
            {    return true;}

            else
            {return false;}
        }
    }
}