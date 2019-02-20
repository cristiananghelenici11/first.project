using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionApp
{
    public class InvalidAge : Exception
    {
        public InvalidAge(string message) : base(message)
        {
            
        }
    }
}
