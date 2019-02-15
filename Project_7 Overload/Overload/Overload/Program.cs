using System;
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
            Angle a1 = new Angle(500);
            Angle a2 = new Angle(500);
            Angle a3 = a1 + a2;
            Angle a4 = a1 - a2;
            Angle a5 = a1 * a2;
            bool b = a4 != a5;
            Angle test = new Angle();
            test[0] = 11;
            test["minutes"] = 22;
            test[2] = 33;
            Console.WriteLine(test);

            Angle angle = new Angle(1000);
            Angle angle2 = new Angle(2, 3, 4);
            Console.WriteLine(angle);
            Console.WriteLine(angle2);
            Console.WriteLine(angle + angle2);
            Console.WriteLine("--------------");
            
            //Sort array witch Angle
            Angle[] arr = new Angle[]{a1, a2, a3, a4};
            Array.ForEach(arr, x => Console.WriteLine(x));
            Console.WriteLine("----Sorted array----"  );

            List<Angle> sortedList = arr.OrderBy(sl => sl.Minutes).ToList();
            Array.ForEach(arr, x => Console.WriteLine(x));
            ///
            // Sort List witch Angle
            Console.WriteLine("----Sorted List----");

            List<Angle> angles = AngleComparer.GenerateAngle(10).OrderBy(x => x.Degrees).ToList<Angle>();
            Array.ForEach(angles.ToArray(), x => Console.WriteLine(x));

            Console.ReadKey();
        }

    
    }
}
