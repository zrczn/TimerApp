using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerApp.CustomEventArgs;

namespace TimerApp.Services
{
    public class AlarmClockService
    {
        public void OnAlarmClockPerformed(object sender, AlarmClockArgs e)
        {
            DateTime now;
            bool flag = true;
            
            Console.WriteLine("AlarmClock Service Triggered: ");

            do
            {
                now = DateTime.Now;

                if(now == e.date)
                    flag = false;

            }while(flag);

            Console.WriteLine("Wake up!");
            Console.WriteLine("Redirecting to Main Menu...");
        }
    }
}
