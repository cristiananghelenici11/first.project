using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine($"DateTime - DateTime: {DateTime.Now + timeSpan1 - DateTime.Now}");

            Console.WriteLine("\n---> DateTimeOffset <---");
            //DateTimeOffset
            DateTimeOffset dateTimeOffset1 = DateTimeOffset.Now;
            Console.WriteLine($"Now: {dateTimeOffset1}");
            Console.WriteLine($"UtcNow: {DateTimeOffset.UtcNow}");
            Console.WriteLine($"DateTimeOffset - TimeSpan: {DateTimeOffset.Now - timeSpan2}");
            Console.WriteLine($"DateTimeOffset - DateTime: {DateTimeOffset.Now - new DateTime(2019, 1, 10)}");

            Console.WriteLine("\n---> TimeZone <---");
            //TimeZone
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones().Take(10))
            {
                Console.WriteLine(timeZone.DisplayName);
            }

            Console.WriteLine("\n---> CultureInfoo <---");
            //CultureInfo
            const double number = 237405.9476;
            Console.WriteLine($"CurrentCulture: {number:C}");
            Console.WriteLine($"InvariantCulture: {number.ToString("C", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Culture(en-GB): {number.ToString("C", new CultureInfo("en-GB"))}");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Console.WriteLine($"Culture(en-Ru):{number:C}");

            Console.WriteLine("\n---> IDisposable --->");
            //IDisposable
            var disposable = new DisposableTest();
            disposable.Dispose();

            using (var test = new DisposableTest())
            {
                Console.WriteLine("using");
            }

            //STORE DATETIME ON LOCAL FILE SYSTEM THEN READ IT AND PRINT IN CORRECT FORMAT FOR CURRENT USER LOCALE
            Console.WriteLine("\n---> DATETIME ON LOCAL FILE SYSTEM <---");

            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime}");

            var saver2 = new Saver
            {
                Data = dateTime.ToString(CultureInfo.CurrentCulture)
            };
            const string path = @"D:\Internship\Projects\Project_1 VCS\first.project\Project_14 Encoding Disposal\Encoding\dateTime.txt";

            saver2.Save(path);
            saver2.Read(path);

            Console.ReadKey();
        }
    }
}
