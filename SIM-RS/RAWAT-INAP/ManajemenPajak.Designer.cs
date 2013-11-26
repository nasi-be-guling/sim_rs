namespace SIM_RS.RAWAT_INAP
{
    partial class ManajemenPajak
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lblIdPajak = new System.Windows.Forms.Label();
            this.lvDokterPajak = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnTglAmbil = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.dtpTglAmbil = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dtpTglSPJ = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamaDokter = new System.Windows.Forms.Label();
            this.lblKodeDokter = new System.Windows.Forms.Label();
            this.lvPajakPerDokter = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RVPajakBulanan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCariLagi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.InfoProsesExcell = new System.Windows.Forms.Label();
            this.RVRekapitulasiPajak = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lvPajakRekapitulasi = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtpRentang2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dtpRentang1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.bwLoadDokter = new System.ComponentModel.BackgroundWorker();
            this.bwLoadPajak = new System.ComponentModel.BackgroundWorker();
            this.cmsRubahTglSPJ = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rubahTanggalSPJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bwRekapitulasi = new System.ComponentModel.BackgroundWorker();
            this.lstPajakPerDokter = new System.Windows.Forms.BindingSource(this.components);
            this.ReportPajakPerDokterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmsRubahTglSPJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstPajakPerDokter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportPajakPerDokterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 476);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnKeluar);
            this.tabPage3.Controls.Add(this.lblIdPajak);
            this.tabPage3.Controls.Add(this.lvDokterPajak);
            this.tabPage3.Controls.Add(this.panel7);
            this.tabPage3.Controls.Add(this.btnTglAmbil);
            this.tabPage3.Controls.Add(this.btnBatal);
            this.tabPage3.Controls.Add(this.dtpTglAmbil);
            this.tabPage3.Controls.Add(this.btnSimpan);
            this.tabPage3.Controls.Add(this.dtpTglSPJ);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 440);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SPJ DOKTER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(585, 17);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(93, 29);
            this.btnKeluar.TabIndex = 131;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // lblIdPajak
            // 
            this.lblIdPajak.AutoSize = true;
            this.lblIdPajak.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPajak.Location = new System.Drawing.Point(659, 269);
            this.lblIdPajak.Name = "lblIdPajak";
            this.lblIdPajak.Size = new System.Drawing.Size(19, 14);
            this.lblIdPajak.TabIndex = 130;
            this.lblIdPajak.Text = "...";
            this.lblIdPajak.Visible = false;
            // 
            // lvDokterPajak
            // 
            this.lvDokterPajak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDokterPajak.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader19,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader20});
            this.lvDokterPajak.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDokterPajak.FullRowSelect = true;
            this.lvDokterPajak.GridLines = true;
            this.lvDokterPajak.HideSelection = false;
            this.lvDokterPajak.Location = new System.Drawing.Point(14, 53);
            this.lvDokterPajak.Name = "lvDokterPajak";
            this.lvDokterPajak.Size = new System.Drawing.Size(730, 339);
            this.lvDokterPajak.TabIndex = 129;
            this.lvDokterPajak.UseCompatibleStateImageBehavior = false;
            this.lvDokterPajak.View = System.Windows.Forms.View.Details;
            this.lvDokterPajak.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDokterPajak_MouseClick);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "No";
            this.columnHeader13.Width = 41;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Tgl Ambil";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 130;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "TglSPJ";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader19.Width = 130;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Nama Dokter";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Bruto";
            this.columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Pajak";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Kode DOkter";
            this.columnHeader18.Width = 0;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "ID Pajak";
            this.columnHeader20.Width = 0;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel7.Controls.Add(this.label11);
            this.panel7.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(14, 398);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(202, 30);
            this.panel7.TabIndex = 128;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tanggal SPJ";
            // 
            // btnTglAmbil
            // 
            this.btnTglAmbil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnTglAmbil.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTglAmbil.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTglAmbil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTglAmbil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTglAmbil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTglAmbil.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTglAmbil.Location = new System.Drawing.Point(486, 17);
            this.btnTglAmbil.Name = "btnTglAmbil";
            this.btnTglAmbil.Size = new System.Drawing.Size(93, 29);
            this.btnTglAmbil.TabIndex = 93;
            this.btnTglAmbil.Text = "&TAMPILKAN";
            this.btnTglAmbil.UseVisualStyleBackColor = false;
            this.btnTglAmbil.Click += new System.EventHandler(this.btnTglAmbil_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBatal.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatal.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(578, 398);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(74, 28);
            this.btnBatal.TabIndex = 127;
            this.btnBatal.Text = "&BATAL";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // dtpTglAmbil
            // 
            this.dtpTglAmbil.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTglAmbil.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTglAmbil.Location = new System.Drawing.Point(220, 17);
            this.dtpTglAmbil.Name = "dtpTglAmbil";
            this.dtpTglAmbil.Size = new System.Drawing.Size(262, 30);
            this.dtpTglAmbil.TabIndex = 1;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSimpan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(490, 398);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(82, 28);
            this.btnSimpan.TabIndex = 126;
            this.btnSimpan.Text = "S&IMPAN";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dtpTglSPJ
            // 
            this.dtpTglSPJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTglSPJ.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTglSPJ.Location = new System.Drawing.Point(220, 398);
            this.dtpTglSPJ.Name = "dtpTglSPJ";
            this.dtpTglSPJ.Size = new System.Drawing.Size(261, 30);
            this.dtpTglSPJ.TabIndex = 125;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel5.Controls.Add(this.label6);
            this.panel5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(14, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(202, 30);
            this.panel5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tanggal Ambil";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.lblNamaDokter);
            this.tabPage1.Controls.Add(this.lblKodeDokter);
            this.tabPage1.Controls.Add(this.lvPajakPerDokter);
            this.tabPage1.Controls.Add(this.RVPajakBulanan);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PER DOKTER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 35);
            this.panel2.TabIndex = 121;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(607, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "LAPORAN PAJAK";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNamaDokter
            // 
            this.lblNamaDokter.AutoSize = true;
            this.lblNamaDokter.Location = new System.Drawing.Point(523, 259);
            this.lblNamaDokter.Name = "lblNamaDokter";
            this.lblNamaDokter.Size = new System.Drawing.Size(28, 23);
            this.lblNamaDokter.TabIndex = 119;
            this.lblNamaDokter.Text = "...";
            this.lblNamaDokter.Visible = false;
            // 
            // lblKodeDokter
            // 
            this.lblKodeDokter.AutoSize = true;
            this.lblKodeDokter.Location = new System.Drawing.Point(464, 259);
            this.lblKodeDokter.Name = "lblKodeDokter";
            this.lblKodeDokter.Size = new System.Drawing.Size(28, 23);
            this.lblKodeDokter.TabIndex = 118;
            this.lblKodeDokter.Text = "...";
            this.lblKodeDokter.Visible = false;
            // 
            // lvPajakPerDokter
            // 
            this.lvPajakPerDokter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPajakPerDokter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPajakPerDokter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPajakPerDokter.FullRowSelect = true;
            this.lvPajakPerDokter.GridLines = true;
            this.lvPajakPerDokter.HideSelection = false;
            this.lvPajakPerDokter.Location = new System.Drawing.Point(3, 50);
            this.lvPajakPerDokter.Name = "lvPajakPerDokter";
            this.lvPajakPerDokter.Size = new System.Drawing.Size(762, 214);
            this.lvPajakPerDokter.TabIndex = 117;
            this.lvPajakPerDokter.UseCompatibleStateImageBehavior = false;
            this.lvPajakPerDokter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "No";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Bulan";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sblm Kena Pajak";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pajak";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stlh Kena Pajak";
            this.columnHeader3.Width = 121;
            // 
            // RVPajakBulanan
            // 
            this.RVPajakBulanan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportPajakPerDokterBindingSource;
            this.RVPajakBulanan.LocalReport.DataSources.Add(reportDataSource1);
            this.RVPajakBulanan.LocalReport.ReportEmbeddedResource = "SIM_RS.LAPORAN_PRINOUT.reportan_perdokter.rdlc";
            this.RVPajakBulanan.Location = new System.Drawing.Point(3, 305);
            this.RVPajakBulanan.Name = "RVPajakBulanan";
            this.RVPajakBulanan.Size = new System.Drawing.Size(762, 129);
            this.RVPajakBulanan.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.btnCariLagi);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtNamaDokter);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 44);
            this.panel1.TabIndex = 3;
            // 
            // btnCariLagi
            // 
            this.btnCariLagi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCariLagi.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCariLagi.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCariLagi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariLagi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariLagi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariLagi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariLagi.ForeColor = System.Drawing.Color.White;
            this.btnCariLagi.Location = new System.Drawing.Point(665, 5);
            this.btnCariLagi.Name = "btnCariLagi";
            this.btnCariLagi.Size = new System.Drawing.Size(65, 29);
            this.btnCariLagi.TabIndex = 94;
            this.btnCariLagi.Text = "&BARU";
            this.btnCariLagi.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(554, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 29);
            this.button1.TabIndex = 92;
            this.button1.Text = "&TAMPILKAN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaDokter.Location = new System.Drawing.Point(111, 5);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(350, 33);
            this.txtNamaDokter.TabIndex = 93;
            this.txtNamaDokter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNamaDokter_KeyDown);
            this.txtNamaDokter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaDokter_KeyPress);
            this.txtNamaDokter.Leave += new System.EventHandler(this.txtNamaDokter_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(467, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 32);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "DOKTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.InfoProsesExcell);
            this.tabPage2.Controls.Add(this.RVRekapitulasiPajak);
            this.tabPage2.Controls.Add(this.lvPajakRekapitulasi);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REKAPITULASI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // InfoProsesExcell
            // 
            this.InfoProsesExcell.AutoSize = true;
            this.InfoProsesExcell.Location = new System.Drawing.Point(698, 277);
            this.InfoProsesExcell.Name = "InfoProsesExcell";
            this.InfoProsesExcell.Size = new System.Drawing.Size(28, 23);
            this.InfoProsesExcell.TabIndex = 125;
            this.InfoProsesExcell.Text = "...";
            this.InfoProsesExcell.Visible = false;
            // 
            // RVRekapitulasiPajak
            // 
            this.RVRekapitulasiPajak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RVRekapitulasiPajak.Location = new System.Drawing.Point(3, 475);
            this.RVRekapitulasiPajak.Name = "RVRekapitulasiPajak";
            this.RVRekapitulasiPajak.Size = new System.Drawing.Size(762, 255);
            this.RVRekapitulasiPajak.TabIndex = 122;
            // 
            // lvPajakRekapitulasi
            // 
            this.lvPajakRekapitulasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPajakRekapitulasi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvPajakRekapitulasi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPajakRekapitulasi.FullRowSelect = true;
            this.lvPajakRekapitulasi.GridLines = true;
            this.lvPajakRekapitulasi.HideSelection = false;
            this.lvPajakRekapitulasi.Location = new System.Drawing.Point(3, 46);
            this.lvPajakRekapitulasi.Name = "lvPajakRekapitulasi";
            this.lvPajakRekapitulasi.Size = new System.Drawing.Size(762, 388);
            this.lvPajakRekapitulasi.TabIndex = 118;
            this.lvPajakRekapitulasi.UseCompatibleStateImageBehavior = false;
            this.lvPajakRekapitulasi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "No";
            this.columnHeader4.Width = 41;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tgl SPJ";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nama Dokter";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Sblm Pajak";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Pajak";
            this.columnHeader11.Width = 121;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Stlh Pajak";
            this.columnHeader12.Width = 150;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.dtpRentang2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnTampilkan);
            this.panel3.Controls.Add(this.dtpRentang1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(762, 37);
            this.panel3.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(640, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 29);
            this.btnExport.TabIndex = 95;
            this.btnExport.Text = "&EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtpRentang2
            // 
            this.dtpRentang2.CustomFormat = "dd/mm/yyyy";
            this.dtpRentang2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRentang2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRentang2.Location = new System.Drawing.Point(395, 3);
            this.dtpRentang2.Name = "dtpRentang2";
            this.dtpRentang2.Size = new System.Drawing.Size(133, 32);
            this.dtpRentang2.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 23);
            this.label4.TabIndex = 93;
            this.label4.Text = "s/d";
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTampilkan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTampilkan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTampilkan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilkan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilkan.Location = new System.Drawing.Point(544, 4);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(90, 29);
            this.btnTampilkan.TabIndex = 92;
            this.btnTampilkan.Text = "&TAMPILKAN";
            this.btnTampilkan.UseVisualStyleBackColor = false;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // dtpRentang1
            // 
            this.dtpRentang1.CustomFormat = "dd/mm/yyyy";
            this.dtpRentang1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRentang1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRentang1.Location = new System.Drawing.Point(207, 2);
            this.dtpRentang1.Name = "dtpRentang1";
            this.dtpRentang1.Size = new System.Drawing.Size(133, 32);
            this.dtpRentang1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "RENTANG WAKTU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bwLoadDokter
            // 
            this.bwLoadDokter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadDokter_DoWork);
            // 
            // bwLoadPajak
            // 
            this.bwLoadPajak.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadPajak_DoWork);
            // 
            // cmsRubahTglSPJ
            // 
            this.cmsRubahTglSPJ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rubahTanggalSPJToolStripMenuItem});
            this.cmsRubahTglSPJ.Name = "cmsRubahTglSPJ";
            this.cmsRubahTglSPJ.Size = new System.Drawing.Size(175, 26);
            // 
            // rubahTanggalSPJToolStripMenuItem
            // 
            this.rubahTanggalSPJToolStripMenuItem.Name = "rubahTanggalSPJToolStripMenuItem";
            this.rubahTanggalSPJToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.rubahTanggalSPJToolStripMenuItem.Text = "Rubah Tanggal SPJ";
            this.rubahTanggalSPJToolStripMenuItem.Click += new System.EventHandler(this.rubahTanggalSPJToolStripMenuItem_Click);
            // 
            // bwRekapitulasi
            // 
            this.bwRekapitulasi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRekapitulasi_DoWork);
            // 
            // ReportPajakPerDokterBindingSource
            // 
            this.ReportPajakPerDokterBindingSource.DataSource = typeof(SIM_RS.RAWAT_INAP.ManajemenPajak.ReportPajakPerDokter);
            // 
            // ManajemenPajak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(793, 491);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManajemenPajak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManajemenPajak";
            this.Load += new System.EventHandler(this.ManajemenPajak_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cmsRubahTglSPJ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstPajakPerDokter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportPajakPerDokterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer RVPajakBulanan;
        private System.Windows.Forms.ListView lvPajakPerDokter;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.ComponentModel.BackgroundWorker bwLoadDokter;
        private System.Windows.Forms.Label lblKodeDokter;
        private System.Windows.Forms.Label lblNamaDokter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DateTimePicker dtpRentang1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bwLoadPajak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvPajakRekapitulasi;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.DateTimePicker dtpRentang2;
        private Microsoft.Reporting.WinForms.ReportViewer RVRekapitulasiPajak;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DateTimePicker dtpTglAmbil;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTglAmbil;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DateTimePicker dtpTglSPJ;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvDokterPajak;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ContextMenuStrip cmsRubahTglSPJ;
        private System.Windows.Forms.ToolStripMenuItem rubahTanggalSPJToolStripMenuItem;
        private System.Windows.Forms.Label lblIdPajak;
        private System.Windows.Forms.Button btnExport;
        private System.ComponentModel.BackgroundWorker bwRekapitulasi;
        private System.Windows.Forms.Label InfoProsesExcell;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnCariLagi;
        private System.Windows.Forms.BindingSource lstPajakPerDokter;
        private System.Windows.Forms.BindingSource ReportPajakPerDokterBindingSource;
    }
}