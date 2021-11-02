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

namespace Math
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int answer = Sum(2, 3, 5);
        }

        int Sum(int a, int b)
        {
            return a + b;
        }

        int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        private void Struct(object sender, RoutedEventArgs e)
        {

        }
    }
}
