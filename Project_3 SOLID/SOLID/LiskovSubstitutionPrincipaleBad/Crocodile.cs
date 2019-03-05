using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
<<<<<<< HEAD
    public class Crocodile : Animal
=======
    class Crocodile : Animal
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
