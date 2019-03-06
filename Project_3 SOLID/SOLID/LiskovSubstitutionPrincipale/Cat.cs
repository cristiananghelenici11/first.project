using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    public class Cat : IRun
    {
        public string Run()
        {
            return "run cat";
        }
    }
}
