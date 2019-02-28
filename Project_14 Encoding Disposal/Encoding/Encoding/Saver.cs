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
        public string Data { get; set; }

        public void Save(string fileName, Encoding encoding)
        {
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create), encoding))
            {
                writer.Write(encoding.GetBytes(Data));
            }
        }
    }
}
