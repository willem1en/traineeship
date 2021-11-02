using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SprintTracker
{

    class MainWindowViewModel
    {
        public ObservableCollection<Task> TaskList { get; set; }

        public LogEvent ActiveEvent;

        public void Load()
        {
            if (File.Exists("data.json"))
            {
                using (StreamReader r = new StreamReader("data.json"))
                {
                    string json = r.ReadToEnd();
                    List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(json);

                    TaskList = new ObservableCollection<Task>(tasks);
                }
            } else {
                TaskList = new ObservableCollection<Task>();
            }
        }

        public void Save()
        {
            using (StreamWriter file = File.CreateText("data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, TaskList);
            }
        }

        public void AddTask(Task tsk)
        {
            TaskList.Add(tsk);
        }

        public void DeleteTask(Task tsk)
        {
            TaskList.Remove(tsk);
        }

        public void StartTask(Task tsk)
        {
            if (ActiveEvent != null)
            {
                ActiveEvent.Stop();
            }

            ActiveEvent = tsk.Start();
        }

        public void StopTask(Task tsk)
        {
            ActiveEvent = null;
            tsk.Stop();
        }

        public void NewSprint()
        {
            TaskList.Clear();
        }
    }
    
}
