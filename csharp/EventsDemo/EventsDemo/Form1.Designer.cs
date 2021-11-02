
namespace EventsDemo
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
            this.Cool = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Heat = new System.Windows.Forms.Button();
            this.SuperCool = new System.Windows.Forms.Button();
            this.SuperHeat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cool
            // 
            this.Cool.Location = new System.Drawing.Point(229, 100);
            this.Cool.Name = "Cool";
            this.Cool.Size = new System.Drawing.Size(75, 23);
            this.Cool.TabIndex = 0;
            this.Cool.Text = "Cool";
            this.Cool.UseVisualStyleBackColor = true;
            this.Cool.Click += new System.EventHandler(this.Cool_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Heat
            // 
            this.Heat.Location = new System.Drawing.Point(310, 100);
            this.Heat.Name = "Heat";
            this.Heat.Size = new System.Drawing.Size(75, 23);
            this.Heat.TabIndex = 2;
            this.Heat.Text = "Heat";
            this.Heat.UseVisualStyleBackColor = true;
            this.Heat.Click += new System.EventHandler(this.Heat_Click);
            // 
            // SuperCool
            // 
            this.SuperCool.Location = new System.Drawing.Point(148, 100);
            this.SuperCool.Name = "SuperCool";
            this.SuperCool.Size = new System.Drawing.Size(75, 23);
            this.SuperCool.TabIndex = 3;
            this.SuperCool.Text = "Super cool";
            this.SuperCool.UseVisualStyleBackColor = true;
            this.SuperCool.Click += new System.EventHandler(this.SuperCool_Click);
            // 
            // SuperHeat
            // 
            this.SuperHeat.Location = new System.Drawing.Point(391, 100);
            this.SuperHeat.Name = "SuperHeat";
            this.SuperHeat.Size = new System.Drawing.Size(75, 23);
            this.SuperHeat.TabIndex = 4;
            this.SuperHeat.Text = "Super heat";
            this.SuperHeat.UseVisualStyleBackColor = true;
            this.SuperHeat.Click += new System.EventHandler(this.SuperHeat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SuperHeat);
            this.Controls.Add(this.SuperCool);
            this.Controls.Add(this.Heat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cool);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Heat;
        private System.Windows.Forms.Button SuperCool;
        private System.Windows.Forms.Button SuperHeat;
        private System.Windows.Forms.Label label2;
    }
}

