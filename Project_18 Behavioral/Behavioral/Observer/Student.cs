using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Student : IObserver
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public long ID { get; }
        public double AverageOfGrades { get; set; }

        public void Update(string news)
        {
            Console.WriteLine($"{ToString()} , News: {news}");
        }

        public override string ToString()
        {
            return $"Studentul: {FirstName}, {LasttName}, ID: {ID}, AVG Grades {AverageOfGrades}";
        }
    }
}
