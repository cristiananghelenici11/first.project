using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class MaternityHome
    {

        public IEnumerable<Person> GenerateNewPerson(int numberOfPerson)
        {
            var persons = new List<Person>();
            var rnd = new Random();

            for (var i = 1; i < numberOfPerson; i++)
            {
               persons.Add(PersonFactory.CreateNewPerson("Anghelenici", "Cristian",
                   rnd.Next(1000000, 9000000), rnd.Next(0, 150), i, i ));
            }
            return persons;
        }

        public IEnumerable<Person> GenerateChildPerson(int numberOfPerson)
        {
            var persons = new List<Person>();
            var rnd = new Random();

            for (var i = 1; i < numberOfPerson; i++)
            {
               persons.Add(PersonFactory.CreateChildPerson("Anghelenici", "Cristian",
                   rnd.Next(1000000, 9000000), rnd.Next(0, 11), i, i ));
            }
            return persons;
        }

        public IEnumerable<Person> GenerateBigPerson(int numberOfPerson)
        {
            var persons = new List<Person>();
            var rnd = new Random();

            for (var i = 1; i < numberOfPerson; i++)
            {
               persons.Add(PersonFactory.CreateBigPerson("Anghelenici", "Cristian", 
                   rnd.Next(1000000, 9000000), rnd.Next(18, 100), i + 100, i + 190 ));
            }
            return persons;
        }

    }
}
