using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventsCustom
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CallManager callManager = new CallManager();
            LandlinePhone landlinePhone = new LandlinePhone();
            MobilePhone mobilePhone = new MobilePhone();

            WeakEventManager<CallManager, NewCallEventArgs>.
                AddHandler(callManager, "NewCall", landlinePhone.PhoneCall);

            Console.WriteLine("========= Land Line Phone =============");
            callManager.Call("Cristian", "Viorel", 2);
            Console.WriteLine("=============================");

            WeakEventManager<CallManager, NewCallEventArgs>.
                AddHandler(callManager, "NewCall", mobilePhone.PhoneCall);
            Console.WriteLine("========= Mobile Phone , landline Phone=============");
            callManager.Call("Vitalie", "Andrei", 5);
            Console.WriteLine("=============================");

            // unregister subscribers
            WeakEventManager<CallManager, NewCallEventArgs>.RemoveHandler(callManager, "NewCall", landlinePhone.PhoneCall);
            WeakEventManager<CallManager, NewCallEventArgs>.RemoveHandler(callManager, "NewCall", mobilePhone.PhoneCall);

            Console.WriteLine("=========> After Unsubscribe<==========");
            callManager.Call("Vitalie", "Andrei", 5);

            Console.ReadKey();
        }
    }
  
}
