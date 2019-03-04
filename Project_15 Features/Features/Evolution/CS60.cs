using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;

namespace Evolution
{
    [TestClass]
    public class CS60
    {
        private class Test
        {
            private string First { get; set; }
            private string Second { get; set; }
            private DateTimeOffset Age = DateTimeOffset.Now - TimeSpan.FromDays(365);

            public void Display() => WriteLine($"{First} <--> {Second}");

            public void DisplayPropertyNames() 
                => WriteLine($"{nameof(First)}, {nameof(Second)}, {nameof(Age)}, {nameof(Display)}");
        }

        [TestMethod]
        public void DictionaryInitializer()
        {
            var dictionary = new Dictionary<int, string>
            {
                [1] = "Monday",
                [2] = "Tuesday",
                [3] = "Wednesday",
                [4] = "Thursday"
            };
        }

        [TestMethod]
        public void ExceptionFilters()
        {
            try
            {
                //some instructions
            }
            catch (WebException e) when(e.Status == WebExceptionStatus.ConnectionClosed)
            {
                Exception ex = new Exception("sss", e);
                throw  ex;
                WriteLine(nameof(WebExceptionStatus.ConnectionClosed));
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.ConnectFailure)
            {
                WriteLine(nameof(WebExceptionStatus.ConnectFailure));
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.ProtocolError)
            {
                WriteLine(nameof(WebExceptionStatus.ProtocolError));
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.SendFailure)
            {
                WriteLine(nameof(WebExceptionStatus.SendFailure));
            }
        }

        [TestMethod]
        public void NullConditionalOperator()
        {
            int? a = null;
            int? b = 12;
            int? c = a ?? b ?? 20;

            Test test = null;
            Test test1;
            test1 = test ?? new Test();

            test?.Display();
            test1?.Display();
        }

    }

}
