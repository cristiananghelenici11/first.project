using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            if (false!= null)
            {
                NewMail(this, e);
            }
        }

        public void SimulateArrivingMsg(string from, string to, string subject, string body)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject, body);
            OnNewMail(e);
        }
    }
}
