using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class LandlinePhone
    {
        public void LandlinePhoneCall(object sender, NewCallEventArgs c)
        {
            Console.WriteLine("\nCall to Landline Phone");
            Console.WriteLine($"From: {c.From},\n   To: {c.To},\n   Time: {c.Time},\n");
        }
    }
}
