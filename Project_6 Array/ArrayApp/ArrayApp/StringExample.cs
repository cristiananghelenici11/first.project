
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    class StringExample
    {
        public static void StringBuilderGo()
        {
            //StringBuilder
            // se foloseste cu stringuri mare, e static 
            //Obiectul stringBuilde este un sir neschimbabil

            StringBuilder stringBuilder = new StringBuilder("StringBuilder");
            Console.WriteLine("length of string: {0}", stringBuilder.Length);
            Console.WriteLine("volumul string: {0}", stringBuilder.Capacity);
            
            StringBuilder sb = new StringBuilder("Denumire");
            Console.WriteLine("length of string: {0}", sb.Length); // 8
            Console.WriteLine("volumul string: {0}", sb.Capacity); // 16
 
            sb.Append("Internship");
            Console.WriteLine("length of string: {0}", sb.Length); // 28
            Console.WriteLine("volumul string: {0}", sb.Capacity); // 32
 
            sb.Append("c#");
            Console.WriteLine("length of string: {0}", sb.Length); // 20
            Console.WriteLine("volumul string: {0}", sb.Capacity); // 32

            StringBuilder sb2 = new StringBuilder("Hello World");
            sb2.Append("!!");
            sb2.Insert(7, "StringBuilder");
            Console.WriteLine(sb2);

            sb2.Replace("Hello", "World");
            Console.WriteLine(sb2);

            // stergem 13 simboluri, incepind cu 7
            sb.Remove(7, 13);
            Console.WriteLine(sb);

            // stringBuilder to string
            string s = sb2.ToString();
            Console.WriteLine(s);
        }

        public static void StringGo()
        {
            char[] ch = {'I', 'N', 'T', 'E', 'R', 'N', 'S', 'H', 'I', 'P'};
            string str1 = new String(ch);
            string str2 = new String('i', 10);
            string concatString = String.Concat(str1, str2);
            string insertString = concatString.Insert(11, " Insert ");
            string path = @"C:\ProgramData\Adobe\ARM\Reader_18.009.20044";

            Console.WriteLine($"{str1}\n {str2}\n{concatString}\n{insertString}\n{insertString.ToUpper()}\n{path}");

            // Split Join
            string str = "This is our Demo String";
            string[] arr1 = str.Split(' ');
            string rest = string.Join(" ", arr1.Skip(1));

            Console.WriteLine(rest);



        }
    }
}
