using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class Animal : IEnumerable
    {
        public string[] animal = {"Dog", "Cat", "Duck", "Horse", "Mouse"};

        public IEnumerator GetEnumerator()
        {
            return new AnimalEnumerator(animal);
        }
    }

}
