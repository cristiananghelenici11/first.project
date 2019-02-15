using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    internal class AngleComparer : IComparer<Angle>
    {
        public int Compare(Angle x, Angle y)
        {
            if(ReferenceEquals(x, null)) throw new NullReferenceException();
            return x.Minutes.CompareTo(y.Minutes);
        }
    }
}
