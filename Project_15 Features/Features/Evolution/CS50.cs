using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS50
    {
        [TestMethod]
        public void AsynchronsMethod()
        {
            Console.WriteLine("Start");
            Calculate();
            Console.WriteLine("Stop");
        }

        public async void Calculate()
        {
            Console.WriteLine("Start Add");
            Console.WriteLine(await Add(23));
            Console.WriteLine("Stop Add");
        }

        private Task<int> Add(int i)
        {
            return Task.Run(async () =>
            {
                await Task.Delay(2000);
                return i + i;
            });
        }
    }
}
