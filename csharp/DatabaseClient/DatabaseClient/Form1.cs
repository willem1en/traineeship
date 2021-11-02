using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseClient
{
    public partial class Form1 : Form
    {
        readonly AdventureWorks2Entities db = new AdventureWorks2Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowProducts_Click(object sender, EventArgs e)
        {
            var results = db.Products.ToList();

            dataGridView1.DataSource = results;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from p in db.Products
                        where p.Color.Contains("r")
                        orderby p.ListPrice descending
                        select new
                        {
                            p.ProductID,
                            p.Name,
                            p.ListPrice,
                            p.Color
                        };

            MessageBox.Show(query.ToString());

            var result = query.ToList();

            dataGridView1.DataSource = result;
        }

        private void joins_Click(object sender, EventArgs e)
        {
            var query = from p in db.Products
                        select new
                        {
                            p.ProductID,
                            p.Name,
                            p.Color,
                            p.ListPrice,
                            CategoryName = p.ProductCategory.Name
                        };

            var result = query.ToList();

            dataGridView1.DataSource = result;
        }

        private void joins2_Click(object sender, EventArgs e)
        {
            var query = from c in db.ProductCategories
                        select new
                        {
                            c.ProductCategoryID,
                            c.Name,
                            Count = c.Products.Count()
                        };

            var result = query.ToList();

            dataGridView1.DataSource = result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var query = from p in db.Products
                        where p.Color == comboBox1.Text
                        select p;

            dataGridView1.DataSource = query.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var query = from p in db.Products
                        where p.Color != null
                        select p.Color;

            List<string> results = query.Distinct().ToList();

            comboBox1.DataSource = results;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Saved changes");
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory AddCategory = new AddCategory();
            AddCategory.ShowDialog();
            dataGridView1.DataSource = db.ProductCategories.ToList();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            var cat = dataGridView1.SelectedRows[0].DataBoundItem as ProductCategory;
            db.ProductCategories.Remove(cat);
            db.SaveChanges();
            dataGridView1.DataSource = db.ProductCategories.ToList();
        }

        private void btnShowCategories_Click(object sender, EventArgs e)
        {
            btnAddCategory.Show();
            btnDeleteCategory.Show();
            dataGridView1.DataSource = db.ProductCategories.ToList();
        }

        private void hideCategoryButtons()
        {
            btnAddCategory.Hide();
            btnDeleteCategory.Hide();
        }
    }
}
