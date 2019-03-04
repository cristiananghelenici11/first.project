using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventsCustom
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var callManager = new CallManager();

            var landlinePhone = new LandlinePhone();
            var mobilePhone = new MobilePhone();
            var satellitePhone = new SatellitePhone();

            WeakEventManager<CallManager, NewCallEventArgs>.
                AddHandler(callManager, "NewCall", landlinePhone.LandlinePhoneCall);

            Console.WriteLine("========= Land Line Phone =============");
            callManager.Call("Cristian", "Viorel", 2);
            Console.WriteLine("=============================");

            WeakEventManager<CallManager, NewCallEventArgs>.
                AddHandler(callManager, "NewCall", mobilePhone.MobilePhoneCall);
            Console.WriteLine("========= Mobile Phone & landline Phone=============");
            callManager.Call("Vitalie", "Andrei", 5);
            Console.WriteLine("=============================");

            WeakEventManager<CallManager, NewCallEventArgs>.
                AddHandler(callManager, "NewCall", satellitePhone.SatelitePhoneCall);
            Console.WriteLine("========= Mobile Phone & landline Phone & satelite phone =============");
            callManager.Call("Vitalie", "Andrei", 5);
            Console.WriteLine("=============================");


            // unregister subscribers
            WeakEventManager<CallManager, NewCallEventArgs>.RemoveHandler(callManager, "NewCall", landlinePhone.LandlinePhoneCall);
            WeakEventManager<CallManager, NewCallEventArgs>.RemoveHandler(callManager, "NewCall", mobilePhone.MobilePhoneCall);

            Console.WriteLine("=========> After Unsubscribe landline, mobile phone<==========");
            callManager.Call("Tom", "Max", 3);

            Console.ReadKey();
        }

    }
  
}
