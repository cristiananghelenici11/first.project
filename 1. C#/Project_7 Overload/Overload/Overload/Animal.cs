using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    internal class Animal : IEnumerable
    {
        private readonly string[] _animal = {"Dog", "Cat", "Duck", "Horse", "Mouse"};

        public IEnumerator GetEnumerator()
        {
            //yield return animal[1];
            //yield return animal[2];
            return new AnimalEnumerator(_animal);
        }
    }
}
