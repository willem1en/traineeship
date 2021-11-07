using Newtonsoft.Json;
using SprintTrackerNew.MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace SprintTrackerNew.MVVM.ViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<Task> TaskList { get; set; } = new ObservableCollection<Task>();
        public LogEvent ActiveEvent { get; set; }
        private string savefile;
        public bool saved;

        //public ObservableCollection<string> SprintDays {
        //    get
        //    {
        //        var sprintDates = new List<DateTime>();
        //        var sprintDays = new ObservableCollection<string>();

        //        if (TaskList is not null)
        //        {
        //            foreach (Task tsk in TaskList)
        //            {
        //                foreach (LogEvent ev in tsk.Log.LogEvents)
        //                {
        //                    if (!sprintDates.Contains(ev.StartTime.Date))
        //                    {
        //                        sprintDates.Add(ev.StartTime.Date);
        //                    }
        //                }
        //            }

        //            foreach (DateTime date in sprintDates)
        //            {
        //                sprintDays.Add(date.ToLongDateString());
        //            }
        //        }

        //        return sprintDays;
        //    }
        //}

        public void Load()
        {
            saved = true;

            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (!Directory.Exists("savefiles"))
            {
                Directory.CreateDirectory("savefiles");
            }

            if (File.Exists("data/savefile.txt"))
            {
                savefile = File.ReadAllText("data/savefile.txt");
            }
            else
            {
                CreateNewSavefileFilename();
            }


            if (File.Exists(savefile))
            {
                using (StreamReader r = new StreamReader(savefile))
                {
                    string json = r.ReadToEnd();
                    List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(json);

                    TaskList = new ObservableCollection<Task>(tasks);
                }
            }
        }

        private void CreateNewSavefileFilename()
        {
            savefile = $"savefiles/sprint{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";
        }

        public async void Save()
        {
            if (TaskList.Count != 0)
            {
                using (StreamWriter file = File.CreateText(savefile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, TaskList);
                }

                await File.WriteAllTextAsync("data/savefile.txt", savefile);

                saved = true;
            }
        }

        public bool AddTask(Task t)
        {
            if (TaskList.Count < 20)
            {
                saved = false;
                TaskList.Add(t);
                return true;
            }
            
            return false;
        }

        public void DeleteTask(Task tsk)
        {
            saved = false;
            TaskList.Remove(tsk);
        }

        public void StartTask(Task tsk)
        {
            saved = false;

            if (ActiveEvent != null)
            {
                ActiveEvent.Stop();
            }

            ActiveEvent = tsk.Start();
        }

        public LogEvent StartTask(Task tsk, int minutes)
        {
            saved = false;
            LogEvent prev = null;

            if (ActiveEvent != null)
            {
                prev = ActiveEvent;
                ActiveEvent.Stop(minutes);
            }

            ActiveEvent = tsk.Start(minutes);

            return prev;
        }

        public void StopTask(Task tsk)
        {
            saved = false;
            ActiveEvent = null;
            tsk.Stop();
        }

        public void NewSprint()
        {
            saved = false;

            if (ActiveEvent != null)
            {
                ActiveEvent.Stop();
            }

            foreach (Task tsk in TaskList)
            {
                tsk.Reset();
            }

            CreateNewSavefileFilename();
        }
    }
}
