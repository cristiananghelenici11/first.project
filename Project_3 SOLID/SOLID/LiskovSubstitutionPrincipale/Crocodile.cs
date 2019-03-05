using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
<<<<<<< HEAD
    public class Crocodile : IRun, ISwim
=======
    class Crocodile : IRun, ISwim
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

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
