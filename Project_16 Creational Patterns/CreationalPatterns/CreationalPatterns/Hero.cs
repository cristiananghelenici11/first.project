using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class Hero
    {
        public string Name { get; set; }
        public List<Planet> Planets = new List<Planet>();

        public void CreatePlanet(Planet planet)
        {
            Planets.Add(planet);
        }
    }
}
