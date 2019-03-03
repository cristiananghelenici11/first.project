using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreams
{
    public static class SynchronizeDirectory
    {
        public static void Synchronize(string sourceDirectory, string targetDirectory)
        {
            Check(sourceDirectory, targetDirectory);
            DeleteFromTargetdirectory(sourceDirectory, targetDirectory);
            SyncFromSourceDirectory(sourceDirectory, targetDirectory);
            SynchronizeContent(sourceDirectory, targetDirectory);
            Console.WriteLine("\nsuccess synchronize");
        }

        private static void SyncFromSourceDirectory(string sourceDirectory, string targetDirectory)
        {
            string tempPath;
            foreach (string source in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = source.Replace(sourceDirectory, targetDirectory);
                if (!Directory.Exists(tempPath))
                {
                    Console.WriteLine($"Copy {Path.GetFileName(tempPath)} to target directory");
                    Directory.CreateDirectory(tempPath);
                }
            }

            foreach (string source in Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = source.Replace(sourceDirectory, targetDirectory);
                if (!File.Exists(tempPath))
                {
                    Console.WriteLine($"Copy {Path.GetFileName(tempPath)} to target directory");
                    File.Copy(source, tempPath);
                }
            }

        }

        private static void DeleteFromTargetdirectory(string sourceDirectory, string targetDirectory)
        {
            string tempPath;
            foreach (string targetFile in Directory.GetFiles(targetDirectory))
            {
                tempPath = targetFile.Replace(targetDirectory, sourceDirectory);
                if (!File.Exists(tempPath))
                {
                    Console.WriteLine($"Delete File from targetDirectory: ---> {Path.GetFileName(targetFile)} <---");
                    File.Delete(targetFile);
                }
            }

            foreach (string directory in Directory.GetDirectories(targetDirectory))
            {
                tempPath = directory.Replace(targetDirectory, sourceDirectory);
                if (!Directory.Exists(tempPath))
                {
                    Console.WriteLine($"Delete Directory from targetDirectory: ---> {Path.GetFileName(directory)} <---");
                    Directory.Delete(directory, true);
                }
            }

        }

        private static void Check(string sourceDirectory, string targetDirectory)
        {
            Console.WriteLine("Check Directory");

            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
                Console.WriteLine("Create source directory");
            }

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
                Console.WriteLine("Create target directory");
            }

        }

        private static async void SynchronizeContent(string sourceDirectory, string targetDirectory)
        {
            string[] fileExtension = { ".txt", ".doc", ".docx", ".html", ".css" };

            foreach (string file in Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string tempPath = file.Replace(sourceDirectory, targetDirectory);
                if (fileExtension.Contains(Path.GetExtension(file)))
                {
                    var stringBuilder1 = new StringBuilder();
                    var stringBuilder2 = new StringBuilder();
                    string tempLine;

                    using (var streamReader = new StreamReader(file))
                    {
                        while ((tempLine = streamReader.ReadLine()) != null)
                        {
                            await Task.Run(() => stringBuilder1.Append(tempLine + Environment.NewLine));
                        }
                    }

                    using (var streamReader = new StreamReader(tempPath))
                    {
                        while ((tempLine = streamReader.ReadLine()) != null)
                        {
                            await Task.Run(() => stringBuilder2.Append(tempLine + Environment.NewLine));
                        }
                    }

                    if (stringBuilder1.Equals(stringBuilder2)) continue;
                    using (var streamWriter = new StreamWriter( tempPath, false, Encoding.Default))
                    {
                        await Task.Run(() => streamWriter.WriteLine((stringBuilder1)));
                    }
                }
                else
                {
                    if (file.GetHashCode() != tempPath.GetHashCode())
                    {
                        File.Copy(file, tempPath, true);
                    }
                }
            }
        }
    }
}
