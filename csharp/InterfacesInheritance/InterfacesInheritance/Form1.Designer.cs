
namespace InterfacesInheritance
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestCalculators = new System.Windows.Forms.Button();
            this.TestZoo = new System.Windows.Forms.Button();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.SuspendLayout();
            // 
            // TestCalculators
            // 
            this.TestCalculators.Location = new System.Drawing.Point(12, 12);
            this.TestCalculators.Name = "TestCalculators";
            this.TestCalculators.Size = new System.Drawing.Size(150, 23);
            this.TestCalculators.TabIndex = 0;
            this.TestCalculators.Text = "Test calculators";
            this.TestCalculators.UseVisualStyleBackColor = true;
            this.TestCalculators.Click += new System.EventHandler(this.TestCalculators_Click);
            // 
            // TestZoo
            // 
            this.TestZoo.Location = new System.Drawing.Point(12, 41);
            this.TestZoo.Name = "TestZoo";
            this.TestZoo.Size = new System.Drawing.Size(150, 23);
            this.TestZoo.TabIndex = 1;
            this.TestZoo.Text = "Test zoo";
            this.TestZoo.UseVisualStyleBackColor = true;
            this.TestZoo.Click += new System.EventHandler(this.TestZoo_Click);
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.Location = new System.Drawing.Point(182, 12);
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.RowTemplate.Height = 25;
            this.dgvAnimals.Size = new System.Drawing.Size(606, 426);
            this.dgvAnimals.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAnimals);
            this.Controls.Add(this.TestZoo);
            this.Controls.Add(this.TestCalculators);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestCalculators;
        private System.Windows.Forms.Button TestZoo;
        private System.Windows.Forms.DataGridView dgvAnimals;
    }
}

