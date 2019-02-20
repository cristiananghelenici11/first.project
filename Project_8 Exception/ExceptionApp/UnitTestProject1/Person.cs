using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionApp
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void AddName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("First name and Last name is empty or null");
            }

            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAge(int age)
        {
            if (age <= 0 || age > 150) throw new InvalidAge("Age can not be less than 0 and greater than 150 (0 < age < 150)");
            Age = age;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}, Last Name {LastName}, Age: {Age}";
        }
    }
}
