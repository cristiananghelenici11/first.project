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
<<<<<<< HEAD
            var callManager = new CallManager();

            var landlinePhone = new LandlinePhone();
            var mobilePhone = new MobilePhone();
            var satellitePhone = new SatellitePhone();
=======
            CallManager callManager = new CallManager();

            LandlinePhone landlinePhone = new LandlinePhone();
            MobilePhone mobilePhone = new MobilePhone();
            SatellitePhone satellitePhone = new SatellitePhone();
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355

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
