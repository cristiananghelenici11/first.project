using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class NewMailEventArgs : EventArgs
    {
        public readonly String from, to, subject, body;

        public NewMailEventArgs(string from, string to, string subject, string body)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
    }
}
