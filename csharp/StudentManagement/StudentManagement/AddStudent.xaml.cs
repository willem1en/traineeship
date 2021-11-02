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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        StudentContext db = new StudentContext();
        public Student CurrentStudent { get; set; } = new Student();

        public AddStudent()
        {
            InitializeComponent();
            this.DataContext = CurrentStudent;
        }

        private void SaveStudent(object sender, RoutedEventArgs e)
        {
            var st = this.DataContext as Student;

            if (st.FirstName == null || st.LastName == null)
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            db.Students.Add(st);
            db.SaveChanges();

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
