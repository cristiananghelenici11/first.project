using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS70
    {
        [TestMethod]
        public void OutVariables()
        {
            Console.WriteLine(int.TryParse("13", out int result1) ? result1 : 0);

            double.TryParse("1.3", out double result2);
            Console.WriteLine(result2);
        }

        [TestMethod]
        public void PatternMatching()
        {
            object obj = 34.9;

            if (obj is double d)
            {
                Console.WriteLine(d);
            }

            switch (obj)
            {
                case double value when (Math.Abs(value - 32.9) < 0.1):
                    Console.WriteLine(value);
                    break;
                case double value2 :
                        Console.WriteLine(value2);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        [TestMethod]
        public void LocalFunctions()
        {
            double Multiply(int x, int y) => x * y;

            Console.WriteLine(Multiply(2, 3));

            foreach (int i in Iterators(new[] {1, 4, 2, 9}))
            {
                Console.WriteLine(i);
            }
        }

        private static IEnumerable<int> Iterators(int[] arr)
        {
            return Iterator();

            IEnumerable<int> Iterator()
            {
                foreach (int a in arr)
                {
                    yield return a;
                }
            }
        }

        [TestMethod]
        public void RefLocalsAndReturns()
        {
            var arr = new[] {1, 2, 3, 4, 5};

            ref int elem = ref TestRef(arr);

            elem = 67;

            Array.ForEach(arr, Console.WriteLine);

        }
        private static ref int TestRef(int[] arr)
        {
            return ref arr[0];
        }

        public class TestBodyExpression
        {
            private int _value;
            public int Value
            {
                get => _value;
                set => _value = value;
            }

            public TestBodyExpression() => Value = 45;

            public string Exept() => throw new ArgumentException();
        }

        [TestMethod]
        public void Tuples()
        {
            (int, string) number = Number();
            (string, string, int) person = Person();
            (string firstName, string lastName, int Age) person2 = Person();
            Console.WriteLine(number);
            Console.WriteLine(person);
        }

        private static (int, string) Number()
        {
            const int n = 1;
            const string str = "one";

            return (n, str);
        }

        private (string, string, int) Person() => ("Anghelenici", "Cristian", 23);

        [TestMethod]
        public void Test()
        {

            DoSomething(null);
        }

        public static void DoSomething(string newName)         
        {
            if (newName == null)
            {
                throw new Exception(nameof(newName) + " is null");         
            }
        }
    }
}
