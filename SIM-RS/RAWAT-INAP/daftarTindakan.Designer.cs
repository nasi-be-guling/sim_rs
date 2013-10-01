namespace SIM_RS.RAWAT_INAP
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
            this.cmbPilihanFilter = new System.Windows.Forms.ComboBox();
            this.txtIsiFilter = new System.Windows.Forms.TextBox();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.btnCariSesuaiFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.bgWork2 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(7, 36);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(757, 348);
            this.lvDaftarTindakan.TabIndex = 0;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            this.lvDaftarTindakan.DoubleClick += new System.EventHandler(this.lvDaftarTindakan_DoubleClick);
            this.lvDaftarTindakan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvDaftarTindakan_KeyPress);
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
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbPilihanFilter
            // 
            this.cmbPilihanFilter.FormattingEnabled = true;
            this.cmbPilihanFilter.Items.AddRange(new object[] {
            "Kode Tarif",
            "Nama Tarif",
            "Nama SMF"});
            this.cmbPilihanFilter.Location = new System.Drawing.Point(229, 8);
            this.cmbPilihanFilter.Name = "cmbPilihanFilter";
            this.cmbPilihanFilter.Size = new System.Drawing.Size(121, 28);
            this.cmbPilihanFilter.TabIndex = 2;
            // 
            // txtIsiFilter
            // 
            this.txtIsiFilter.BackColor = System.Drawing.Color.White;
            this.txtIsiFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIsiFilter.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsiFilter.Location = new System.Drawing.Point(363, 8);
            this.txtIsiFilter.Name = "txtIsiFilter";
            this.txtIsiFilter.Size = new System.Drawing.Size(250, 28);
            this.txtIsiFilter.TabIndex = 3;
            this.txtIsiFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIsiFilter_KeyDown);
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // btnCariSesuaiFilter
            // 
            this.btnCariSesuaiFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCariSesuaiFilter.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCariSesuaiFilter.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCariSesuaiFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariSesuaiFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariSesuaiFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariSesuaiFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariSesuaiFilter.Location = new System.Drawing.Point(619, 8);
            this.btnCariSesuaiFilter.Name = "btnCariSesuaiFilter";
            this.btnCariSesuaiFilter.Size = new System.Drawing.Size(71, 28);
            this.btnCariSesuaiFilter.TabIndex = 96;
            this.btnCariSesuaiFilter.Text = "&Cari";
            this.btnCariSesuaiFilter.UseVisualStyleBackColor = false;
            this.btnCariSesuaiFilter.Click += new System.EventHandler(this.btnCariSesuaiFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(6, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 390);
            this.panel1.TabIndex = 113;
            // 
            // lblDaftarTindakan
            // 
            this.lblDaftarTindakan.AutoSize = true;
            this.lblDaftarTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblDaftarTindakan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDaftarTindakan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarTindakan.ForeColor = System.Drawing.Color.White;
            this.lblDaftarTindakan.Location = new System.Drawing.Point(0, 0);
            this.lblDaftarTindakan.Name = "lblDaftarTindakan";
            this.lblDaftarTindakan.Size = new System.Drawing.Size(306, 25);
            this.lblDaftarTindakan.TabIndex = 111;
            this.lblDaftarTindakan.Text = "DAFTAR NAMA TARIF PERAWATAN";
            this.lblDaftarTindakan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.cmbPilihanFilter);
            this.panel3.Controls.Add(this.btnCariSesuaiFilter);
            this.panel3.Controls.Add(this.txtIsiFilter);
            this.panel3.Location = new System.Drawing.Point(6, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 43);
            this.panel3.TabIndex = 115;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(223, 43);
            this.label23.TabIndex = 93;
            this.label23.Text = "Filter Pencarian  : ";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgWork2
            // 
            this.bgWork2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork2_DoWork);
            // 
            // daftarTindakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(782, 452);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "daftarTindakan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAFTAR NAMA TARIF PERAWATAN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.daftarTindakan_FormClosed);
            this.Load += new System.EventHandler(this.daftarTindakan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daftarTindakan_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.ComboBox cmbPilihanFilter;
        private System.Windows.Forms.TextBox txtIsiFilter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Button btnCariSesuaiFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label23;
        private System.ComponentModel.BackgroundWorker bgWork2;
    }
}