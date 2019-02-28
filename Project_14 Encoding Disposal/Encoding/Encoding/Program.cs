using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposal
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var str = new StringBuilder();

            for (var i = 0; i < 10000; i++)
            {
                str.Append((char) i);
            }

            var saver = new Saver
            {
                Data = str.ToString()
            };

            saver.Save(@"D:\Internship\Projects\Project_1 VCS\first.project\Project_14 Encoding Disposal\Encoding\ascii.txt", Encoding.ASCII);
            saver.Save(@"D:\Internship\Projects\Project_1 VCS\first.project\Project_14 Encoding Disposal\Encoding\utf8.txt", Encoding.UTF8);
            saver.Save(@"D:\Internship\Projects\Project_1 VCS\first.project\Project_14 Encoding Disposal\Encoding\utf32.txt", Encoding.UTF32);
            saver.Save(@"D:\Internship\Projects\Project_1 VCS\first.project\Project_14 Encoding Disposal\Encoding\unicode.txt", Encoding.Unicode);

            string s = string.Format("it {0} , Day of week {1}", 1, DateTime.Now.DayOfWeek);
            Console.WriteLine(s);
            Console.WriteLine($"starts with :(it) {s.StartsWith("it")}");
            Console.WriteLine($"contains :(of) {s.Contains("of")}");
            Console.WriteLine(string.Compare("test1", "test"));

            Console.WriteLine("---> TimeSpan <---");
            //TimeSpan
            var timeSpan1 = new TimeSpan(10000000);
            var timeSpan2 = new TimeSpan(20, 2, 20, 12);
            Console.WriteLine($"{timeSpan1:g}");
            Console.WriteLine($"{timeSpan2:g}");
            Console.WriteLine(timeSpan1 + timeSpan2);

            Console.WriteLine("\n---> DateTime <---");
            //DateTime
            DateTime dateTime1 = DateTime.MaxValue;
            Console.WriteLine($"Max Value: {dateTime1:G}");
            Console.WriteLine($"DateTime UtcNow: {DateTime.UtcNow}");
            Console.WriteLine($"DateTime.Now: {DateTime.Now}");
            Console.WriteLine($"DateTime - TimeSpan: {DateTime.Now - timeSpan1}");
            Console.WriteLine($"DateTime - DateTime: {DateTime.Now - DateTime.Now}");

            Console.WriteLine("\n---> DateTimeOffset <---");
            //DateTimeOffset
            DateTimeOffset dateTimeOffset1 = DateTimeOffset.Now;
            Console.WriteLine($"Now: {dateTimeOffset1}");
            Console.WriteLine($"UtcNow: {DateTimeOffset.UtcNow}");
            Console.WriteLine($"DateTimeOffset - TimeSpan: {DateTimeOffset.Now - timeSpan2}");
            Console.WriteLine($"DateTimeOffset - DateTime: {DateTimeOffset.Now - new DateTime(2019, 1, 10)}");

            Console.WriteLine("\n---> TimeZone <---");
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones().Take(10))
            {
                Console.WriteLine(timeZone.DisplayName);
            }




            Console.ReadKey();
        }
    }
}
