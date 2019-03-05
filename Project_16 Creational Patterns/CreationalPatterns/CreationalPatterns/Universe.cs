using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public sealed class Universe
    {
        private static readonly Lazy<Universe> Lazy = 
            new Lazy<Universe>(() => new Universe(), true);

<<<<<<< HEAD
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public static string Name { get; set; }
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
        public static string Name { get; set; }
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

        private Universe()
        {
        }

        public static Universe GetInstance()
        {
            return Lazy.Value;
        }
    }
}