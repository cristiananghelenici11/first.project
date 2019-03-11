using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Professor : IObserver
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public long ID { get; }
        public string Discipline { get; set; }

        public void Update(string news)
        {
            Console.WriteLine($"{ToString()}, News{news}");
        }

        public override string ToString()
        {
            return $"Professor: {FirstName}, {LasttName}, ID: {ID}, Disciplina: {Discipline}";
        }
    }
}
