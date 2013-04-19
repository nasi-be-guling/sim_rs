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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.lvDetailTindakan = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIdTransaksi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKodeTarif = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblBiayaTindakan = new System.Windows.Forms.Label();
            this.lblKodeTindakan = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblDeskripsiTindakan = new System.Windows.Forms.Label();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFilterTgl2 = new System.Windows.Forms.DateTimePicker();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.dtpFilterTgl1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.cmsPerbaikan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rubahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.lblJumlahTindakan = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsPerbaikan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Controls.Add(this.btnBatal);
            this.panel1.Controls.Add(this.btnSimpan);
            this.panel1.Controls.Add(this.lvDetailTindakan);
            this.panel1.Controls.Add(this.txtNamaDokter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblIdTransaksi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblKodeTarif);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.lblBiayaTindakan);
            this.panel1.Controls.Add(this.lblKodeTindakan);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblDeskripsiTindakan);
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(4, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 465);
            this.panel1.TabIndex = 113;
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader14});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(4, 24);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(784, 157);
            this.lvDaftarTindakan.TabIndex = 75;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            this.lvDaftarTindakan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDaftarTindakan_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No Billing";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tgl Transaksi";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kode Tindakan";
            this.columnHeader5.Width = 135;
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
            // columnHeader6
            // 
            this.columnHeader6.Text = "Id Transaksi";
            this.columnHeader6.Width = 93;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Ruang";
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnBatal.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatal.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(687, 429);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(101, 26);
            this.btnBatal.TabIndex = 124;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnSimpan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(580, 429);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(101, 26);
            this.btnSimpan.TabIndex = 123;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // lvDetailTindakan
            // 
            this.lvDetailTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDetailTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvDetailTindakan.FullRowSelect = true;
            this.lvDetailTindakan.GridLines = true;
            this.lvDetailTindakan.HideSelection = false;
            this.lvDetailTindakan.Location = new System.Drawing.Point(5, 300);
            this.lvDetailTindakan.Name = "lvDetailTindakan";
            this.lvDetailTindakan.Size = new System.Drawing.Size(783, 126);
            this.lvDetailTindakan.TabIndex = 122;
            this.lvDetailTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDetailTindakan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Kode Tarif";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Id Komponen";
            this.columnHeader8.Width = 106;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Nilai Komponen";
            this.columnHeader9.Width = 130;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Hak 1";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Hak 2";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Hak 3";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Prioritas Tunai";
            this.columnHeader13.Width = 126;
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamaDokter.BackColor = System.Drawing.Color.White;
            this.txtNamaDokter.Location = new System.Drawing.Point(117, 267);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(612, 27);
            this.txtNamaDokter.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 120;
            this.label7.Text = "Kode Dokter : ";
            // 
            // lblIdTransaksi
            // 
            this.lblIdTransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdTransaksi.AutoSize = true;
            this.lblIdTransaksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblIdTransaksi.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTransaksi.ForeColor = System.Drawing.Color.Black;
            this.lblIdTransaksi.Location = new System.Drawing.Point(114, 184);
            this.lblIdTransaksi.Name = "lblIdTransaksi";
            this.lblIdTransaksi.Size = new System.Drawing.Size(23, 18);
            this.lblIdTransaksi.TabIndex = 119;
            this.lblIdTransaksi.Text = "...";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 118;
            this.label5.Text = "Id Transaksi :";
            // 
            // lblKodeTarif
            // 
            this.lblKodeTarif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKodeTarif.AutoSize = true;
            this.lblKodeTarif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblKodeTarif.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeTarif.ForeColor = System.Drawing.Color.Black;
            this.lblKodeTarif.Location = new System.Drawing.Point(114, 211);
            this.lblKodeTarif.Name = "lblKodeTarif";
            this.lblKodeTarif.Size = new System.Drawing.Size(23, 18);
            this.lblKodeTarif.TabIndex = 117;
            this.lblKodeTarif.Text = "...";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(191, 241);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 18);
            this.label22.TabIndex = 116;
            this.label22.Text = "Deskripsi :";
            // 
            // lblBiayaTindakan
            // 
            this.lblBiayaTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBiayaTindakan.AutoSize = true;
            this.lblBiayaTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblBiayaTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiayaTindakan.ForeColor = System.Drawing.Color.Black;
            this.lblBiayaTindakan.Location = new System.Drawing.Point(114, 241);
            this.lblBiayaTindakan.Name = "lblBiayaTindakan";
            this.lblBiayaTindakan.Size = new System.Drawing.Size(23, 18);
            this.lblBiayaTindakan.TabIndex = 115;
            this.lblBiayaTindakan.Text = "...";
            // 
            // lblKodeTindakan
            // 
            this.lblKodeTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKodeTindakan.AutoSize = true;
            this.lblKodeTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblKodeTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeTindakan.Location = new System.Drawing.Point(4, 211);
            this.lblKodeTindakan.Name = "lblKodeTindakan";
            this.lblKodeTindakan.Size = new System.Drawing.Size(91, 18);
            this.lblKodeTindakan.TabIndex = 112;
            this.lblKodeTindakan.Text = "K&ode Tarif : ";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 241);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 18);
            this.label17.TabIndex = 114;
            this.label17.Text = "Biaya : ";
            // 
            // lblDeskripsiTindakan
            // 
            this.lblDeskripsiTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeskripsiTindakan.AutoSize = true;
            this.lblDeskripsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblDeskripsiTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeskripsiTindakan.ForeColor = System.Drawing.Color.Black;
            this.lblDeskripsiTindakan.Location = new System.Drawing.Point(268, 241);
            this.lblDeskripsiTindakan.Name = "lblDeskripsiTindakan";
            this.lblDeskripsiTindakan.Size = new System.Drawing.Size(23, 18);
            this.lblDeskripsiTindakan.TabIndex = 113;
            this.lblDeskripsiTindakan.Text = "...";
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
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpFilterTgl2);
            this.panel2.Controls.Add(this.lblInfoPencarian);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.dtpFilterTgl1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 45);
            this.panel2.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "-";
            // 
            // dtpFilterTgl2
            // 
            this.dtpFilterTgl2.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl2.Location = new System.Drawing.Point(318, 9);
            this.dtpFilterTgl2.Name = "dtpFilterTgl2";
            this.dtpFilterTgl2.Size = new System.Drawing.Size(186, 27);
            this.dtpFilterTgl2.TabIndex = 98;
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Location = new System.Drawing.Point(660, 16);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(128, 20);
            this.lblInfoPencarian.TabIndex = 97;
            this.lblInfoPencarian.Text = "Proses Pencarian...";
            this.lblInfoPencarian.Visible = false;
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCari.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCari.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(553, 6);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(101, 30);
            this.btnCari.TabIndex = 96;
            this.btnCari.Text = "&CARI";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // dtpFilterTgl1
            // 
            this.dtpFilterTgl1.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl1.Location = new System.Drawing.Point(102, 9);
            this.dtpFilterTgl1.Name = "dtpFilterTgl1";
            this.dtpFilterTgl1.Size = new System.Drawing.Size(189, 27);
            this.dtpFilterTgl1.TabIndex = 1;
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
            // cmsPerbaikan
            // 
            this.cmsPerbaikan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rubahToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportExcelToolStripMenuItem});
            this.cmsPerbaikan.Name = "cmsPerbaikan";
            this.cmsPerbaikan.Size = new System.Drawing.Size(137, 54);
            // 
            // rubahToolStripMenuItem
            // 
            this.rubahToolStripMenuItem.Name = "rubahToolStripMenuItem";
            this.rubahToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.rubahToolStripMenuItem.Text = "Rubah";
            this.rubahToolStripMenuItem.Click += new System.EventHandler(this.rubahToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportExcelToolStripMenuItem.Text = "Export Excel";
            this.exportExcelToolStripMenuItem.Click += new System.EventHandler(this.exportExcelToolStripMenuItem_Click);
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // lblJumlahTindakan
            // 
            this.lblJumlahTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJumlahTindakan.AutoSize = true;
            this.lblJumlahTindakan.Location = new System.Drawing.Point(7, 535);
            this.lblJumlahTindakan.Name = "lblJumlahTindakan";
            this.lblJumlahTindakan.Size = new System.Drawing.Size(239, 20);
            this.lblJumlahTindakan.TabIndex = 117;
            this.lblJumlahTindakan.Text = "Jumlah tindakan yang tidak tepat : ";
            // 
            // LapCheckTransAndDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.lblJumlahTindakan);
            this.Controls.Add(this.btnKeluar);
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
            this.panel2.PerformLayout();
            this.cmsPerbaikan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl1;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblKodeTarif;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblBiayaTindakan;
        private System.Windows.Forms.Label lblKodeTindakan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblDeskripsiTindakan;
        private System.Windows.Forms.Label lblIdTransaksi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvDetailTindakan;
        public System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ContextMenuStrip cmsPerbaikan;
        private System.Windows.Forms.ToolStripMenuItem rubahToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ToolStripMenuItem exportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Label lblInfoPencarian;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl2;
        private System.Windows.Forms.Label lblJumlahTindakan;
    }
}