using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Person
    {
        private string FirstName { get; }
        private string LastName { get; }
        private double Id { get; }
        private int Age { get; }
        private double Weight { get; }
        private double Height { get; }

        public Person(string firstName, string lastName, double id, int age, double weight, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"First Name : {FirstName}, Last Name: {LastName}, " +
                   $"ID: {Id}, Age: {Age}, Weight: {Weight}, Height: {Height}";
        }
    }
}
