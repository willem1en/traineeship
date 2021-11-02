using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GlassOfWater glass = new GlassOfWater();

        private void Form1_Load(object sender, EventArgs e)
        {
            glass.TemperatureChanged += Glass_TemperatureChanged;
            glass.Freezing += (obj, args) => label1.ForeColor = Color.Blue;
            glass.Boiling += (obj, args) => label1.ForeColor = Color.Red;
            glass.Normal += (obj, args) => label1.ForeColor = Color.Black;
            label1.Text = $"The temperature is {glass.Temperature}";
        }


        private void Glass_TemperatureChanged(object sender, DateTime when)
        {
            label1.Text = $"{when.ToLongTimeString()} The temperature is {glass.Temperature}";
        }

        private void Cool_Click(object sender, EventArgs e)
        {
            glass.Cool();
        }

        private void Heat_Click(object sender, EventArgs e)
        {
            glass.Heat();
        }

        private void SuperCool_Click(object sender, EventArgs e)
        {
            glass.SuperCool();
        }

        private void SuperHeat_Click(object sender, EventArgs e)
        {
            glass.SuperHeat();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = $"P({e.X}, {e.Y})";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("U sure?");
        }
    }
}
