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
    /// Interaction logic for EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {
        StudentContext db = new StudentContext();
        public EditCourse(Course c)
        {
            InitializeComponent();

            this.DataContext = c;
        }

        private void SaveCourse(object sender, RoutedEventArgs e)
        {
            var c = this.DataContext as Course;

            db.Courses.Update(c);
            db.SaveChanges();

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
