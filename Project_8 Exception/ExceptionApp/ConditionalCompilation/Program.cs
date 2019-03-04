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
            
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            var condition = 51;
            Debug.WriteLineIf(condition > 50, "This message for condition");

            Console.WriteLine(" Console.WriteLine");
            Debug.WriteLine("Debug writeline");
           
            Trace.WriteLine("Trace Information-Product Starting ");

#if TEST
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
