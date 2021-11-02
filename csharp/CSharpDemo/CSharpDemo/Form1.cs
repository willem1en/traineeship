using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hello {txtFirstName.Text} {txtLastName.Text}");
        }

        private void BtnNewStudent_Click(object sender, EventArgs e)
        {
            Student st = new Student
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };

            // MessageBox.Show(st.ToString());

            lbxStudents.Items.Add(st);
        }

        private void btnTestData_Click(object sender, EventArgs e)
        {
            Student st1 = new Student
            {
                FirstName = "Eric",
                LastName = "Schuitmaker"
            };

            Student st2 = new Student
            {
                FirstName = "Chantal",
                LastName = "Rikse"
            };

            Student st3 = new Student
            {
                FirstName = "Gertjan",
                LastName = "Pomstra"
            };

            Student st4 = new Student
            {
                FirstName = "Willemien",
                LastName = "Kuijk"
            };

            List<Student> studentList = new List<Student> { st1, st2, st3, st4};

            dgvStudents.DataSource = studentList;
        }
    }
}
