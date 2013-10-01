namespace SIM_RS.ADMIN
{
    partial class daftarMenu
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbDipakai = new System.Windows.Forms.ComboBox();
            this.txtNamaAppBaru = new System.Windows.Forms.TextBox();
            this.txtNamaMenu = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.lblTempatLayanan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnCariMenu = new System.Windows.Forms.Button();
            this.txtCariMenu = new System.Windows.Forms.TextBox();
            this.lblInfoDaftarPengguna = new System.Windows.Forms.Label();
            this.lvDaftarMenu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsDaftarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rubahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.cmsDaftarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnKeluar);
            this.panel1.Controls.Add(this.btnCariMenu);
            this.panel1.Controls.Add(this.txtCariMenu);
            this.panel1.Controls.Add(this.lblInfoDaftarPengguna);
            this.panel1.Controls.Add(this.lvDaftarMenu);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 586);
            this.panel1.TabIndex = 118;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel6.Controls.Add(this.cmbDipakai);
            this.panel6.Controls.Add(this.txtNamaAppBaru);
            this.panel6.Controls.Add(this.txtNamaMenu);
            this.panel6.Controls.Add(this.btnBatal);
            this.panel6.Controls.Add(this.lblTempatLayanan);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.btnSimpan);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(6, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(774, 186);
            this.panel6.TabIndex = 146;
            // 
            // cmbDipakai
            // 
            this.cmbDipakai.DisplayMember = "0";
            this.cmbDipakai.FormattingEnabled = true;
            this.cmbDipakai.Items.AddRange(new object[] {
            "Tidak",
            "Ya",
            "Bisa Jadi"});
            this.cmbDipakai.Location = new System.Drawing.Point(198, 93);
            this.cmbDipakai.Name = "cmbDipakai";
            this.cmbDipakai.Size = new System.Drawing.Size(121, 28);
            this.cmbDipakai.TabIndex = 127;
            this.cmbDipakai.ValueMember = "0";
            // 
            // txtNamaAppBaru
            // 
            this.txtNamaAppBaru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaAppBaru.BackColor = System.Drawing.Color.White;
            this.txtNamaAppBaru.Location = new System.Drawing.Point(198, 51);
            this.txtNamaAppBaru.Name = "txtNamaAppBaru";
            this.txtNamaAppBaru.Size = new System.Drawing.Size(242, 27);
            this.txtNamaAppBaru.TabIndex = 126;
            this.txtNamaAppBaru.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNamaAppBaru_KeyUp);
            // 
            // txtNamaMenu
            // 
            this.txtNamaMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaMenu.BackColor = System.Drawing.Color.White;
            this.txtNamaMenu.Location = new System.Drawing.Point(198, 13);
            this.txtNamaMenu.Name = "txtNamaMenu";
            this.txtNamaMenu.Size = new System.Drawing.Size(376, 27);
            this.txtNamaMenu.TabIndex = 113;
            this.txtNamaMenu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNamaMenu_KeyUp);
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnBatal.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatal.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(688, 142);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(77, 32);
            this.btnBatal.TabIndex = 124;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // lblTempatLayanan
            // 
            this.lblTempatLayanan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTempatLayanan.AutoSize = true;
            this.lblTempatLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblTempatLayanan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempatLayanan.Location = new System.Drawing.Point(36, 17);
            this.lblTempatLayanan.Name = "lblTempatLayanan";
            this.lblTempatLayanan.Size = new System.Drawing.Size(103, 18);
            this.lblTempatLayanan.TabIndex = 112;
            this.lblTempatLayanan.Text = "Nama Menu : ";
            this.lblTempatLayanan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 18);
            this.label3.TabIndex = 122;
            this.label3.Text = "Nama Form Aplikasi  : ";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnSimpan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(605, 142);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(77, 32);
            this.btnSimpan.TabIndex = 118;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 120;
            this.label2.Text = "Dipakai : ";
            // 
            // btnKeluar
            // 
            this.btnKeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(681, 551);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 119;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnCariMenu
            // 
            this.btnCariMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCariMenu.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCariMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCariMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariMenu.Location = new System.Drawing.Point(371, 220);
            this.btnCariMenu.Name = "btnCariMenu";
            this.btnCariMenu.Size = new System.Drawing.Size(130, 28);
            this.btnCariMenu.TabIndex = 96;
            this.btnCariMenu.Text = "&Filter Pencarian";
            this.btnCariMenu.UseVisualStyleBackColor = false;
            this.btnCariMenu.Click += new System.EventHandler(this.btnCariMenu_Click);
            // 
            // txtCariMenu
            // 
            this.txtCariMenu.BackColor = System.Drawing.Color.White;
            this.txtCariMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCariMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCariMenu.Location = new System.Drawing.Point(6, 220);
            this.txtCariMenu.Name = "txtCariMenu";
            this.txtCariMenu.Size = new System.Drawing.Size(359, 28);
            this.txtCariMenu.TabIndex = 3;
            // 
            // lblInfoDaftarPengguna
            // 
            this.lblInfoDaftarPengguna.AutoSize = true;
            this.lblInfoDaftarPengguna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblInfoDaftarPengguna.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoDaftarPengguna.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoDaftarPengguna.ForeColor = System.Drawing.Color.White;
            this.lblInfoDaftarPengguna.Location = new System.Drawing.Point(0, 0);
            this.lblInfoDaftarPengguna.Name = "lblInfoDaftarPengguna";
            this.lblInfoDaftarPengguna.Size = new System.Drawing.Size(218, 25);
            this.lblInfoDaftarPengguna.TabIndex = 111;
            this.lblInfoDaftarPengguna.Text = "DAFTAR MENU APLIKASI";
            this.lblInfoDaftarPengguna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvDaftarMenu
            // 
            this.lvDaftarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDaftarMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDaftarMenu.FullRowSelect = true;
            this.lvDaftarMenu.GridLines = true;
            this.lvDaftarMenu.HideSelection = false;
            this.lvDaftarMenu.Location = new System.Drawing.Point(6, 254);
            this.lvDaftarMenu.Name = "lvDaftarMenu";
            this.lvDaftarMenu.Size = new System.Drawing.Size(773, 290);
            this.lvDaftarMenu.TabIndex = 0;
            this.lvDaftarMenu.UseCompatibleStateImageBehavior = false;
            this.lvDaftarMenu.View = System.Windows.Forms.View.Details;
            this.lvDaftarMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDaftarMenu_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama Menu";
            this.columnHeader2.Width = 189;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dipakai";
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nama Form Aplikasi";
            this.columnHeader4.Width = 186;
            // 
            // cmsDaftarMenu
            // 
            this.cmsDaftarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rubahToolStripMenuItem});
            this.cmsDaftarMenu.Name = "cmsDaftarTindakan";
            this.cmsDaftarMenu.Size = new System.Drawing.Size(117, 26);
            // 
            // rubahToolStripMenuItem
            // 
            this.rubahToolStripMenuItem.Name = "rubahToolStripMenuItem";
            this.rubahToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.rubahToolStripMenuItem.Text = "Rubah";
            this.rubahToolStripMenuItem.Click += new System.EventHandler(this.rubahToolStripMenuItem_Click);
            // 
            // daftarMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "daftarMenu";
            this.Text = "daftarMenu";
            this.Load += new System.EventHandler(this.daftarMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daftarMenu_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.cmsDaftarMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnCariMenu;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtCariMenu;
        private System.Windows.Forms.TextBox txtNamaMenu;
        private System.Windows.Forms.Label lblTempatLayanan;
        private System.Windows.Forms.Label lblInfoDaftarPengguna;
        private System.Windows.Forms.ListView lvDaftarMenu;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtNamaAppBaru;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip cmsDaftarMenu;
        private System.Windows.Forms.ToolStripMenuItem rubahToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbDipakai;
    }
}