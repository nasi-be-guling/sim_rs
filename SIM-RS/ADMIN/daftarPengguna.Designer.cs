﻿namespace SIM_RS.ADMIN
{
    partial class daftarPengguna
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
            this.btnCariSesuaiFilter = new System.Windows.Forms.Button();
            this.txtIsiFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPilihan = new System.Windows.Forms.ComboBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.cmbStatusID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSandiPetugas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeluarIsiTindakan = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPetugas = new System.Windows.Forms.TextBox();
            this.lblPetugas = new System.Windows.Forms.Label();
            this.lblInfoDaftarPengguna = new System.Windows.Forms.Label();
            this.lvDaftarPengguna = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmsDaftarPengguna = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rubahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtUnitKerja = new System.Windows.Forms.TextBox();
            this.lblUnitKerja = new System.Windows.Forms.Label();
            this.txtNIPNBI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIdPetugas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cmsDaftarPengguna.SuspendLayout();
            this.SuspendLayout();
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
            this.btnCariSesuaiFilter.Location = new System.Drawing.Point(449, 36);
            this.btnCariSesuaiFilter.Name = "btnCariSesuaiFilter";
            this.btnCariSesuaiFilter.Size = new System.Drawing.Size(71, 28);
            this.btnCariSesuaiFilter.TabIndex = 96;
            this.btnCariSesuaiFilter.Text = "&Cari";
            this.btnCariSesuaiFilter.UseVisualStyleBackColor = false;
            this.btnCariSesuaiFilter.Click += new System.EventHandler(this.btnCariSesuaiFilter_Click);
            // 
            // txtIsiFilter
            // 
            this.txtIsiFilter.BackColor = System.Drawing.Color.White;
            this.txtIsiFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIsiFilter.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsiFilter.Location = new System.Drawing.Point(152, 36);
            this.txtIsiFilter.Name = "txtIsiFilter";
            this.txtIsiFilter.Size = new System.Drawing.Size(291, 28);
            this.txtIsiFilter.TabIndex = 3;
            this.txtIsiFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIsiFilter_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblIdPetugas);
            this.panel1.Controls.Add(this.txtNIPNBI);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblUnitKerja);
            this.panel1.Controls.Add(this.txtUnitKerja);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cbPilihan);
            this.panel1.Controls.Add(this.btnBatal);
            this.panel1.Controls.Add(this.cmbStatusID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSandiPetugas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnKeluarIsiTindakan);
            this.panel1.Controls.Add(this.btnCariSesuaiFilter);
            this.panel1.Controls.Add(this.btnSimpan);
            this.panel1.Controls.Add(this.txtIsiFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPetugas);
            this.panel1.Controls.Add(this.lblPetugas);
            this.panel1.Controls.Add(this.lblInfoDaftarPengguna);
            this.panel1.Controls.Add(this.lvDaftarPengguna);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 439);
            this.panel1.TabIndex = 117;
            // 
            // cbPilihan
            // 
            this.cbPilihan.FormattingEnabled = true;
            this.cbPilihan.Items.AddRange(new object[] {
            "Nama",
            "Unit Kerja",
            "NIP/NBI"});
            this.cbPilihan.Location = new System.Drawing.Point(8, 36);
            this.cbPilihan.Name = "cbPilihan";
            this.cbPilihan.Size = new System.Drawing.Size(138, 28);
            this.cbPilihan.TabIndex = 125;
            this.cbPilihan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPilihan_KeyDown);
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
            this.btnBatal.Location = new System.Drawing.Point(652, 261);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(77, 32);
            this.btnBatal.TabIndex = 124;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // cmbStatusID
            // 
            this.cmbStatusID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusID.FormattingEnabled = true;
            this.cmbStatusID.Items.AddRange(new object[] {
            "DIPAKAI",
            "TIDAK DIPAKAI"});
            this.cmbStatusID.Location = new System.Drawing.Point(554, 227);
            this.cmbStatusID.Name = "cmbStatusID";
            this.cmbStatusID.Size = new System.Drawing.Size(175, 28);
            this.cmbStatusID.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(457, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 122;
            this.label3.Text = "Status ID :";
            // 
            // txtSandiPetugas
            // 
            this.txtSandiPetugas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSandiPetugas.BackColor = System.Drawing.Color.White;
            this.txtSandiPetugas.Location = new System.Drawing.Point(554, 194);
            this.txtSandiPetugas.Name = "txtSandiPetugas";
            this.txtSandiPetugas.PasswordChar = '*';
            this.txtSandiPetugas.Size = new System.Drawing.Size(175, 27);
            this.txtSandiPetugas.TabIndex = 121;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(457, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 120;
            this.label2.Text = "Sandi : ";
            // 
            // btnKeluarIsiTindakan
            // 
            this.btnKeluarIsiTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluarIsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluarIsiTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluarIsiTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluarIsiTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarIsiTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarIsiTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluarIsiTindakan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarIsiTindakan.Location = new System.Drawing.Point(664, 404);
            this.btnKeluarIsiTindakan.Name = "btnKeluarIsiTindakan";
            this.btnKeluarIsiTindakan.Size = new System.Drawing.Size(101, 30);
            this.btnKeluarIsiTindakan.TabIndex = 119;
            this.btnKeluarIsiTindakan.Text = "&KELUAR";
            this.btnKeluarIsiTindakan.UseVisualStyleBackColor = false;
            this.btnKeluarIsiTindakan.Click += new System.EventHandler(this.btnKeluarIsiTindakan_Click);
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
            this.btnSimpan.Location = new System.Drawing.Point(568, 261);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(77, 32);
            this.btnSimpan.TabIndex = 118;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(457, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Unit Kerja : ";
            // 
            // txtPetugas
            // 
            this.txtPetugas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPetugas.BackColor = System.Drawing.Color.White;
            this.txtPetugas.Location = new System.Drawing.Point(554, 127);
            this.txtPetugas.Name = "txtPetugas";
            this.txtPetugas.Size = new System.Drawing.Size(175, 27);
            this.txtPetugas.TabIndex = 113;
            // 
            // lblPetugas
            // 
            this.lblPetugas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPetugas.AutoSize = true;
            this.lblPetugas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblPetugas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetugas.Location = new System.Drawing.Point(457, 131);
            this.lblPetugas.Name = "lblPetugas";
            this.lblPetugas.Size = new System.Drawing.Size(75, 18);
            this.lblPetugas.TabIndex = 112;
            this.lblPetugas.Text = "Petugas : ";
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
            this.lblInfoDaftarPengguna.Size = new System.Drawing.Size(264, 25);
            this.lblInfoDaftarPengguna.TabIndex = 111;
            this.lblInfoDaftarPengguna.Text = "DAFTAR PENGGUNA APLIKASI";
            this.lblInfoDaftarPengguna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvDaftarPengguna
            // 
            this.lvDaftarPengguna.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarPengguna.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDaftarPengguna.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDaftarPengguna.FullRowSelect = true;
            this.lvDaftarPengguna.GridLines = true;
            this.lvDaftarPengguna.HideSelection = false;
            this.lvDaftarPengguna.Location = new System.Drawing.Point(7, 70);
            this.lvDaftarPengguna.Name = "lvDaftarPengguna";
            this.lvDaftarPengguna.Size = new System.Drawing.Size(436, 364);
            this.lvDaftarPengguna.TabIndex = 0;
            this.lvDaftarPengguna.UseCompatibleStateImageBehavior = false;
            this.lvDaftarPengguna.View = System.Windows.Forms.View.Details;
            this.lvDaftarPengguna.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvDaftarPengguna_KeyDown);
            this.lvDaftarPengguna.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDaftarPengguna_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Petugas";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Unit Kerja";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status ID";
            this.columnHeader3.Width = 103;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.pictureBox2.Location = new System.Drawing.Point(450, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(316, 233);
            this.pictureBox2.TabIndex = 116;
            this.pictureBox2.TabStop = false;
            // 
            // cmsDaftarPengguna
            // 
            this.cmsDaftarPengguna.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rubahToolStripMenuItem});
            this.cmsDaftarPengguna.Name = "cmsDaftarTindakan";
            this.cmsDaftarPengguna.Size = new System.Drawing.Size(109, 26);
            // 
            // rubahToolStripMenuItem
            // 
            this.rubahToolStripMenuItem.Name = "rubahToolStripMenuItem";
            this.rubahToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rubahToolStripMenuItem.Text = "Rubah";
            this.rubahToolStripMenuItem.Click += new System.EventHandler(this.rubahToolStripMenuItem_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "NIP/NBI";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(554, 404);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 30);
            this.btnRefresh.TabIndex = 126;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtUnitKerja
            // 
            this.txtUnitKerja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitKerja.BackColor = System.Drawing.Color.White;
            this.txtUnitKerja.Location = new System.Drawing.Point(554, 160);
            this.txtUnitKerja.Name = "txtUnitKerja";
            this.txtUnitKerja.Size = new System.Drawing.Size(175, 27);
            this.txtUnitKerja.TabIndex = 127;
            // 
            // lblUnitKerja
            // 
            this.lblUnitKerja.AutoSize = true;
            this.lblUnitKerja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblUnitKerja.Location = new System.Drawing.Point(735, 162);
            this.lblUnitKerja.Name = "lblUnitKerja";
            this.lblUnitKerja.Size = new System.Drawing.Size(18, 20);
            this.lblUnitKerja.TabIndex = 128;
            this.lblUnitKerja.Text = "...";
            // 
            // txtNIPNBI
            // 
            this.txtNIPNBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNIPNBI.BackColor = System.Drawing.Color.White;
            this.txtNIPNBI.Location = new System.Drawing.Point(554, 94);
            this.txtNIPNBI.Name = "txtNIPNBI";
            this.txtNIPNBI.Size = new System.Drawing.Size(175, 27);
            this.txtNIPNBI.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(457, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 129;
            this.label4.Text = "NIP / NBI : ";
            // 
            // lblIdPetugas
            // 
            this.lblIdPetugas.AutoSize = true;
            this.lblIdPetugas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblIdPetugas.Location = new System.Drawing.Point(735, 131);
            this.lblIdPetugas.Name = "lblIdPetugas";
            this.lblIdPetugas.Size = new System.Drawing.Size(18, 20);
            this.lblIdPetugas.TabIndex = 131;
            this.lblIdPetugas.Text = "...";
            // 
            // daftarPengguna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 452);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "daftarPengguna";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.daftarPengguna_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cmsDaftarPengguna.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCariSesuaiFilter;
        private System.Windows.Forms.TextBox txtIsiFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfoDaftarPengguna;
        private System.Windows.Forms.ListView lvDaftarPengguna;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtPetugas;
        private System.Windows.Forms.Label lblPetugas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnKeluarIsiTindakan;
        private System.Windows.Forms.ContextMenuStrip cmsDaftarPengguna;
        private System.Windows.Forms.TextBox txtSandiPetugas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem rubahToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbStatusID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.ComboBox cbPilihan;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblUnitKerja;
        private System.Windows.Forms.TextBox txtUnitKerja;
        private System.Windows.Forms.TextBox txtNIPNBI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIdPetugas;

    }
}