using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.ProgressBarr
{
    public class ProgressBar
    {
        private int _defSymbol;
        private int _defLength;
        private int _timeToFinish;
        private int _currPercent;
        private float onePercentValue;

        private StringBuilder Components;


        private event EventHandler PercentRaised;

        public int TimeToFinish
        {
            init { _timeToFinish = value; }
        }

        public int DefSymbol
        {
            init { _defSymbol = value; }
        }

        public int DefLength
        {
            init { _defLength = value; }
        }

        public ProgressBar(char defSymbol,
            int defLength,
            int timeToFinish)
        {
            DefSymbol = defSymbol;
            DefLength = defLength;
            TimeToFinish = timeToFinish;

            _currPercent = default;
            Components = new($"[{new string('-', _defLength)}] {_currPercent}%");

            onePercentValue = 1 * timeToFinish / 100;
        }

        private void drawComponents()
        {
            // Calculate the number of dashes to represent the progress.
            int numDashes = (_currPercent * _defLength) / 100;

            // Generate the progress bar string.
            StringBuilder progressBar = new StringBuilder("[");
            progressBar.Append(new string('-', numDashes));
            progressBar.Append(new string(' ', _defLength - numDashes));
            progressBar.Append($"] {_currPercent}%");

            // Output the progress bar to the console.
            Console.WriteLine(progressBar);
        }

        public void RunProgressBar()
        {
            int currInt = default;

            do
            {
                if(onePercentValue == currInt)
                {
                    PercentRaised += c_PercentRaised;
                }

                currInt = default;

                OnPercentRaised();
                PercentRaised -= c_PercentRaised;

            } while (_currPercent != 100);
        }

        protected virtual void OnPercentRaised()
        {
            if(PercentRaised != null)
            {
                PercentRaised.Invoke(this, EventArgs.Empty);
            }
        }
        
        private void c_PercentRaised(object obj, EventArgs e)
        {
            drawComponents();
        }

    }
}
