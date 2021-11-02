using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTracker
{
    public class LogEvent
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } = DateTime.MinValue;

        public LogEvent()
        {
            StartTime = DateTime.Now;
        }

        public void Stop()
        {
            EndTime = DateTime.Now;
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
