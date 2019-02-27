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
        private List<Planet>_planets = new List<Planet>();

        public void CreatePlanet(Planet planet)
        {
            _planets.Add(planet);
        }
    }
}
