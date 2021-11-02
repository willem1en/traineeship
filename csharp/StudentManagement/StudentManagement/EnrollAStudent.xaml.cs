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
    /// Interaction logic for EnrollAStudent.xaml
    /// </summary>
    public partial class EnrollAStudent : Window
    {
        StudentContext db = new StudentContext();
        int stID;

        public EnrollAStudent(Student st)
        {
            InitializeComponent();
            stID = st.StudentID;
            GetData();
        }

        private void GetData()
        {
            Student st = db.Students.Find(stID);

            var query = from enr in st.Enrollments
                        select enr;

            var enrollments = query.ToList();

            lbxEnrollments.ItemsSource = enrollments;
            lbxEnrollments.DisplayMemberPath = "Course.Name";

            var courses = db.Courses.ToList();

            var unenrolled = new List<Course>();

            foreach (Course c in courses.ToList())
            {
                var enrolled = false;

                foreach (Enrollment e in st.Enrollments)
                {
                    if (e.Course.Name == c.Name)
                    {
                        enrolled = true;
                        break;
                    }
                }

                if (!enrolled)
                {
                    unenrolled.Add(c);
                }
            }

            cbxCourses.ItemsSource = unenrolled;
            cbxCourses.DisplayMemberPath = "Name";
        }

        private void EnrollStudent(object sender, RoutedEventArgs e)
        {
            var st = this.DataContext as Student;
            var c = cbxCourses.SelectedItem as Course;

            var enrolled = from enr in st.Enrollments
                           select enr.Course.Name;

            db.Enrollments.Add(new Enrollment { CourseID = c.CourseID, StudentID = st.StudentID });
            db.SaveChanges();

            GetData();
        }

        private void UnenrollStudent(object sender, RoutedEventArgs e)
        {
            var st = this.DataContext as Student;
            var enrollment = lbxEnrollments.SelectedItem as Enrollment;

            db.Enrollments.Remove(enrollment);
            db.SaveChanges();

            GetData();
        }
    }
}
