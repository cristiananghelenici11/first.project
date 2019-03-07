using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
    public class Sheep : Animal

    {
        public override string Run()
        {
            return "run sheep";
        }

        public override string Swim()
        {
            throw new Exception("Cat not swim");
        }
    }
}
