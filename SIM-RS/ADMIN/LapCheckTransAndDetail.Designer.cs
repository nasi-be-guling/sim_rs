namespace SIM_RS.ADMIN
{
    partial class LapCheckTransAndDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFilterTgl = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbPilihanKelas = new System.Windows.Forms.ComboBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(4, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 465);
            this.panel1.TabIndex = 113;
            // 
            // lblDaftarTindakan
            // 
            this.lblDaftarTindakan.AutoSize = true;
            this.lblDaftarTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblDaftarTindakan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDaftarTindakan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarTindakan.ForeColor = System.Drawing.Color.White;
            this.lblDaftarTindakan.Location = new System.Drawing.Point(0, 0);
            this.lblDaftarTindakan.Name = "lblDaftarTindakan";
            this.lblDaftarTindakan.Size = new System.Drawing.Size(146, 20);
            this.lblDaftarTindakan.TabIndex = 111;
            this.lblDaftarTindakan.Text = "D&AFTAR TINDAKAN ";
            this.lblDaftarTindakan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(6, 25);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(784, 434);
            this.lvDaftarTindakan.TabIndex = 75;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.dtpFilterTgl);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 45);
            this.panel2.TabIndex = 114;
            // 
            // dtpFilterTgl
            // 
            this.dtpFilterTgl.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl.Location = new System.Drawing.Point(102, 9);
            this.dtpFilterTgl.Name = "dtpFilterTgl";
            this.dtpFilterTgl.Size = new System.Drawing.Size(218, 27);
            this.dtpFilterTgl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "FILTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel3.Controls.Add(this.cmbPilihanKelas);
            this.panel3.Controls.Add(this.btnCari);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(330, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 45);
            this.panel3.TabIndex = 115;
            // 
            // cmbPilihanKelas
            // 
            this.cmbPilihanKelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPilihanKelas.FormattingEnabled = true;
            this.cmbPilihanKelas.Items.AddRange(new object[] {
            "SATU",
            "DUA",
            "TIGA"});
            this.cmbPilihanKelas.Location = new System.Drawing.Point(111, 8);
            this.cmbPilihanKelas.Name = "cmbPilihanKelas";
            this.cmbPilihanKelas.Size = new System.Drawing.Size(179, 28);
            this.cmbPilihanKelas.TabIndex = 97;
            // 
            // btnCari
            // 
            this.btnCari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCari.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCari.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(296, 8);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(101, 30);
            this.btnCari.TabIndex = 96;
            this.btnCari.Text = "&CARI";
            this.btnCari.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "KELAS : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKeluar
            // 
            this.btnKeluar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(697, 529);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 116;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No Billing";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No MR";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nilai Transaksi";
            this.columnHeader3.Width = 143;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nilai Detail Transaksi";
            this.columnHeader4.Width = 199;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kode Tindakan";
            this.columnHeader5.Width = 135;
            // 
            // LapCheckTransAndDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LapCheckTransAndDetail";
            this.Text = "LapCheckTransAndDetail";
            this.Load += new System.EventHandler(this.LapCheckTransAndDetail_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LapCheckTransAndDetail_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.ComboBox cmbPilihanKelas;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}