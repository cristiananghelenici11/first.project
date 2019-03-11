using System;
using System.Windows;

using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("------");
//
//            MailManager mm = new MailManager();
//
//            Fax fax = new Fax(mm);
//            CellPhone pager = new CellPhone(mm);
//
//            mm.SimulateArrivingMsg("Google", "Me", "CV", "how are you");
//
//            fax.Unregister(mm);
//
//            mm.SimulateArrivingMsg("Amdaris", "Me", "ID", "check your account");
            ///////////////////
 

//            // Construct a MailPublisher object
//            MailManager mm2 = new MailManager();
//
//            // Construct a Fax object 
//            Fax fax2 = new Fax(mm2);
//
//            // Construct a CellPhone object 
//            CellPhone phone2 = new CellPhone(mm2);
//
//            //Register weak events by WeakEventManager
//            
//            WeakEventManager<MailManager, NewMailEventArgs>.
//                AddHandler(mm2, "SimulateArrivingMsg", fax2.FaxMsg);
//
//            //mm2.SimulateArrivingMsg("Google", "Me", "CV", "how are you");
//            
//            //fax2.Unregister(mm2);
//
//            WeakEventManager<MailManager, NewMailEventArgs>.
//                AddHandler(mm2, "NewMail", phone2.PhoneMsg);
//
//
//            //mm2.SimulateArrivingMsg("Google", "Me", "CV", "how are you");
//
//            // Unregister weak event for the Fax object by WeakEventManager
//            WeakEventManager<MailManager, NewMailEventArgs>.RemoveHandler(mm2, "NewMail", fax2.FaxMsg);



            // Construct a MailPublisher object
            MailManager mm = new MailManager();

            // Construct a Fax object 
            Fax fax = new Fax();

            // Construct a CellPhone object 
            CellPhone phone = new CellPhone();

            //Register weak events by WeakEventManager  fax
            Console.WriteLine("========= fax.msg=============");
            WeakEventManager<MailManager, NewMailEventArgs>.
                AddHandler(mm, "NewMail", fax.FaxMsg);
            mm.SimulateArrivingMsg("Google", "Me", "CV", "how are you");
            Console.WriteLine("=============================");

            Console.WriteLine("========= fax.msg, phone.msg=============");
            WeakEventManager<MailManager, NewMailEventArgs>.
                AddHandler(mm, "NewMail", phone.PhoneMsg);
       
            
            mm.SimulateArrivingMsg("Amdaris", "Me", "ID", "check your account");
            Console.WriteLine("=============================");





            // Unregister weak event for the Fax object by WeakEventManager
            WeakEventManager<MailManager, NewMailEventArgs>.
                RemoveHandler(mm, "NewMail", fax.FaxMsg);            
            
            WeakEventManager<MailManager, NewMailEventArgs>.
                RemoveHandler(mm, "NewMail", phone.PhoneMsg);



            Console.ReadKey();
        }

    }


}
