using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTracker
{
    public class Log
    {
        public List<LogEvent> LogEvents;

        public Log()
        {
            LogEvents = new List<LogEvent>();
        }

        public LogEvent StartEvent()
        {
            LogEvent ev = new LogEvent();
            LogEvents.Add(ev);
            return ev;
        }

        public void StopEvent()
        {
            LogEvents.Last().Stop();
        }

        public TimeSpan GetTotalPassedTime()
        {
            TimeSpan timePassed = new TimeSpan();

            foreach (LogEvent ev in LogEvents)
            {
                timePassed += ev.GetTime();
            }

            return timePassed;
        }
    }
}
