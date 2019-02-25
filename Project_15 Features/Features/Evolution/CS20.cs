using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS20
    {
        [TestMethod]
        public void Generic()
        {
            var list = new List<int>{1, 2, 3, 4, 5};

            Action<int> deleg = Console.WriteLine;

            IEnumerable<string> str = new[] {"one", "two", "three"};
        }

        [TestMethod]
        public void PartialClass()
        {
            Console.WriteLine(Partial.Add(1, 2));
            Console.WriteLine(Partial.Multiply(2, 3));
        }

        [TestMethod]
        public void AnonymousMethod()
        {
            Action<string> delegAction = delegate(string str)
            {
                Console.WriteLine(str); 
            };

            Func<double, bool> delegFunc = delegate(double d)
            {
                return d > 100;
            };
        }

        [TestMethod]
        public void NullableType()
        {
            int? a = 10;
            a = 20;
            var b = 100;
            a = b;
            b = (int) a;

            TimeSpan? time = null;
        }

        [TestMethod]
        public void StaticClass()
        {
            Display.Print("Print in the static class");
        }

    }

    public static class Display
    {
        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }

    public static partial class Partial
    {
        public static int Add(int x, int y) => x + y;
    }

    public static partial class Partial
    {
        public static double Multiply(int x, int y) => x * y;

    }
}
