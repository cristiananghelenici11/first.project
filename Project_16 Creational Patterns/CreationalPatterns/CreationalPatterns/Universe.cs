using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class Universe
    {
        private static readonly Lazy<Universe> lazy = 
            new Lazy<Universe>(() => new Universe());

        public string Name { get; set; }

        private Universe()
        {
        }

        public static Universe GetInstance()
        {
            return lazy.Value;
        }
    }
}