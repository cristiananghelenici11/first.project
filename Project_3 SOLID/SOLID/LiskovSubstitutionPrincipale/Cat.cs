using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    class Cat : IRun
    {
        public string Run()
        {
            return "run cat";
        }
    }
}
