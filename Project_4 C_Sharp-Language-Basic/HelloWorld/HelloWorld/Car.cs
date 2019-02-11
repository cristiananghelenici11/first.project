using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    static class Car
    {
        static Car()
        {
            Console.WriteLine("Static Car constructor");
        }

        public static void Start()
        {
            Console.WriteLine("method start");
        }

        public static void Accelerate()
        {
            Console.WriteLine("method stop");
        }

    }
}
