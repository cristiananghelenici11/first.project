using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evolution
{
    [TestClass]
    public class CS30
    {
        [TestMethod]
        public void Var()
        {
            var x = 0;
            var date = DateTime.Now;
            var person = new Person();
        }

        [TestMethod]
        public void LinqAndLambda()
        {
            var _months = new[]
            {
                "January", "February", "March", "April", "May", "June", 
                "July", "August", "September", "October","November", "December"
            };

            string[] select = _months.OrderBy(x => x.Length).ToArray();
            Array.ForEach(select, Console.WriteLine);
        }

        [TestMethod]
        public void ExtensionMethod()
        {
            var person = new Person{Name = "Cristian"};
            person.PrintPerson();
        }
    }
}
