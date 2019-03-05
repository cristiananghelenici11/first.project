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
<<<<<<< HEAD
<<<<<<< HEAD
            const string path1 = @"D:\Internship\Projects\Project_1 VCS\first.project\Project_13 FileStreams\FileStreams\Dir1";
            const string path2 = @"D:\Internship\Projects\Project_1 VCS\first.project\Project_13 FileStreams\FileStreams\Dir2";
=======
            const string path1 = @"C:\Users\crist\Desktop\work\first.project\Project_13 FileStreams\FileStreams\Dir1";
            const string path2 = @"C:\Users\crist\Desktop\work\first.project\Project_13 FileStreams\FileStreams\Dir2";
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            const string path1 = @"C:\Users\crist\Desktop\work\first.project\Project_13 FileStreams\FileStreams\Dir1";
            const string path2 = @"C:\Users\crist\Desktop\work\first.project\Project_13 FileStreams\FileStreams\Dir2";
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            Console.WriteLine($"Synchronize {Path.GetFileName(path1)} and {Path.GetFileName(path2)}");
            SynchronizeDirectory.Synchronize(path1, path2);

<<<<<<< HEAD
<<<<<<< HEAD

           Console.WriteLine();
=======
            //string str = 
            Console.WriteLine();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            //string str = 
            Console.WriteLine();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

            Console.ReadKey();
        }
    }
}
