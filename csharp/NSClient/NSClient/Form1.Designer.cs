
namespace NSClient
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
            this.lstbxStations = new System.Windows.Forms.ListBox();
            this.lblStations = new System.Windows.Forms.Label();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            this.SuspendLayout();
            // 
            // lstbxStations
            // 
            this.lstbxStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbxStations.FormattingEnabled = true;
            this.lstbxStations.Location = new System.Drawing.Point(12, 64);
            this.lstbxStations.Name = "lstbxStations";
            this.lstbxStations.Size = new System.Drawing.Size(187, 394);
            this.lstbxStations.TabIndex = 0;
            this.lstbxStations.SelectedIndexChanged += new System.EventHandler(this.lstbxStations_SelectedIndexChanged);
            // 
            // lblStations
            // 
            this.lblStations.AutoSize = true;
            this.lblStations.Location = new System.Drawing.Point(12, 48);
            this.lblStations.Name = "lblStations";
            this.lblStations.Size = new System.Drawing.Size(45, 13);
            this.lblStations.TabIndex = 1;
            this.lblStations.Text = "Stations";
            // 
            // dgvStations
            // 
            this.dgvStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Location = new System.Drawing.Point(214, 25);
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.Size = new System.Drawing.Size(638, 437);
            this.dgvStations.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 482);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvStations);
            this.Controls.Add(this.lblStations);
            this.Controls.Add(this.lstbxStations);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxStations;
        private System.Windows.Forms.Label lblStations;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

