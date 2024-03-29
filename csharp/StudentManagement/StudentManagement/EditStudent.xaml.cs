﻿using System;
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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        StudentContext db = new StudentContext();
        public EditStudent(Student st)
        {
            InitializeComponent();

            this.DataContext = st;

            var query = from e in st.Enrollments
                        select e.Course.Name;
        }

        private void SaveStudent(object sender, RoutedEventArgs e)
        {
            var st = this.DataContext as Student;

            db.Students.Update(st);
            db.SaveChanges();

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
