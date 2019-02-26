using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Singleton.text);
 
            Singleton2 singleton2 = Singleton2.GetInstance();
            Console.WriteLine(singleton2.Name);
            Console.ReadKey();
        }
    }

    public class Singleton
    {
        public static string text = "hello";
        public string Date { get; private set; }

        private Singleton()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly Singleton instance = new Singleton();
        }

    }

    public class Singleton2
    {
        private static readonly Lazy<Singleton2> lazy = 
            new Lazy<Singleton2>(() => new Singleton2());

        public string Name { get; private set; }

        private Singleton2()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static Singleton2 GetInstance()
        {
            return lazy.Value;
        }
    }

}
