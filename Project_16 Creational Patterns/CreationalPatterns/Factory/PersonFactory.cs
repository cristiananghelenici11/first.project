using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class PersonFactory
    {
        public static Person CreateNewPerson(string firstName, string lastName, double id, int age, 
            double weight, double height )
        {
            CheckName(firstName, lastName);

            if (age <= 0 && weight <=0 && height <= 0) 
                throw new ArgumentOutOfRangeException("age, weight, height must be greater than 0");

            return new Person(firstName, lastName, id, age, weight, height);;
        }

        public static Person CreateChildPerson(string firstName, string lastName, double id, int age,
            double weight, double height)
        {
            CheckName(firstName, lastName);

            if (age < 0 && age > 11) 
                throw new ArgumentOutOfRangeException("Age of child must be 11 > age > 0");
            return new Person(firstName, lastName, id, age, weight, height);
        }

        public static Person CreateBigPerson(string firstName, string lastName, double id, int age,
            double weight, double height)
        {
            CheckName(firstName, lastName);

            if (age < 18 && weight > 100 && height > 195) 
                throw new ArgumentOutOfRangeException("Age of child must be 11 > age > 0");

            return new Person(firstName, lastName, id, age, weight, height);
        }

        public static Person CreateDriver(string firstName, string lastName, double id, int age,
            double weight, double height)
        {
            CheckName(firstName, lastName);

            if (age < 18) 
                throw new ArgumentOutOfRangeException("Age of child must be age > 18");

            return new Person(firstName, lastName, id, age, weight, height);
        }

        private static void CheckName(string firstName, string lastName)
        {
            firstName = string.IsNullOrEmpty(firstName)
                ? throw new ArgumentNullException("first Name is empty or null")
                : firstName;            
            
            lastName = string.IsNullOrEmpty(lastName)
                ? throw new ArgumentNullException("firstName is empty or null")
                : lastName; 
        }

    }
}
