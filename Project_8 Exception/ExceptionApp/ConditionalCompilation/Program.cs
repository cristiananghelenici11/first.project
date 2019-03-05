using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalCompilation
{
    public class Program
    {
        private static void Main(string[] args)
        {
<<<<<<< HEAD
            
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            var condition = 51;
=======
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            int condition = 51;
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            Debug.WriteLineIf(condition > 50, "This message for condition");

            Console.WriteLine(" Console.WriteLine");
            Debug.WriteLine("Debug writeline");
           
            Trace.WriteLine("Trace Information-Product Starting ");

<<<<<<< HEAD
#if TEST
=======
#if DEBUG
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            Console.WriteLine("if DEBUG");
#else
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Console.WriteLine("else Debug");
            Debug.WriteLine("Use Debug Class for Output");
#endif

            Console.ReadLine();
        }
    }
}
