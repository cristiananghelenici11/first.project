using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronize
{
    public class SynchronizeDirectory
    {
        private string _sourceDirectory;
        private string _targetDirectory;

        public void Synchronize(string sourceDirectory, string targetDirectory)
        {
            _sourceDirectory = sourceDirectory;
            _targetDirectory = targetDirectory;

            Check();
            SyncFromSourceDirectory(null, null);
            DeleteFromTargetdirectory(null, null);
            SynchronizeContent(null, null);

            var watcher = new FileSystemWatcher(sourceDirectory)
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                               NotifyFilters.FileName | NotifyFilters.DirectoryName,
                IncludeSubdirectories = true
            };

            watcher.Changed += SynchronizeContent;
            watcher.Created += SyncFromSourceDirectory;
            watcher.Deleted += DeleteFromTargetdirectory;
            watcher.Renamed += SyncFromSourceDirectory;
           
            watcher.EnableRaisingEvents = true;

        }
        
        private void SyncFromSourceDirectory(object obj, FileSystemEventArgs e)
        {
            string tempPath;
            foreach (string source in Directory.GetDirectories(_sourceDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = source.Replace(_sourceDirectory, _targetDirectory);
                if (!Directory.Exists(tempPath))
                {
                    Console.WriteLine($"Copy {Path.GetFileName(tempPath)} to target directory========");
                    Directory.CreateDirectory(tempPath);
                }
            }

            foreach (string source in Directory.GetFiles(_sourceDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = source.Replace(_sourceDirectory, _targetDirectory);
                
                if (!File.Exists(tempPath))
                {
                    var final = false;
                    while (final == false)
                    {
                        try
                        {
                            Console.WriteLine($"Copy {Path.GetFileName(tempPath)} to target directory+++++++++++");
                            File.Copy(source, tempPath);
                            final = true;
                        }
                        catch
                        {
                            Thread.Sleep(1000);

                        }
                    }
                    
                }
            }

        }

        private void DeleteFromTargetdirectory(object obj, FileSystemEventArgs e)
        {
            string tempPath;
            foreach (string targetFile in Directory.GetFiles(_targetDirectory, "*", SearchOption.AllDirectories))
            {
                tempPath = targetFile.Replace(_targetDirectory, _sourceDirectory);
                if (!File.Exists(tempPath))
                {
                    Console.WriteLine($"Delete File from targetDirectory: ---> {Path.GetFileName(targetFile)} <---");
                    File.Delete(targetFile);
                }
            }

            foreach (string directory in Directory.GetDirectories(_targetDirectory))
            {
                tempPath = directory.Replace(_targetDirectory, _sourceDirectory);
                if (!Directory.Exists(tempPath))
                {
                    Console.WriteLine($"Delete Directory from targetDirectory: ---> {Path.GetFileName(directory)} <---");
                    Directory.Delete(directory, true);
                }
            }
        }

        private void Check()
        {
            Console.WriteLine("Check Directory");

            if (!Directory.Exists(_sourceDirectory))
            {
                Directory.CreateDirectory(_sourceDirectory);
                Console.WriteLine("Create source directory");
            }

            if (!Directory.Exists(_targetDirectory))
            {
                Directory.CreateDirectory(_targetDirectory);
                Console.WriteLine("Create target directory");
            }

        }

        private void SynchronizeContent(object obj, FileSystemEventArgs e)
        {

            foreach (string file in Directory.GetFiles(_sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string tempPath = file.Replace(_sourceDirectory, _targetDirectory);

                if (file.GetHashCode() != tempPath.GetHashCode())
                {
                    var check = false;
                    while (check == false)
                    {
                        try
                        {
                            File.Copy(file, tempPath, true);
                            check = true;
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
                
        }

    }
}
