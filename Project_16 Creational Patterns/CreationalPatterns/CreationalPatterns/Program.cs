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
            Universe universe1 = Universe.GetInstance();
            universe1.Name = "Universe";

            var superHero = new Hero { Name = "PlanetMan" };
            superHero.CreatePlanet(new Planet{NameOfPlanet = "Terra"});
            Console.WriteLine(universe1.Name);

            var jupiter = new Planet{NameOfPlanet = "Jupiter"};
            superHero.CreatePlanet(jupiter);
            Console.WriteLine($"Planet: {jupiter.NameOfPlanet}, Sun: {jupiter.Universe.Name}");

            Universe universe2 = Universe.GetInstance();
            universe2.Name = "Universe";

            Console.WriteLine($"Sun1 and Sun2 is equal: {universe1.Equals(universe2)}");
            Console.WriteLine($"{universe1.GetHashCode()}, \n{universe2.GetHashCode()}");
            Console.ReadKey();
        }
    }
}
