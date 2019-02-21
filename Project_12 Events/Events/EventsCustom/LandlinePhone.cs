using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class LandlinePhone
    {
        public void PhoneCall(object sender, NewCallEventArgs c)
        {
            Console.WriteLine("\nCall to Landline Phone");
            Console.WriteLine($"From: {c.From},\n   To: {c.To},\n   Subject: {c.Time},\n");
        }
    }
}
