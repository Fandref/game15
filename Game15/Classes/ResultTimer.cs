using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1.Classes
{
    
 
    public class ResultTimer
    {

        
        private ResultTime time;

        public ResultTime Time => time;

        private bool status;
        public bool Status => status;

        public string Minutes {
            get
            {
                int minutes = time.Minutes;
                if (minutes < 10)
                {
                    return $"0{minutes}";
                }

                return minutes.ToString();
            }
        }

        public string Seconds
        {
            get
            {
                int seconds = time.Seconds;
                if (seconds < 10)
                {
                    return $"0{seconds}";
                }

                return seconds.ToString();
            }
        }

        public string Miliseconds
        {
            get
            {
                int miliseconds = time.Miliseconds;
                if (miliseconds < 10)
                {
                    return $"00{miliseconds}";
                }
                else if(miliseconds < 100)
                {
                    return $"0{miliseconds}";
                }

                return miliseconds.ToString();
            }
        }

        

        private DispatcherTimer interval;
        

        public ResultTimer()
        {
            Reset();
            status = false;
        }
        public ResultTimer(int minutes, int seconds, int miliseconds)
        {
            time = new ResultTime(minutes, seconds, miliseconds);

        }

        public void Reset()
        {
            time.Miliseconds = 0;
            time.Seconds = 0;
            time.Minutes = 0;
        }

        public void Start()
        {

            if (!status)
            {
                interval = new DispatcherTimer();
                interval.Tick += new EventHandler(Calculate);
                interval.Interval = new TimeSpan(0, 0, 0, 0, 1);
                interval.Start();
                status = true;
            }
            






        }

        public void Continue()
        {
            if (!status)
            {
                interval.IsEnabled = true;
                status = true;
            }
            
        }

        public void Stop()
        {
            if (status)
            {
                status = false;
                interval.IsEnabled = false;
            }
            
        }



        private void Calculate(object sender, EventArgs e)
        {

            time.Miliseconds += 17;
        }



    }
}
