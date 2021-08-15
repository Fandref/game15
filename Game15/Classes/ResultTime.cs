using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public struct ResultTime
    {

        private int _minutes;
        private int _seconds;
        private int _miliseconds;

        public int Minutes
        {
            get {
                return _minutes;
            }
            set
            {
                _minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return _seconds;
            }

            set
            {
                if (value > 60)
                {
                    Minutes += value / 60;
                    _seconds = value % 60;
                }
                else
                {
                    _seconds = value;
                }
                
            }

        }

        public int Miliseconds
        {
            get
            {
                return _miliseconds;
            }

            set
            {
                if (value > 1000)
                {
                    Seconds += value / 1000;
                    _miliseconds = value % 1000;
                }
                else
                    _miliseconds = value;
            }
            
        }
            public ResultTime(int minutes, int seconds, int miliseconds)
        {
            _miliseconds = miliseconds;
            _seconds = seconds;
            _minutes = minutes;

            if (miliseconds > 1000)
            {
                _seconds += miliseconds / 1000;
                _miliseconds = miliseconds % 1000;
            }

            if (seconds > 60)
            {
                _minutes += seconds / 60;
                _seconds = seconds % 60;
                
            }
            

        }

        public static bool operator >(ResultTime time1, ResultTime time2)
        {
            if(time1.Minutes > time2.Minutes)
            {
                return true;
            }
            else if(time1.Minutes == time2.Minutes)
            {
                if(time1.Seconds > time2.Seconds)
                {
                    return true;
                }
                else if(time1.Seconds == time2.Seconds)
                {
                    if (time1.Miliseconds > time2.Miliseconds)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator <(ResultTime time1, ResultTime time2)
        {
            if (time1.Minutes < time2.Minutes)
            {
                return true;
            }
            else if (time1.Minutes == time2.Minutes)
            {
                if (time1.Seconds < time2.Seconds)
                {
                    return true;
                }
                else if (time1.Seconds == time2.Seconds)
                {
                    if (time1.Miliseconds < time2.Miliseconds)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (_miliseconds == 0 && _seconds == 0 && _minutes == 0)
                return true;
            return false;
        }


    }
}
