
namespace DatabaseClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowProducts = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.joins = new System.Windows.Forms.Button();
            this.joins2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSelectColor = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnShowCategories = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowProducts
            // 
            this.btnShowProducts.Location = new System.Drawing.Point(133, 10);
            this.btnShowProducts.Name = "btnShowProducts";
            this.btnShowProducts.Size = new System.Drawing.Size(97, 23);
            this.btnShowProducts.TabIndex = 0;
            this.btnShowProducts.Text = "Show products";
            this.btnShowProducts.UseVisualStyleBackColor = true;
            this.btnShowProducts.Click += new System.EventHandler(this.btnShowProducts_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(133, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 396);
            this.dataGridView1.TabIndex = 1;
            // 
            // joins
            // 
            this.joins.Location = new System.Drawing.Point(80, 385);
            this.joins.Name = "joins";
            this.joins.Size = new System.Drawing.Size(47, 23);
            this.joins.TabIndex = 3;
            this.joins.Text = "Joins";
            this.joins.UseVisualStyleBackColor = true;
            this.joins.Click += new System.EventHandler(this.joins_Click);
            // 
            // joins2
            // 
            this.joins2.Location = new System.Drawing.Point(88, 414);
            this.joins2.Name = "joins2";
            this.joins2.Size = new System.Drawing.Size(39, 23);
            this.joins2.TabIndex = 4;
            this.joins2.Text = "Joins 2";
            this.joins2.UseVisualStyleBackColor = true;
            this.joins2.Click += new System.EventHandler(this.joins2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(844, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSelectColor
            // 
            this.lblSelectColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectColor.AutoSize = true;
            this.lblSelectColor.Location = new System.Drawing.Point(783, 15);
            this.lblSelectColor.Name = "lblSelectColor";
            this.lblSelectColor.Size = new System.Drawing.Size(55, 13);
            this.lblSelectColor.TabIndex = 7;
            this.lblSelectColor.Text = "Filter color";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(876, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(386, 10);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(103, 23);
            this.btnAddCategory.TabIndex = 9;
            this.btnAddCategory.Text = "Add category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(495, 10);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(103, 23);
            this.btnDeleteCategory.TabIndex = 10;
            this.btnDeleteCategory.Text = "Delete category";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnShowCategories
            // 
            this.btnShowCategories.Location = new System.Drawing.Point(236, 10);
            this.btnShowCategories.Name = "btnShowCategories";
            this.btnShowCategories.Size = new System.Drawing.Size(97, 23);
            this.btnShowCategories.TabIndex = 11;
            this.btnShowCategories.Text = "Show categories";
            this.btnShowCategories.UseVisualStyleBackColor = true;
            this.btnShowCategories.Click += new System.EventHandler(this.btnShowCategories_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Red products";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1000, 475);
            this.Controls.Add(this.btnShowCategories);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSelectColor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.joins2);
            this.Controls.Add(this.joins);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnShowProducts);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowProducts;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button joins;
        private System.Windows.Forms.Button joins2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSelectColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnShowCategories;
        private System.Windows.Forms.Button button2;
    }
}

