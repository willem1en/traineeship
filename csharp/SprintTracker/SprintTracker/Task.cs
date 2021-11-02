using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SprintTracker
{
    public class Task
    {
        // Public properties
        public string Name { get; set; }
        public Log Log { get; set; }
        public bool Active { get; set; } = false;

        // Methods

        public Task(string name)
        {
            Name = name;
            Log = new Log();
        }

        public override string ToString()
        {
            return Name;
        }

        public LogEvent Start()
        {
            var ev = Log.StartEvent();
            Active = true;
            return ev;
        }

        public void Stop()
        {
            Log.StopEvent();
            Active = false;
        }

        public void Reset()
        {
            //
        }

        public string GetElapsedTimeString()
        {
            var timePassed = Log.GetTotalPassedTime();
            return timePassed.ToString("h\\:mm\\:ss");
        }

    }
}
