using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreams
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            const string path1 = @"D:\Internship\Projects\Project_1 VCS\first.project\Project_13 FileStreams\FileStreams\Dir1";
            const string path2 = @"D:\Internship\Projects\Project_1 VCS\first.project\Project_13 FileStreams\FileStreams\Dir2";

            Console.WriteLine($"Synchronize {Path.GetFileName(path1)} and {Path.GetFileName(path2)}");
            SynchronizeDirectory.Synchronize(path1, path2);
            Console.ReadKey();
        }
    }
}
