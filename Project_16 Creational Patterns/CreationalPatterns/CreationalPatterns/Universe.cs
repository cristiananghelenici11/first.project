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

        public string Name { get; set; }

        private Universe()
        {
        }

        public static Universe GetInstance()
        {
            return Lazy.Value;
        }
    }
}