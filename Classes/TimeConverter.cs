using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            //try parsing input time
            Time time;
            if (!Time.TryParse(aTime, out time))
                throw new Exception("Unknown time format");
            return GetLine1(time) + GetLine2(time) + GetLine3(time) + GetLine4(time) +
                   GetLine5(time);
        }

        private static string GetLine1(Time time)
        {
            return (time.Second % 2 == 0 ? "Y" : "O") + Environment.NewLine;
        }

        private static string GetLine2(Time time)
        {
            return new string('R', time.Hour / 5).PadRight(4,'O') + Environment.NewLine;
        }

        private static string GetLine3(Time time)
        {
            return new string('R', time.Hour % 5).PadRight(4, 'O') + Environment.NewLine;
        }

        private static string GetLine4(Time time)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 11; i++)
            {
                if (time.Minute / 5 > i)
                    sb.Append(i % 3 == 2 ? 'R' : 'Y');
                else
                {
                    sb.Append('O');
                }
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        private static string GetLine5(Time time)
        {
            return new string('Y', time.Minute % 5).PadRight(4, 'O');
        }


    }
}
