using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.CustomEventArgs
{
    public class TimerEventArgs : EventArgs
    {
        public int startsOn { get; set; }
    }
}
