using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Fax
    {
//        public Fax(MailManager mm)
//        {
//            mm.NewMail += FaxMsg;
//        }

        public void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("\nFaxing mail message");
            Console.WriteLine($"From: {e.from},\n   To: {e.to},\n   Subject: {e.subject},\n   Body: {e.body}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }

    }
}
