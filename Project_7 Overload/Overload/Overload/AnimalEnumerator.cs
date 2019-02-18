using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    internal class AnimalEnumerator : IEnumerator
    {
        private readonly string[] _animals;
        private int _position = -1;

        public AnimalEnumerator(string[] animals)
        {
            _animals = animals;
        }

        public object Current
        {
            get
            {
                if (_position == -1 || _position >= _animals.Length)
                    throw new InvalidOperationException();

                return _animals[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position >= _animals.Length - 1) return false;
            _position++;

            return true;
        }

        public void Reset()
        {
            _position = -1;
        }

    }

}
