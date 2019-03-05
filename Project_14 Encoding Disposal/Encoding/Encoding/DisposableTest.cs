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
<<<<<<< HEAD
=======
            Console.WriteLine("Destructor");
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            Dispose();
        }
    }
}
