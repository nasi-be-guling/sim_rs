﻿namespace SIM_RS.RAWAT_INAP
{
    partial class daftarTindakan
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
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPilihanFilter = new System.Windows.Forms.ComboBox();
            this.txtIsiFilter = new System.Windows.Forms.TextBox();
            this.btnCariSesuaiFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(12, 48);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(774, 347);
            this.lvDaftarTindakan.TabIndex = 0;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            this.lvDaftarTindakan.DoubleClick += new System.EventHandler(this.lvDaftarTindakan_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kode Tarif";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama Tarif";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nama SMF";
            this.columnHeader3.Width = 144;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Biaya";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Data : ";
            // 
            // cmbPilihanFilter
            // 
            this.cmbPilihanFilter.FormattingEnabled = true;
            this.cmbPilihanFilter.Location = new System.Drawing.Point(106, 16);
            this.cmbPilihanFilter.Name = "cmbPilihanFilter";
            this.cmbPilihanFilter.Size = new System.Drawing.Size(121, 26);
            this.cmbPilihanFilter.TabIndex = 2;
            // 
            // txtIsiFilter
            // 
            this.txtIsiFilter.Location = new System.Drawing.Point(243, 16);
            this.txtIsiFilter.Name = "txtIsiFilter";
            this.txtIsiFilter.Size = new System.Drawing.Size(221, 26);
            this.txtIsiFilter.TabIndex = 3;
            // 
            // btnCariSesuaiFilter
            // 
            this.btnCariSesuaiFilter.Location = new System.Drawing.Point(470, 16);
            this.btnCariSesuaiFilter.Name = "btnCariSesuaiFilter";
            this.btnCariSesuaiFilter.Size = new System.Drawing.Size(75, 26);
            this.btnCariSesuaiFilter.TabIndex = 4;
            this.btnCariSesuaiFilter.Text = "Cari";
            this.btnCariSesuaiFilter.UseVisualStyleBackColor = true;
            // 
            // daftarTindakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 407);
            this.Controls.Add(this.btnCariSesuaiFilter);
            this.Controls.Add(this.txtIsiFilter);
            this.Controls.Add(this.cmbPilihanFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvDaftarTindakan);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "daftarTindakan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Nama Tarip Perawatan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.daftarTindakan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPilihanFilter;
        private System.Windows.Forms.TextBox txtIsiFilter;
        private System.Windows.Forms.Button btnCariSesuaiFilter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}