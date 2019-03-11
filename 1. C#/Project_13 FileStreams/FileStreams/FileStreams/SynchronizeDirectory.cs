using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
            foreach (string targetFile in Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = targetFile.Replace(targetDirectory, sourceDirectory);
                if (!File.Exists(tempPath))
                {
                    Console.WriteLine($"Delete File from targetDirectory: ---> {Path.GetFileName(targetFile)} <---");
                    File.Delete(targetFile);
                }
            }

            foreach (string directory in Directory.GetDirectories(targetDirectory, "*", SearchOption.AllDirectories))
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

        private static void SynchronizeContent(string sourceDirectory, string targetDirectory)
        {
            foreach (string file in Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string tempPath = file.Replace(sourceDirectory, targetDirectory);

                using (var sourceFile = new FileStream(file, FileMode.Open))
                using (var targetFile = new FileStream(tempPath, FileMode.Open))
                {
                    bool isSame = VerifyFilesBinary(sourceFile, targetFile);
                    if (!isSame)
                    {
                        targetFile.Close();
                        File.Delete(tempPath);
                        File.Copy(file, tempPath);
                    }
                }

                //1
                bool VerifyFilesBinary(Stream sourceFileStream, Stream targetFileStream)
                {

                    if (sourceFileStream.Length != targetFileStream.Length)
                        return false;

                    var bufferSize = 1024 * 1024 * 1024;

                    var source = new byte[bufferSize];
                    var target = new byte[bufferSize];

                    var bytesRead = 1;

                    while (bytesRead != 0)
                    {
                        bytesRead = sourceFileStream.Read(source, 0, bufferSize);
                        targetFileStream.Read(target, 0, bufferSize);
                        if (!source.SequenceEqual(target))
                            return false;
                    }

                    return true;
                }

                //2
                bool VerifyFilesSHA256(Stream sourceFileStream, Stream targetFileStream)
                {
                    string s1, s2;
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        s1 = Convert.ToBase64String(sha256.ComputeHash(sourceFileStream));
                        s2 = Convert.ToBase64String(sha256.ComputeHash(targetFileStream));
                    }

                    return s1 == s2;
                }

                //3
                bool VerifyFilesMd5(Stream sourceFileStream, Stream targetFileStream)
                {
                    byte[] firstHash = MD5.Create().ComputeHash(sourceFileStream);
                    byte[] secondHash = MD5.Create().ComputeHash(targetFileStream);

                    return !firstHash.Where((t, i) => t != secondHash[i]).Any();
                }

            }
        }

    }
}
