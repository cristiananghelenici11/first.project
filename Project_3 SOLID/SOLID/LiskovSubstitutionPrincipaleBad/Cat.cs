using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    public class Cat : Animal
    {
        public override string Run()
        {
            return "run cat";
        }

        public override string Swim()
        {
            throw new Exception("Cat not swim");
        }
    }
}
