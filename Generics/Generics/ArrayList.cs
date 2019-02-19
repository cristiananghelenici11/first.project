using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
     public class ArrayList<T> : IList<T>
     {
        private List<T> _items;
        public T this[int index] 
        { 
            get => _items[index]; 
            set => _items[index] = value;
        }

        public int Capacity => _items?.Count ?? -1;

        public bool IsReadOnly { get; } = false;

        public int Count => _items?.Count ?? -1;

        public ArrayList(IEnumerable<T> items) => _items = new List<T>(items);

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _items.AddRange(items);
        }

        public void Clear()
        {
            _items = null;
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);

        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length > _items.Count) throw new ArgumentException($"Destination array was not long enough");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();

            for (var i = 0; i < Count; i++)
            {
                array[arrayIndex++] = _items[i];
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            Add(item);

            for (int i = Count - 1; i > index; i--)
            {
                Swap(i, i - 1);
            }

        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count) throw new ArgumentOutOfRangeException(nameof(firstIndex));
            if (secondIndex < 0 || secondIndex >= Count) throw new ArgumentOutOfRangeException(nameof(secondIndex));

            T temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) == -1) return false;

            RemoveAt(IndexOf(item));

            return true;
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                T item = _items[i];
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
