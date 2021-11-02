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

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentContext db = new StudentContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            db = new StudentContext();
            dgs.ItemsSource = db.Students.ToList();
            dgc.ItemsSource = db.Courses.ToList();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Students tab

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            var AddStudentWindow = new AddStudent();
            AddStudentWindow.ShowDialog();

            GetData();
        }

        private void EditStudent(object sender, RoutedEventArgs e)
        {
            if (dgs.SelectedItem == null)
            {
                MessageBox.Show("Please select a student to modify");
                return;
            }
            var st = dgs.SelectedItem as Student;
            var EditStudentWindow = new EditStudent(st);
            EditStudentWindow.DataContext = st;
            EditStudentWindow.ShowDialog();

            GetData();
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            var st = dgs.SelectedItem as Student;
            var result = MessageBox.Show($"Do you want to delete {st}?", "Delete student", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.Cancel)
            {
                return;
            }

            db.Students.Remove(st);
            db.SaveChanges();

            GetData();
        }

        private void EnrollInCourse(object sender, RoutedEventArgs e)
        {
            if (dgs.SelectedItem == null)
            {
                MessageBox.Show("Please select a student to enroll");
                return;
            }
            var st = dgs.SelectedItem as Student;
            var EnrollAStudentWindow = new EnrollAStudent(st);
            EnrollAStudentWindow.DataContext = st;
            EnrollAStudentWindow.ShowDialog();

            GetData();
        }

        // Courses tab

        private void EnrollStudents(object sender, RoutedEventArgs e)
        {
            var c = dgc.SelectedItem as Course;
            var EnrollStudentsWindow = new EnrollStudents(c);
            EnrollStudentsWindow.ShowDialog();

            GetData();
        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {
            var AddCourseWindow = new AddCourse();
            AddCourseWindow.ShowDialog();

            GetData();
        }

        private void EditCourse(object sender, RoutedEventArgs e)
        {
            if (dgc.SelectedItem == null)
            {
                MessageBox.Show("Please select a course to modify");
                return;
            }
            var c = dgc.SelectedItem as Course;
            var EditCourseWindow = new EditCourse(c);
            EditCourseWindow.DataContext = c;
            EditCourseWindow.ShowDialog();

            GetData();
        }

        private void DeleteCourse(object sender, RoutedEventArgs e)
        {
            var c = dgc.SelectedItem as Course;

            var result = MessageBox.Show($"Do you want to delete {c}?", "Delete course", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.Cancel)
            {
                return;
            }

            db.Courses.Remove(c);
            db.SaveChanges();

            GetData();
        }
    }
}
