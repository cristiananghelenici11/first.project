using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class AngleComparer : IComparer<Angle>
    {
        public static List<Angle> GenerateAngle(int lengthList)
        {
            Random random = new Random();
            List<Angle> angles = new List<Angle>();
            for(int i = 0; i < lengthList; i++)
            {
                angles.Add(new Angle(random.Next(0, 360), random.Next(0, 60), random.Next(0, 60)));
            }

            return angles;
        }

        public int Compare(Angle x, Angle y)
        {
            return x.Minutes.CompareTo(y.Minutes);
        }
    }
}
