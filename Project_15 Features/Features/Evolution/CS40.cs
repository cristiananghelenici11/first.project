using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS40
    {
        [TestMethod]
        public void TestDynamic()
        {
            dynamic d = 8;
            Console.WriteLine(Add(d));
            d = "str";
            Console.WriteLine(d);

            dynamic list = new List<int> {1, 2, 5, 2, 4};

            foreach (dynamic l in list)
            {
                Console.WriteLine(l);
            }
        }

        private int Add(int d) => d + d;

        [TestMethod]
        public void NamedAndOptionalArguments()
        {
            DisplayValues(1, 2);

            DisplayValues(1, 2, 3, 4);

            DisplayValues(1, 2, 3, 4, 5, 6, 7, 7, 9);

            DisplayValues(1, 2, e: 2, d: 4);

            DisplayValues(a: 1, b: 2, e: 4, array: new[] {5, 6, 7});

        }

        private static void DisplayValues(int a, int b, int d = 0, int e = 1, params int[] array)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(d);
            Console.WriteLine(e);

            Array.ForEach(array, Console.WriteLine);
            Console.WriteLine("---> END <---");
        }
    }
}
