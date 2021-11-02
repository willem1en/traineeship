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
    public partial class AddCategory : Form
    {
        readonly AdventureWorks2Entities db = new AdventureWorks2Entities();

        public AddCategory()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var cat = new ProductCategory()
            {
                Name = txtCategoryName.Text,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };

            db.ProductCategories.Add(cat);
            db.SaveChanges();
            this.Close();
        }
    }
}
