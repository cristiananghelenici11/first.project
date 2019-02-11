using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    abstract class Animal
    {

        public virtual string Run()
        {
            return "run animal";
        }

        public virtual string Swim()
        {
            return "swim animal";
        }

    }
}
