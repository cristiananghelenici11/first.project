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
<<<<<<< HEAD
<<<<<<< HEAD
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate), encoding))
=======
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create), encoding))
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create), encoding))
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            {
                writer.Write(encoding.GetBytes(Data));
            }
        }
        public void Save(string fileName)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
=======
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
