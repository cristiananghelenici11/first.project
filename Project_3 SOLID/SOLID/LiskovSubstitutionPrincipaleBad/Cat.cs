using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipaleBad
{
<<<<<<< HEAD
    public class Cat : Animal
=======
    class Cat : Animal
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    {
        public override string Run()
        {
            return "run cat";
        }

        public override string Swim()
        {
<<<<<<< HEAD
            throw new Exception("Cat not swim");
=======
            throw new NotImplementedException();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        }
    }
}
