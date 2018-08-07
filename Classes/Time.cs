using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    internal class Time
    {
        public int Hour { get; internal set; }
        public int Minute { get; internal set; }
        public int Second { get; internal set; }

        public static bool TryParse(string time, out Time parsedTime)
        {
            parsedTime = null;
            //split by :
            var timeParts = time.Split(':');
            if (timeParts.Length != 3)
                return false;
            //check hour is within 0-24 and an integer
            int hour;
            if (!int.TryParse(timeParts[0], out hour) || hour < 0 || hour > 24)
                return false;
            //check minutes are within 0-59 and an integer
            int minute;
            if (!int.TryParse(timeParts[1], out minute) || minute < 0 || minute > 59)
                return false;
            //check seconds are within 0-59 and an integer
            int second;
            if (!int.TryParse(timeParts[2], out second) || second < 0 || second > 59)
                return false;
            parsedTime = new Time() {Hour = hour, Minute = minute, Second = second};
            return true;
        }
    }
}
