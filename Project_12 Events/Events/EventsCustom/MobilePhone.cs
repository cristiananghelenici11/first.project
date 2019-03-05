using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class MobilePhone
    {
<<<<<<< HEAD
<<<<<<< HEAD
//        public MobilePhone(CallManager cm)
//        {
//            cm.NewCall += MobilePhoneCall;
//        }
        public void MobilePhoneCall(object sende, NewCallEventArgs c)
=======
        public void MobilePhoneCall(object sender, NewCallEventArgs c)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
        public void MobilePhoneCall(object sender, NewCallEventArgs c)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        {
            Console.WriteLine("\n Call to Mobile Phone");
            Console.WriteLine($"From: {c.From},\n   To: {c.To},\n   Subject: {c.Time},\n");
        }
<<<<<<< HEAD
<<<<<<< HEAD

//        public void Unregister(CallManager cm)
//        {
//            cm.NewCall -= MobilePhoneCall;
//        }
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
    }
}
