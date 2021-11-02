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
using System.Windows.Shapes;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for EnrollStudents.xaml
    /// </summary>
    public partial class EnrollStudents : Window
    {
        StudentContext db = new StudentContext();
        Course course = new Course();

        public EnrollStudents(Course c)
        {
            InitializeComponent();

            course = c;
            this.DataContext = course;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStudents();
        }

        private void EnrollStudent(object sender, RoutedEventArgs e)
        {
            if (lbxStudents.SelectedItem == null)
            {
                MessageBox.Show("Please select student to enroll");
                return;
            }

            var st = lbxStudents.SelectedItem as Student;

            db.Enrollments.Add(new Enrollment { CourseID = course.CourseID, StudentID = st.StudentID });
            db.SaveChanges();

            LoadStudents();

        }

        private void RemoveStudent(object sender, RoutedEventArgs e)
        {
            if (lbxEnrolled.SelectedItem == null)
            {
                MessageBox.Show("Please select student to unenroll");
                return;
            }

            var st = lbxEnrolled.SelectedItem as Student;
            var enrollments = from enr in db.Enrollments
                              where enr.CourseID == course.CourseID
                              where enr.StudentID == st.StudentID
                              select enr;

            foreach (Enrollment enr in enrollments)
            {
                db.Enrollments.Remove(enr);
            }

            db.SaveChanges();

            LoadStudents();
        }

        private void LoadStudents()
        {
            var enrolled = from enr in db.Enrollments
                           where enr.CourseID == course.CourseID
                           orderby enr.Student.LastName
                           select enr.Student;

            var unenrolled = new List<Student>();

            var enrList = enrolled.Distinct().ToList();

            foreach (Student st in db.Students)
            {
                if (!enrList.Contains(st))
                {
                    unenrolled.Add(st);
                }
            }

            lbxStudents.ItemsSource = unenrolled;
            lbxEnrolled.ItemsSource = enrList;
        }
    }
}
