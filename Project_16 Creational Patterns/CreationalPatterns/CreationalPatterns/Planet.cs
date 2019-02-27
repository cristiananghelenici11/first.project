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
        public readonly Universe universe;

        public Planet(string nameOfSun)
        {
            universe = Universe.GetInstance();
            universe.Name = nameOfSun;
        }
    }
}
