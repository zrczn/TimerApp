using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerApp.CustomEventArgs;
using TimerApp.Services;

namespace TimerApp
{
    public class User
    {
        public event EventHandler<TimerEventArgs> TimerPerformed;

        TimerService tmrSrv = new();

        public void UnfollowEvents(TimerService tmrService)
        {
            TimerPerformed -= tmrService.OnTimerPerformed;
        }

        public void ExecuteTimerEvent(TimerEventArgs startsOn)
        {
            OnTimerPerformed(startsOn);
        }

        public bool CheckForEvents()
            => TimerPerformed != null;

        protected virtual void OnTimerPerformed(TimerEventArgs startsOn)
        {
            if(TimerPerformed != null)
            {
                TimerPerformed.Invoke(this, startsOn);
            }
        }

    }
}
