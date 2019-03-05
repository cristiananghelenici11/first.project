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
        }  
        
        public void RegisterObserver(IEnumerable<IObserver> observers)
        {
            _observers.AddRange(observers);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine();
        }

    }
}
