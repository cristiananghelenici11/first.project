using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class NewCallEventArgs : EventArgs
    {
        public string From { get; }
        public string To { get; }
        public double Time { get; }

        public NewCallEventArgs(string from, string to, double time)
        {
            From = from;
            To = to;
            Time = time;
        }
    }
}
