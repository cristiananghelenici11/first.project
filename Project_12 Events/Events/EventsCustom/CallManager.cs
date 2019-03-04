using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCustom
{
    public class CallManager
    {
        public event EventHandler<NewCallEventArgs> NewCall;

        private void OnNewCall(NewCallEventArgs c)
        {
            NewCall?.Invoke(this, c);
        }

        public void Call(string from, string to, double time)
        {
            NewCallEventArgs c = new NewCallEventArgs(from, to, time);
            OnNewCall(c);

        }

    }
}
