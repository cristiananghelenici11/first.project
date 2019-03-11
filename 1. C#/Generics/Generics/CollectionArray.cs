using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
     public class CollectionArray<T> : IList<T>
     {
        private T[] _items;

        public int Count { get; private set; }
        public bool IsReadOnly { get; } = false;

        public int Capacity
        {
            get => _items. Length;
            set
            {
                if (value < Capacity) throw new ArgumentOutOfRangeException($"" +
                                                                            $"capacity was less than the current size" +
                                                                            $"" +
                                                                            $"");

                Capacity = value;

                Array.Resize(ref _items, Capacity);
            }
        }

        public CollectionArray()
        {
            _items = new T[4];
            Count = 0;
        }

        public CollectionArray(int capacity)
        {
            _items = new T[capacity];
            
            Count = 0;
        }

        public CollectionArray(IEnumerable<T> items)
        {
            List<T> list = items.ToList();

            _items = new T[list.Count];

            foreach (T t in list)
                _items[Count++] = t;
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(T item)
        {
            if (Count >= Capacity) Array.Resize(ref _items, Capacity * 2);

            _items[Count++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            List<T> itemsList = items.ToList();

            int count = itemsList.Count;

            if (Count + count > Capacity) Array.Resize(ref _items, Count + count);

            foreach (T item in itemsList)
            {
                _items[Count++] = item;
            }
        }

        public bool Remove(T item)
        {
            var temp = new List<T>(_items);
            temp.Remove(item);
            _items = temp.ToArray();
            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            var temp = new List<T>(_items);
            temp.RemoveAt(index);
            _items = temp.ToArray();
            Count --;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count) throw new ArgumentOutOfRangeException(nameof(firstIndex));
            if (secondIndex < 0 || secondIndex >= Count) throw new ArgumentOutOfRangeException(nameof(secondIndex));

            T temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        public void Clear()
        {
            _items = new T[4];
            
            Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            if (array.Length > _items.Length) throw new ArgumentException($"Destination array was not long enough");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();

            for (var i = 0; i < Count; i++)
            {
                array[arrayIndex++] = _items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item)) return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            _items[index] = item;
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
