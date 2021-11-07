using SprintTrackerNew.MVVM.ViewModel;
using SprintTrackerNew.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace SprintTrackerNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel VM => this.DataContext as MainWindowViewModel;

        private UIElementCollection taskrows;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Window related events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            taskrows = spTasklist.Children;
            VM.Load();
            BuildUI();
            // cbSprintDays.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = VM.SprintDays });
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
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            
            if (!VM.saved)
            {
                var result = MessageBox.Show("Save before closing?", "Save", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        VM.Save();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        // Builds the UI dynamically
        public void BuildUI()
        {
            taskrows.Clear();
            spHeader.IsEnabled = true;
            spMenu.IsEnabled = true;
            tbxTaskName.IsEnabled = true;

            SaveButton.IsEnabled = VM.saved ? false : true;

            foreach (Task t in VM.TaskList)
            {
                UICreateRow(t);
            }
        }

        private void UICreateRow(Task tsk)
        {

            var row = new StackPanel();
            row.Tag = tsk;
            UIBuildRow(row);
            taskrows.Add(row);

            if (VM.TaskList.Count == 1)
            {
                spHeader.IsEnabled = true;
                spMenu.IsEnabled = true;
                tbxTaskName.IsEnabled = true;
            }
        }

        private void UIBuildRow(StackPanel row)
        {
            SaveButton.IsEnabled = VM.saved ? false : true;

            row.Children.Clear();
            var tsk = row.Tag as Task;
            row.Orientation = Orientation.Horizontal;

            var status = new StackPanel();
            status.HorizontalAlignment = HorizontalAlignment.Center;
            status.Width = 60;

            var buttons = new StackPanel();
            buttons.HorizontalAlignment = HorizontalAlignment.Right;
            buttons.Orientation = Orientation.Horizontal;
            buttons.Width = 70;

            if (tsk.Active)
            {
                // Active label
                var active = new Label();
                active.Content = "active";
                active.SetResourceReference(StyleProperty, "ActiveLabel");
                status.Children.Add(active);

                // Stop button
                var stop = new Button();
                stop.Content = "stop";
                stop.HorizontalContentAlignment = HorizontalAlignment.Right;
                stop.Click += Stop_Click;
                stop.SetResourceReference(Control.StyleProperty, "StopButton");
                buttons.Children.Add(stop);
            }
            else
            {
                // Time label
                var time = new Label();
                time.Content = tsk.GetElapsedTimeString();
                time.SetResourceReference(StyleProperty, "TimeLabel");
                status.Children.Add(time);

                // Minutes label
                var minutes = new TextBox();
                minutes.PreviewTextInput += PreviewTextInput;
                minutes.KeyDown += Start_KeyPress;
                minutes.SetResourceReference(StyleProperty, "MinutesTextBox");
                buttons.Children.Add(minutes);

                // Start button
                var start = new Button();
                start.Content = "start";
                start.Tag = minutes;
                start.Click += Start_Click;
                start.SetResourceReference(StyleProperty, "StartButton");
                buttons.Children.Add(start);
                
            }

            // Task label
            var task = new Label();
            task.Content = tsk.Name;
            task.MouseDoubleClick += TaskName_DoubleClick;
            task.SetResourceReference(StyleProperty, "TaskNameLabel");


            row.Children.Add(status);
            row.Children.Add(buttons);
            row.Children.Add(task);
        }

        // Click and key events
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var row = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            var tsk = row.Tag as Task;
            var time = (sender as Button).Tag as TextBox;

            var inp = time.Text;
            var min = 0;
            if (inp != "")
            {
                min = Int32.Parse(inp);
            }
            
            foreach (StackPanel tr in taskrows)
            {
                var t = tr.Tag as Task;

                if (t.Active)
                {
                    t.Stop();
                }

                UIBuildRow(tr);
            }

            var prev = VM.StartTask(tsk, min);
            if (prev is not null)
            {
                foreach (StackPanel tr in taskrows)
                {
                    if ((tr.Tag as Task).TaskID == prev.TaskID)
                    {
                        UIBuildRow(tr);
                        break;
                    }
                }
            }

            UIBuildRow(row);
        }

        private void Start_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var row = ((sender as TextBox).Parent as StackPanel).Parent as StackPanel;
                var tsk = row.Tag as Task;

                var min = Int32.Parse((sender as TextBox).Text);
                foreach (StackPanel tr in taskrows)
                {
                    var t = tr.Tag as Task;

                    if (t.Active)
                    {
                        t.Stop();
                    }

                    UIBuildRow(tr);
                }

                VM.StartTask(tsk, min);
                UIBuildRow(row);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            var row = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            var tsk = row.Tag as Task;
            VM.StopTask(tsk);
            UIBuildRow(row);
        }

        

        private void TbxTaskName_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var tsk = new Task(tbxTaskName.Text);
                var result = VM.AddTask(tsk);
                if (result)
                {
                    UICreateRow(tsk);
                    tbxTaskName.Clear();
                }
            }

            if (e.Key == Key.Escape)
            {
                tbxTaskName.Clear();
            }
        }

        public void TaskName_DoubleClick(object sender, RoutedEventArgs e)
        {
            var row = (sender as Label).Parent as StackPanel;
            var tsk = row.Tag as Task;

            spHeader.IsEnabled = false;
            spMenu.IsEnabled = false;
            tbxTaskName.IsEnabled = false;

            foreach (StackPanel r in taskrows)
            {
                if (r != row)
                {
                    r.IsEnabled = false;
                }
            }

            foreach (UIElement el in row.Children)
            {
                el.IsEnabled = false;
            }

            var task = new TextBox();
            task.Text = tsk.Name;
            task.SetResourceReference(StyleProperty, "RenameTaskTextBox");
            task.KeyDown += Rename_KeyPress;

            row.Children.RemoveAt(row.Children.Count - 1);
            row.Children.Add(task);
            row.Focus();
            Keyboard.Focus(task);

        }

        public void Rename_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var tbx = sender as TextBox;
                var row = tbx.Parent as StackPanel;
                var tsk = row.Tag as Task;

                tsk.Name = tbx.Text;

                foreach (StackPanel s in spTasklist.Children)
                {
                    {
                        s.IsEnabled = true;
                        tbxTaskName.IsEnabled = true;
                        spHeader.IsEnabled = true;
                        spMenu.IsEnabled = true;
                        UIBuildRow(row);
                    }
                }
            }

            if (e.Key == Key.Escape)
            {
                var tbx = sender as TextBox;
                var row = tbx.Parent as StackPanel;
                var tsk = row.Tag as Task;

                foreach (StackPanel s in spTasklist.Children)
                {
                    {
                        s.IsEnabled = true;
                        spHeader.IsEnabled = true;
                        tbxTaskName.IsEnabled = true;
                        spMenu.IsEnabled = true;
                        UIBuildRow(row);
                    }
                }
            }
        }

        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            spHeader.IsEnabled = false;
            spMenu.IsEnabled = false;
            tbxTaskName.IsEnabled = false;

            foreach (StackPanel tr in taskrows)
            {
                var task = tr.Children[2];
                tr.Children.Clear();

                if ((tr.Tag as Task).Removable)
                {
                    var delete = new Button();
                    delete.Content = "-";
                    delete.SetResourceReference(StyleProperty, "DeleteButton");
                    delete.Click += Delete_Click;

                    tr.Children.Clear();
                    tr.Children.Add(delete);
                }
                
                tr.Children.Add(task);
            }

            var finished = new Button();
            finished.Content = "finished";
            finished.Click += Finished_Click;
            finished.SetResourceReference(StyleProperty, "FinishedButton");
            taskrows.Add(finished);
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            VM.Save();
            SaveButton.IsEnabled = false;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var row = (sender as Button).Parent as StackPanel;
            var tsk = row.Tag as Task;

            VM.DeleteTask(tsk);
            taskrows.Remove(row);
            if (VM.TaskList.Count == 0)
            {
                BuildUI();
            }
        }

        private void Finished_Click(object sender, RoutedEventArgs e)
        {
            BuildUI();
        }

        private void NewSprint_Click(object sender, RoutedEventArgs e)
        {
            VM.NewSprint();
            BuildUI();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        // Verification
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
