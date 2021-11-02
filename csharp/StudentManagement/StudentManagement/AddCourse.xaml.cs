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
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        StudentContext db = new StudentContext();
        public Course CurrentCourse { get; set; } = new Course();

        public AddCourse()
        {
            InitializeComponent();
            this.DataContext = CurrentCourse;
        }

        private void SaveCourse(object sender, RoutedEventArgs e)
        {
            var c = this.DataContext as Course;

            if (c.Name == null || c.Description == null)
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            db.Courses.Add(c);
            db.SaveChanges();

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
