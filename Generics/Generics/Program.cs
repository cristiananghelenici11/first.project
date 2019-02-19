using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        private enum Brands
        {
            Apple, 
            Samsung,
            Xiaomi,
            Sony
        }

        private static void Main(string[] args)
        {
            var arr = new ArrayList<int>(new [] {1, 2, 3, 2});

            arr.Swap(0, 1);
            Print.Show(arr);
            arr.Insert(0, 100);
            Print.Show(arr);
            arr.Add(101);
            Print.Show(arr);
            Console.WriteLine($"first element {arr[1]}");
            Console.WriteLine($"first element to 81 : arr[1] = {arr[1] = 81}");

            Console.WriteLine($"Capacity: {arr.Capacity}");
            Console.WriteLine($"Count: {arr.Count}");

            var phone1 = new Phone(Brands.Samsung.ToString(), "A8", 2000, 32);
            var phone2 = new Phone(Brands.Samsung.ToString(), "S8", null, 128);
            var phone3 = new Phone(Brands.Apple.ToString(), "X", 3000, 256);
            var phone4 = new Phone(Brands.Sony.ToString(), "Z", 4000, null);
            var phone5 = new Phone(Brands.Xiaomi.ToString(), "Mi A2", 6000, 64);
            var phones = new List<Phone>{phone1, phone2, phone3, phone4, phone5};
            
            var case1 = new Case(5, "red", phone2);
            var case2 = new Case(6, "blue", phone3);
            var case3 = new Case(4, "white", phone4);
            var case4 = new Case(5, "black", phone5);
            case4.AddPhone(phone3);
            var cases = new List<Case>{case1, case2, case3, case4};

            Print.Show(phones);
            Print.Show(cases);

            var dictionary = new Dictionary<Phone, Case>
            {
                {phone1, case1}, {phone2, case2}, {phone3, case3}, {phone4, case4}
            };
            Print.Show(dictionary);

            // EQUALITY
            Console.WriteLine(dictionary.ContainsKey(phone1));

            //IComparer brand
            phones.Sort(new PhoneEqualityComparer());
            Print.Show(phones);

            //Generic Covariance and Contravariance

            Console.ReadKey();

        }
        
    }
}
