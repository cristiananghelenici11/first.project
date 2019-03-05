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

<<<<<<< HEAD
<<<<<<< HEAD
        private void OnNewCall(NewCallEventArgs c)
=======
        public void OnNewCall(NewCallEventArgs c)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
        public void OnNewCall(NewCallEventArgs c)
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
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
