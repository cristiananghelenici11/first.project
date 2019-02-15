using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a1 = new Angle(50);
            Angle a2 = new Angle(50);
            Console.WriteLine(a1 + a2);
            Console.WriteLine(a1 - a2);
            Console.WriteLine(a1 * a2);
            Console.WriteLine(a1 / a2);

            Angle index = new Angle();
            index[0] = 11;
            index["minutes"] = 22;
            index[2] = 33;
            Console.WriteLine(index);

            Angle angle = new Angle(1, 2, 3);
            angle = new Angle(100, 0);
            angle = new Angle(100);
            Console.WriteLine("--------------");
            
            // Sort List  Angle
            Console.WriteLine("\nSorted List (seconds)");
            List<Angle> angles = Angle.GenerateAngle(4).OrderBy(x => x.Seconds).ToList();
            Array.ForEach(angles.ToArray(), x => Console.WriteLine(x));

            // clone
            Angle firstCopy = new Angle(10);
            Angle cloneCopy = (Angle)firstCopy.Clone();

            // IComparable , CompareTo
            Angle[] angles2 = Angle.GenerateAngle(4).ToArray();
            Console.WriteLine("\nIComparable CompareTo (degrees)");
            Array.Sort(angles2);
            Array.ForEach(angles2.ToArray(), x => Console.WriteLine(x));

            //IComparer
            Angle[] angles3 = Angle.GenerateAngle(4).ToArray();
            Console.WriteLine("\nComparer (minutes)");
            Array.Sort(angles3, new AngleComparer());   
            Array.ForEach(angles3.ToArray(), x => Console.WriteLine(x));

            //Ienumerable
            Animal animal = new Animal();
            Console.WriteLine("\nIEnumerable animals");
            foreach(var a in animal)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }

    }
}
