using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    public class Crocodile : Animal
    {
        public override string Run()
        {
            return "run crocodile";
        }

        public override string Swim()
        {
            return "swim crocodile";
        }
    }
}
