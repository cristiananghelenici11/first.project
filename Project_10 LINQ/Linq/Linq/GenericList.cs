using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class GenericList<T> : IEnumerable<T>
    {
        private List<T> _items;

        public int Capacity
        {
            get  => _items.Capacity; 
            set => _items.Capacity = value;
        }

        public int Count => _items.Count;

        public GenericList()
        {
            _items = new List<T>();
        }

        public GenericList(int size)
        {
            _items = new List<T>(size);
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> item)
        {
            _items.AddRange(item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public void Remove(int index)
        {
            _items.RemoveAt(index);
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T value)
        {
            _items.Insert(index, value);
        }

        public void Sort(IComparer<T> comparer)
        {
            _items.Sort(comparer);
        }

        public void Sort()
        {
            _items.Sort();
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
    }
}
