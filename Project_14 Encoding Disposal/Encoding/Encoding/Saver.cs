using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposal
{
    public class Saver
    {
        public string Data { private get; set; }

        public void Save(string fileName, Encoding encoding)
        {
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create), encoding))
            {
                writer.Write(encoding.GetBytes(Data));
            }
        }
        public void Save(string fileName)
        {
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(Data);
            }
        }

        public void Read(string path)
        {
            string file = File.ReadAllText(path);
            Console.WriteLine($"{file}");
        }

    }
}
