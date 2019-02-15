using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class AnimalEnumerator : IEnumerator
    {
        public string[] animals;
        int position = -1;

        public AnimalEnumerator(string[] animals)
        {
            this.animals = animals;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= animals.Length)
                    throw new InvalidOperationException();
                return animals[position];
            }
        }

        public bool MoveNext()
        {
            if (position < animals.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }

}
