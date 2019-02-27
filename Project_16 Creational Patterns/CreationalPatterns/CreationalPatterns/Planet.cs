using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class Planet
    {
        public string NameOfPlanet { get; set; }
        public readonly Universe Universe;

        public Planet(string nameOfSun)
        {
            Universe = Universe.GetInstance();
            Universe.Name = nameOfSun;
        }
    }
}
