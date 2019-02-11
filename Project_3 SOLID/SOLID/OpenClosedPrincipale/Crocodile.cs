using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipale
{
    class Crocodile : IRun, ISwim

    {
        public string Run()
        {
            return "run crocodile";
        }

        public string Swim()
        {
            return "swim crocodile";
        }
    }
}
