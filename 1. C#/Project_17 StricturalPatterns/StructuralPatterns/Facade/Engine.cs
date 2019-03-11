using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facade
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Check Fuel");
            Thread.Sleep(1000);
            Console.WriteLine("Start Engine");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Engine");
        }
    }
}
