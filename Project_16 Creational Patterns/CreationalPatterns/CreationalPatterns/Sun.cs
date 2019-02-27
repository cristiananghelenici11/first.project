using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class Sun
    {
        private static readonly Lazy<Sun> lazy = 
            new Lazy<Sun>(() => new Sun());

        public string Name { get; set; }

        private Sun()
        {
        }

        public static Sun GetInstance()
        {
            return lazy.Value;
        }
    }
}