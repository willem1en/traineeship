using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SprintTrackerNew.MVVM.Model
{
    public class Task
    {
        private static int IDcounter = 0;

        // Public properties
        public int TaskID { get; set; }
        public string Name { get; set; }
        public Log Log { get; set; }
        public bool Active { get; set; } = false;
        public bool Removable { get; set; } = true;

        // Methods

        public Task(string name)
        {
            Name = name;
            TaskID = IDcounter;
            IDcounter++;
            Log = new Log();
        }

        public override string ToString()
        {
            return Name;
        }

        public LogEvent Start()
        {
            Removable = false;
            var ev = Log.StartEvent();
            ev.TaskID = this.TaskID;
            Active = true;
            return ev;
        }

        public LogEvent Start(int minutes)
        {
            Removable = false;
            var ev = Log.StartEvent(minutes);
            ev.TaskID = this.TaskID;
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
            Log = new Log();
            Removable = true;
            Active = false;
        }

        public string GetElapsedTimeString()
        {
            var timePassed = Log.GetTotalPassedTime();
            return timePassed.ToString("h\\:mm\\:ss");
        }

    }
}
