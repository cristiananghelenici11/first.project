using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposal
{
    public class DisposableTest : IDisposable
    {
        private Stream _stream;
        public void Dispose()
        {
            Console.WriteLine("Class DisposableTest method Dispose");
            _stream?.Dispose();
        }

        ~DisposableTest()
        {
            Console.WriteLine("Destructor");
            Dispose();
        }
    }
}
