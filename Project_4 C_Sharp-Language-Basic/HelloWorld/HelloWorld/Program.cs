using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static int t;
        delegate void Message();
        static void Main(string[] args)
        {
            //value type
            int x = 3;
            double y = 2;
            double z = 4;
            char c = 'a';
            double result = 0;

            // reference types
            string name = "Cristian";
            Vehicle vehicle = new Vehicle{ Mark = "BMW", Model = "i8" };
            Message mes;
            object obj = x;

            // use static method
            Vehicle.CalculateDistance(100, 450);

            //a method for each type of parameter modifier 
            //by value
            Add(x, y);

            // out modifier
            Sqrt(4, out result);
            Console.WriteLine($"out modifier {y}");

            // ref modifier
            Pow(ref y, ref z);
            Console.WriteLine($"y = {y}, z = {z}");

            // boxing, unboxing
            double value = 100;
            Unboxing(value);

            //Thread
            for (int i = 0; i < 2; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Thread " + i.ToString();
                myThread.Start();
                Thread.Sleep(1000);
            }

            Thread t1 = new Thread(Car.Start);
            Thread t2 = new Thread(Car.Accelerate);

            t1.Start();
            t2.Start();

            //static constructor
            //Car.Start();


            Console.ReadKey();
        }





        public static void Add(int a, double b)
        {
            Console.WriteLine(a + b);
        }

        public static void Sqrt(int number, out double result)
        {
            result = Math.Sqrt(number);
        }

        static void Pow (ref double y, ref double z)
        {
            y = y * y;
            z = z * z;
        }

        public static void Unboxing(object obj)
        {
            Console.WriteLine($"Argument type: {obj.GetType()} (boxed)");
            //int b = a + 4; //compilation error, object + int
            double t = (double)obj;
            Console.WriteLine($"Type: {t.GetType()} (unboxed)");
        }

        public static void Count()
        {
            t = 1;
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, t);
                t++;
                Thread.Sleep(100);
            }
        }

    }
}
