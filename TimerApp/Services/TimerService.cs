using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerApp.CustomEventArgs;
using TimerApp.ProgressBarr;

namespace TimerApp.Services
{
    public class TimerService
    {
        public void OnTimerPerformed(object source, TimerEventArgs e)
        {
            Console.WriteLine("Timer Service: Triggered");

            int numb = default;
            for (int i = 0; i < e.startsOn * 10; i++)
            {
                numb++;

                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            };

            Console.WriteLine("Seems like u reached time limit! Redirecting to Main menu...");
            Thread.Sleep(2000);
        }


    }
}
