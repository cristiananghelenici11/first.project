using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class MobilePhone
    {
//        public MobilePhone(CallManager cm)
//        {
//            cm.NewCall += MobilePhoneCall;
//        }
        public void MobilePhoneCall(object sender, NewCallEventArgs c)
        {
            Console.WriteLine("\n Call to Mobile Phone");
            Console.WriteLine($"From: {c.From},\n   To: {c.To},\n   Subject: {c.Time},\n");
        }

//        public void Unregister(CallManager cm)
//        {
//            cm.NewCall -= MobilePhoneCall;
//        }
    }
}
