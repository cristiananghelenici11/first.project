using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal static class Print
    {
        public static void Show(IEnumerable<int> array)
        {
            foreach (int arr in array)
            {
                Console.Write(arr + " ");

            }

            Console.WriteLine();
        }

        public static void Show(IEnumerable<Phone> phones)
        {
            foreach (Phone phone in phones)
            {
                Console.WriteLine(phone);

            }

        }        
        public static void Show(IEnumerable<Case> cases)
        {
            foreach (Case c in cases)
            {
                Console.Write(c);
                Console.Write("phone: ");

                foreach (Phone phone in c._phone)
                {
                    Console.Write(" " + phone.Brand);                    
                }

                Console.WriteLine();
            }

        }        
        
        public static void Show(Dictionary<Phone, Case> dictionary)
        {
            foreach (KeyValuePair<Phone, Case> d in dictionary)
            {
                Console.WriteLine(d);
            }

        }
    }
}
