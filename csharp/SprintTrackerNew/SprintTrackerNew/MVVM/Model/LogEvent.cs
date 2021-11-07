using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerNew.MVVM.Model
{
    public class LogEvent
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public int TaskID { get; set; }

        public LogEvent()
        {
            StartTime = DateTime.Now;
        }

        public LogEvent(int minutes)
        {
            var min = new TimeSpan(0, minutes, 0);
            StartTime = DateTime.Now.Subtract(min);
        }

        public void Stop()
        {
            EndTime = DateTime.Now;
        }

        public void Stop(int minutes)
        {
            var min = new TimeSpan(0, minutes, 0);
            EndTime = DateTime.Now.Subtract(min);
        }

        public TimeSpan GetTime()
        {
            if (EndTime == DateTime.MinValue)
            {
                return DateTime.Now - StartTime;
            } else {
                return EndTime - StartTime;
            }
        }
    }
}
