using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Employee
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public double Salary { get; set; }
        public Computer Computer { get; set; }

        public override string ToString()
        {
            return $"Name: {Name},\t ID: {Id},\t Salary: {Salary},\t Computer: {Computer},\t";
        }
    }
}
