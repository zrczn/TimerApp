using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerApp.CustomEventArgs;
using TimerApp.Services;

namespace TimerApp
{
    public class App
    {
        AlarmClockService alrmSrv;
        TimerService tmrSrv;
        User usr = new User();
        TimerEventArgs tmrEvArgs;
        AlarmClockArgs alrmArgs;

        short actionNumb;

        public void Run()
        {
            string usrInput = default;

            do
            {
                if (usr.CheckForEvents())
                {
                    UI.ChoosenAction();

                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key.ToString() == "Enter")
                    {
                        switch (actionNumb)
                        {
                            case 0:
                                usr.ExecuteTimerEvent(tmrEvArgs);
                                usr.TimerPerformed -= tmrSrv.OnTimerPerformed;
                                break;
                            case 1:
                                usr.ExecuteAlarmClockEvent(alrmArgs);
                                usr.AlarmClockPerformed -= alrmSrv.OnAlarmClockPerformed;
                                break;
                        }
                    }
                }

                Console.Clear();
                UI.MainMenu();

                usrInput = Console.ReadLine();
                short value = default;

                if (Int16.TryParse(usrInput, out value))
                {
                    switch (value)
                    {
                        case 1:
                            int timerStartsOn = UI.Minutnik();
                            tmrSrv = new();
                            tmrEvArgs = new();
                            usr.TimerPerformed += tmrSrv.OnTimerPerformed;
                            tmrEvArgs.startsOn = timerStartsOn;
                            actionNumb = 0;
                            break;
                        case 2:
                            DateTime date = UI.Budzik();
                            alrmSrv = new();
                            alrmArgs = new();
                            usr.AlarmClockPerformed += alrmSrv.OnAlarmClockPerformed;
                            alrmArgs.date = date;
                            actionNumb = 1;
                            break;
                    }
                }
            } while (usrInput != "9");

        }
    }
}
