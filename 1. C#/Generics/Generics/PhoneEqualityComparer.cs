using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class PhoneEqualityComparer : IEqualityComparer<Phone>, IComparer<Phone>
    {
        public int Compare(Phone x, Phone y)
        {
            return string.Compare(x.Brand, y.Brand, StringComparison.Ordinal);
        }

        public bool Equals(Phone x, Phone y)
        {
            if(x == null) throw new NullReferenceException();
            return x.Brand == y.Brand && x.Model == y.Model;
        }

        public int GetHashCode(Phone obj)
        {
            return (obj.Brand + ";" + obj.Model).GetHashCode();
        }
    }
}
