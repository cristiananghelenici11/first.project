


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testlib;
using testanotherlib;

namespace testapp
{
    class Program1
    {
        static void Main1(string[] args)
        {
            B objB = new B();
            C objC = new C();
            objC.ProtectedInternalDisplay();
            objC.InternalDisplay();
           
            
        }
    }
}