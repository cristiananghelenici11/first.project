using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Person : IAcceptOperatii
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public void Accept(IOperatie operatie)
        {
            operatie.Visit(this);
        }
    }
}
