using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class CellPhone
    {
//        public CellPhone(MailManager mm)
//        {
//            mm.NewMail += PhoneMsg;
//        }

        public void PhoneMsg(Object sender, NewMailEventArgs e)
        {
            Console.WriteLine("\nSend mail message to cellPhone");
            Console.WriteLine($"From: {e.from},\n   To: {e.to},\n   Subject: {e.subject},\n   Body: {e.body}");
        }
    }
}
