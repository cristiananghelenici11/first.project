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

        public virtual void OnNewCall(NewCallEventArgs c)
        {
            if (NewCall != null)
            {
                NewCall(this, c);
            }
        }

        public void Call(string from, string to, double time)
        {
            NewCallEventArgs c = new NewCallEventArgs(from, to, time);
            OnNewCall(c);

        }

    }
}
