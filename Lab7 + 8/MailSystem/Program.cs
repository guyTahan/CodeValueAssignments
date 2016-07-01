using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            manager.MailArrived += Manager_MailArrived;
            manager.SimulateMailArrived();

            System.Threading.Timer timer;
            timer = new System.Threading.Timer(new TimerCallback(manager.SimulateMailArrived), null, 0, 1000);
            Console.ReadLine();

        }

        private static void Manager_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine(e.Title);
            Console.WriteLine(e.Body);
        }
    }
}
