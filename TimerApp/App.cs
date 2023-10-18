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
        TimerService tmrSrv;
        User usr = new User();
        TimerEventArgs tmrEvArgs;

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
                        usr.ExecuteTimerEvent(tmrEvArgs);

                    usr.UnfollowEvents(tmrSrv);

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
                            break;
                    }
                }
            } while (usrInput != "9");

        }
    }
}
