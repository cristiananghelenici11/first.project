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
        public readonly Sun Sun;

        public Planet(string nameOfSun)
        {
            Sun = Sun.GetInstance();
            Sun.Name = nameOfSun;
        }
    }
}
