using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreationalPatterns;

namespace Singleton
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Sun sun1 = Sun.GetInstance();
            sun1.Name = "Soare";

            var superHero = new Hero { Name = "PlanetMan" };
            superHero.CreatePlanet(new Planet("Soare1"){NameOfPlanet = "Tera"});
            Console.WriteLine(sun1.Name);

            var jupiter = new Planet("Lumina"){NameOfPlanet = "Jupiter"};
            superHero.CreatePlanet(jupiter);
            Console.WriteLine($"Planet: {jupiter.NameOfPlanet}, Sun: {jupiter.Sun.Name}");

            Sun sun2 = Sun.GetInstance();
            sun2.Name = "Soare2";

            Console.WriteLine($"Sun1 and Sun2 is equal: {sun1.Equals(sun2)}");
            Console.WriteLine($"{sun1.GetHashCode()}, \n{sun2.GetHashCode()}");
            Console.ReadKey();
        }
    }
}
