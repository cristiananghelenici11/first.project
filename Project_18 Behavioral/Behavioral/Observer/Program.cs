using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var university1 = new University{ Name = "UTM" };

<<<<<<< HEAD
<<<<<<< HEAD
            var students = new List<IObserver>
=======
            var _students = new List<IObserver>
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            var _students = new List<IObserver>
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            {
                new Student{ FirstName = "Anghelenici", LasttName = "Cristian", AverageOfGrades = 9.5},
                new Student{ FirstName = "Starciuc", LasttName = "Aurel", AverageOfGrades = 9.5},
                new Student{ FirstName = "Profir", LasttName = "Andrei", AverageOfGrades = 9.5},
                new Student{ FirstName = "Lutenco", LasttName = "Petru", AverageOfGrades = 9.5}
            };

            IObserver professor1 = new Professor
            {
                FirstName = "Rotaru", LasttName = "Ion", Discipline = "OOP"
            };
            
<<<<<<< HEAD
<<<<<<< HEAD
            university1.RegisterObserver(students);
=======
            university1.RegisterObserver(_students);
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            university1.RegisterObserver(_students);
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            university1.RegisterObserver(professor1);

            university1.NotifyObservers("Nu facem OOP");
            university1.RemoveObserver(professor1);
            university1.NotifyObservers("Facem OOP");

            Console.ReadKey();
        }
    }
}