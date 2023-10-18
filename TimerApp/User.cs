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
        public event EventHandler<AlarmClockArgs> AlarmClockPerformed;

        TimerService tmrSrv = new();
        AlarmClockService alarmSrv = new();

        public void UnfollowEvents()
        {
            if(TimerPerformed != null)
                TimerPerformed -= tmrSrv.OnTimerPerformed;
            if(AlarmClockPerformed != null)
                AlarmClockPerformed -= alarmSrv.OnAlarmClockPerformed;
        }

        public void ExecuteTimerEvent(TimerEventArgs startsOn)
        {
            OnTimerPerformed(startsOn);
        }

        public void ExecuteAlarmClockEvent(AlarmClockArgs args)
        {
            OnAlarmClockPerformed(args);
        }

        public bool CheckForEvents()
            => TimerPerformed != null || AlarmClockPerformed != null;

        protected virtual void OnTimerPerformed(TimerEventArgs startsOn)
        {
            if(TimerPerformed != null)
                TimerPerformed.Invoke(this, startsOn);
        }

        protected virtual void OnAlarmClockPerformed(AlarmClockArgs alArg)
        {
            if(AlarmClockPerformed != null)
                AlarmClockPerformed.Invoke(this, alArg);
        }

    }
}
