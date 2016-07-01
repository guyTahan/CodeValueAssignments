using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
       public event EventHandler<MailArrivedEventArgs> MailArrived;

        virtual protected void OnMailArrived(MailArrivedEventArgs args)
        {
            EventHandler<MailArrivedEventArgs> handler = MailArrived;
            if (MailArrived != null)
            {
                MailArrived(this, args);
            }
        }

        public void SimulateMailArrived()
        {
            MailArrivedEventArgs args = new MailArrivedEventArgs("junk mail", "junk junk junk junk");
            OnMailArrived(args);
        }


        public void SimulateMailArrived(object x)
        {
            SimulateMailArrived();
        }

    }
}
//Create a simple method called SimulateMailArrived, that calls OnMailArrived with some dummy data.