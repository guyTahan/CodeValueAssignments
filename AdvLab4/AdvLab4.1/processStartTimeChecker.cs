using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLab4._1
{
    class processStartTimeChecker
    {
        public bool CheckIfYouCanAccessRunTime(Process p)
        {
            try
            {
                var time = p.StartTime;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }



            return true;
        }
    }
}
