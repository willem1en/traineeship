using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SprintTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel VM => this.DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VM.Load();
            UICreateTaskList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (VM.ActiveEvent != null)
            {
                var result = MessageBox.Show("Stop active task?", "Close SprintTracker", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        VM.ActiveEvent.Stop();
                        VM.Save();
                        break;
                    case MessageBoxResult.No:
                        VM.Save();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            } else {
                VM.Save();
            }
        }

        // Click and key events

        private void NewSprint_Click(object sender, RoutedEventArgs e)
        {
            VM.NewSprint();
            UICreateTaskList();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            AddTask();
        }

        private void Enter_Press(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddTask();
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var sp = btn.Parent as StackPanel;
            var tsk = sp.Tag as Task;

            if (tsk.Active)
            {
                var result = MessageBox.Show("Are you sure you want to delete the active task?", "Delete active task", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    tsk.Stop();
                }
                else
                {
                    return;
                }
            }
            else
            {
                DeleteTask(tsk);
                spTasklist.Children.Remove(sp);
            }
        }

        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var sp = btn.Parent as StackPanel;
            var tsk = sp.Tag as Task;

            spHeader.IsEnabled = false;
            Menu.IsEnabled = false;

            foreach (StackPanel s in spTasklist.Children)
            {
                if (s != sp)
                {
                    s.IsEnabled = false;
                }
            }

            sp.Children.Clear();
            var task = new TextBox();
            task.Text = tsk.Name;
            var edit = new Button();
            edit.Content = "save";
            edit.Tag = task;
            edit.Click += SaveEdit_Click;

            sp.Children.Add(task);
            sp.Children.Add(edit);
        }

        public void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var sp = btn.Parent as StackPanel;
            var tsk = sp.Tag as Task;

            var tbx = btn.Tag as TextBox;
            tsk.Name = tbx.Text;

            foreach (StackPanel s in spTasklist.Children)
            {
                {
                    s.IsEnabled = true;
                    UIUpdateTaskRow(sp);
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            UIClearTxb();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var sp = btn.Parent as StackPanel;
            var tsk = sp.Tag as Task;
            
            foreach (StackPanel s in spTasklist.Children)
            {
                var t = s.Tag as Task;

                if (t.Active)
                {
                    t.Stop();
                }

                UIUpdateTaskRow(s);
            }

            VM.StartTask(tsk);
            UIUpdateTaskRow(sp);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var sp = btn.Parent as StackPanel;
            var tsk = sp.Tag as Task;
            VM.StopTask(tsk);
            UIUpdateTaskRow(sp);
        }

        // UI & Data methods

        public void AddTask()
        {
            var tsk = new Task(tbxTaskName.Text);
            VM.AddTask(tsk);
            UICreateTaskRow(tsk);
            UIClearTxb();
        }

        private void DeleteTask(Task tsk)
        {
            VM.DeleteTask(tsk);
        }

        private void UIClearTxb()
        {
            tbxTaskName.Text = "";
        }

        public void UICreateTaskList()
        {
            spTasklist.Children.Clear();

            foreach (Task tsk in VM.TaskList)
            {
                UICreateTaskRow(tsk);
            }
        }

        public void UIUpdateTaskList()
        {
            foreach (StackPanel sp in spTasklist.Children)
            {
                var tsk = sp.Tag as Task;

                if (tsk.Active)
                {
                    tsk.Stop();
                }

                UIUpdateTaskRow(sp);
            }
        }

        public void UICreateTaskRow(Task tsk)
        {
            var sp = new StackPanel();
            sp.Tag = tsk;
            sp.Orientation = Orientation.Horizontal;
            spTasklist.Children.Add(sp);

            UIUpdateTaskRow(sp);
        }

        public void UIUpdateTaskRow(StackPanel sp)
        {
            sp.Children.Clear();

            // Stackpanel
            var tsk = sp.Tag as Task;

            // Task
            var task = new Label();
            task.Content = tsk.Name;
            var edit = new Button();
            edit.Content = "e";
            edit.Click += Edit_Click;
            var delete = new Button();
            delete.Content = "x";
            delete.Click += Delete_Click;

            sp.Children.Add(task);
            sp.Children.Add(edit);
            sp.Children.Add(delete);

            // Inactive
            var time = new Label();
            time.Content = tsk.GetElapsedTimeString();
            time.FontWeight = FontWeights.Bold;
            var start = new Button();
            start.Content = "start";
            start.Click += Start_Click;

            // Active
            var active = new Label();
            active.Content = "active";
            active.Foreground = new SolidColorBrush(Colors.Green);
            var stop = new Button();
            stop.Content = "stop";
            stop.Click += Stop_Click;

            if (tsk.Active)
            {
                sp.Children.Add(active);
                sp.Children.Add(stop);
            }
            else
            {
                sp.Children.Add(time);
                sp.Children.Add(start);
            }
        }
    }
}
