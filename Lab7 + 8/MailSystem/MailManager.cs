using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public delegate void EventHandler<MailArrivedEventArgs>(object sender, MailArrivedEventArgs e) where MailArrivedEventArgs : EventArgs;
    }
}
