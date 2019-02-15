using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var a1 = new Angle(50);
            var a2 = new Angle(50);
            Console.WriteLine(a1 + a2);
            Console.WriteLine(a1 - a2);
            Console.WriteLine(a1 * a2);
            Console.WriteLine(a1 / a2);
            Console.WriteLine(a1 == a2);

            var index = new Angle();
            index[0] = 11;
            index["minutes"] = 22;
            index[2] = 33;
            Console.WriteLine(index);

            var angle = new Angle(1, 2, 3);
            angle = new Angle(100, 0);
            angle = new Angle(100);
            Console.WriteLine("--------------");
            
            // Sort List  Angle
            Console.WriteLine("\nSorted List (seconds)");
            List<Angle> angles = GenerateAngle(4).OrderBy(x => x.Seconds).ToList();
            Array.ForEach(angles.ToArray(), Console.WriteLine);

            // clone
            var firstCopy = new Angle(10);
            var cloneCopy = (Angle)firstCopy.Clone();

            // IComparable , CompareTo
            Angle[] angles2 = GenerateAngle(4).ToArray();
            Console.WriteLine("\nIComparable CompareTo (degrees)");
            Array.Sort(angles2);
            Array.ForEach(angles2.ToArray(), Console.WriteLine);

            //IComparer
            Angle[] angles3 = GenerateAngle(4).ToArray();
            Console.WriteLine("\nComparer (minutes)");
            Array.Sort(angles3, new AngleComparer());   
            Array.ForEach(angles3.ToArray(), Console.WriteLine);

            //IEnumerable
            var animal = new Animal();
            Console.WriteLine("\nIEnumerable animals");
            foreach(object a in animal)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }

        private static List<Angle> GenerateAngle(int lengthList)
        {
            var random = new Random();
            var angles = new List<Angle>();
            for(var i = 0; i < lengthList; i++)
            {
                angles.Add(new Angle(random.Next(0, 360), random.Next(0, 60), random.Next(0, 60)));
            }

            return angles;
        }
    }
}
