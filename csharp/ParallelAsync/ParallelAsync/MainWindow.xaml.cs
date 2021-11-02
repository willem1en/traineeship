using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ParallelAsync
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

        private void Lambda(object sender, RoutedEventArgs e)
        {
            var namen = new[]
            {
                "Willemien Kuijk",
                "Xander Wemmers",
                "Chantal Rikse",
                "Gertjan Pomstra",
                "Eric Schuitmaker"
            };

            var result = namen.First(x => x.Length == 15);

            MessageBox.Show(result);
        }

        private void ParallelF(object sender, RoutedEventArgs e)
        {
            var namen = new[]
            {
                "Willemien Kuijk",
                "Xander Wemmers",
                "Chantal Rikse",
                "Gertjan Pomstra",
                "Eric Schuitmaker"
            };

            Parallel.ForEach(namen, ShowName);
        }

        private void ShowName(string name)
        {
            MessageBox.Show(name);
        }

        private void ComputeSquares(object sender, RoutedEventArgs e)
        {
            var numbers = new[] { 10, 2, 6, 3, 5, 7, 3, 2 };

            var sw = Stopwatch.StartNew();

            var query = from n in numbers.AsParallel()
                        where Square(n) > 50
                        select n;

            var result = query.ToList();

            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }

        int Square(int num)
        {
            Thread.Sleep(1000 * num);
            return num * num;
        }

        Task<int> SquareAsync(int num)
        {
            var task = new Task<int>(() => Square(num));
            task.Start();
            return task;
        }

        private async void Compute (object sender, RoutedEventArgs e)
        {
            int num = int.Parse(txt.Text);
            lbx.Items.Add($"Computing {num} squared...");

            int result = await SquareAsync(num);

            lbx.Items.Add($"{num} squared is {result}");

        }
    }
}
