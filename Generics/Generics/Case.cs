using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Case
    {
        readonly double? _size;
        readonly string _color;
        public List<Phone> _phone = new List<Phone>();

        public Case(double? size, string color, List<Phone> phone)
        {
            _size = size;
            _color = color;
            _phone = phone;
        }
        public Case(double? size, string color, Phone phone)
        {
            _size = size;
            _color = color;
            _phone.Add(phone);
        }

        public Case(Phone phone)
        {
            _phone.Add(phone);
        }

        public void AddPhone(Phone phone)
        {
            _phone.Add(phone);
        }

        public override string ToString()
        {
            return $"Size: {_size},\t Color: {_color}\t";
        }
    }
}
