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

namespace XsmlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var st = sp.DataContext as Student;
            MessageBox.Show($"{st.FirstName} {st.LastName}");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var st = new Student()
            {
                FirstName = "Willemien",
                LastName = "Kuijk",
                DateOfBirth = new DateTime(1994,2,22)
            };

            sp.DataContext = st;
        }
    }
}
