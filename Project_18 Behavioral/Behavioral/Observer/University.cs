using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class University : IObservable
    {
        public string Name { get; set; }
        private List<IObserver> _observers;

        public University()
        {
            _observers = new List<IObserver>();
        }
<<<<<<< HEAD

=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        public void NotifyObservers(string news)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(news);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
<<<<<<< HEAD
        }  
        
        public void RegisterObserver(IEnumerable<IObserver> observers)
=======
        }        
        public void RegisterObserver(List<IObserver> observers)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        {
            _observers.AddRange(observers);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine();
        }
<<<<<<< HEAD

=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    }
}
