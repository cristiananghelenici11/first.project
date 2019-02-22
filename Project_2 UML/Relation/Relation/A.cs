using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testanotherlib
{
    public class A
    {
        internal void InternalDisplay()
        {
            Console.WriteLine("Internal Display Method.");
        }

        protected void ProtectedDisplay()
        {
            Console.WriteLine("Protected Display Method.");
        }

        protected internal void ProtectedInternalDisplay()
        {
            Console.WriteLine("ProtectedInternal Display Method.");
        }

        public void PublicDisplay()
        {
            Console.WriteLine("Public Display Method.");
        }
    }
}
