namespace SIM_RS.RAWAT_INAP
{
    partial class inputTindakan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoBilling = new System.Windows.Forms.TextBox();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTglTindakan = new System.Windows.Forms.DateTimePicker();
            this.lblTempatLayanan = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblKodeTindakan = new System.Windows.Forms.Label();
            this.txtKodeTindakan = new System.Windows.Forms.TextBox();
            this.lblDeskripsiTindakan = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblBiayaTindakan = new System.Windows.Forms.Label();
            this.btnTambahTindakan = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPetugas = new System.Windows.Forms.Label();
            this.btnSimpanIsiTindakan = new System.Windows.Forms.Button();
            this.btnKeluarIsiTindakan = new System.Windows.Forms.Button();
            this.cmsDaftarTindakan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hapusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDokter = new System.Windows.Forms.Label();
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.txtTempatLayanan = new System.Windows.Forms.TextBox();
            this.btnTampilDaftarTindakan = new System.Windows.Forms.Button();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatusPasien = new System.Windows.Forms.Label();
            this.lblKelas = new System.Windows.Forms.Label();
            this.lblRuangan = new System.Windows.Forms.Label();
            this.lblMRPasien = new System.Windows.Forms.Label();
            this.lblAlamatPasien = new System.Windows.Forms.Label();
            this.lblNamaPasien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnBatalTindakan = new System.Windows.Forms.Button();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsDaftarTindakan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "NO REGISTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoBilling
            // 
            this.txtNoBilling.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoBilling.BackColor = System.Drawing.Color.White;
            this.txtNoBilling.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBilling.Location = new System.Drawing.Point(193, 8);
            this.txtNoBilling.Name = "txtNoBilling";
            this.txtNoBilling.Size = new System.Drawing.Size(188, 30);
            this.txtNoBilling.TabIndex = 1;
            this.txtNoBilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoBilling.Enter += new System.EventHandler(this.txtNoBilling_Enter);
            this.txtNoBilling.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoBilling_KeyPress);
            this.txtNoBilling.Leave += new System.EventHandler(this.txtNoBilling_Leave);
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(10, 28);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(987, 246);
            this.lvDaftarTindakan.TabIndex = 75;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            this.lvDaftarTindakan.Enter += new System.EventHandler(this.lvDaftarTindakan_Enter);
            this.lvDaftarTindakan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvDaftarTindakan_KeyDown);
            this.lvDaftarTindakan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvDaftarTindakan_KeyPress);
            this.lvDaftarTindakan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDaftarTindakan_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "No";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kode Tindakan";
            this.columnHeader1.Width = 129;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Uraian Tindakan";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Komponen";
            this.columnHeader3.Width = 108;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Biaya";
            this.columnHeader4.Width = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 18);
            this.label10.TabIndex = 76;
            this.label10.Text = "Tanggal : ";
            // 
            // dtpTglTindakan
            // 
            this.dtpTglTindakan.CustomFormat = "dd MMMM yyyy";
            this.dtpTglTindakan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTglTindakan.Location = new System.Drawing.Point(148, 32);
            this.dtpTglTindakan.Name = "dtpTglTindakan";
            this.dtpTglTindakan.Size = new System.Drawing.Size(188, 26);
            this.dtpTglTindakan.TabIndex = 77;
            this.dtpTglTindakan.Enter += new System.EventHandler(this.dtpTglTindakan_Enter);
            // 
            // lblTempatLayanan
            // 
            this.lblTempatLayanan.AutoSize = true;
            this.lblTempatLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblTempatLayanan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempatLayanan.Location = new System.Drawing.Point(27, 67);
            this.lblTempatLayanan.Name = "lblTempatLayanan";
            this.lblTempatLayanan.Size = new System.Drawing.Size(112, 18);
            this.lblTempatLayanan.TabIndex = 78;
            this.lblTempatLayanan.Text = "&Tmpt Layanan :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(533, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 18);
            this.label12.TabIndex = 80;
            this.label12.Text = "No Transaksi : ";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(645, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 18);
            this.label13.TabIndex = 81;
            this.label13.Text = "...";
            this.label13.Visible = false;
            // 
            // lblKodeTindakan
            // 
            this.lblKodeTindakan.AutoSize = true;
            this.lblKodeTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblKodeTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeTindakan.Location = new System.Drawing.Point(27, 99);
            this.lblKodeTindakan.Name = "lblKodeTindakan";
            this.lblKodeTindakan.Size = new System.Drawing.Size(91, 18);
            this.lblKodeTindakan.TabIndex = 83;
            this.lblKodeTindakan.Text = "K&ode Tarif : ";
            // 
            // txtKodeTindakan
            // 
            this.txtKodeTindakan.BackColor = System.Drawing.Color.White;
            this.txtKodeTindakan.Location = new System.Drawing.Point(148, 96);
            this.txtKodeTindakan.Name = "txtKodeTindakan";
            this.txtKodeTindakan.Size = new System.Drawing.Size(612, 26);
            this.txtKodeTindakan.TabIndex = 84;
            this.txtKodeTindakan.Enter += new System.EventHandler(this.txtKodeTindakan_Enter);
            this.txtKodeTindakan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKodeTindakan_KeyDown);
            this.txtKodeTindakan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKodeTindakan_KeyPress);
            this.txtKodeTindakan.Leave += new System.EventHandler(this.txtKodeTindakan_Leave);
            // 
            // lblDeskripsiTindakan
            // 
            this.lblDeskripsiTindakan.AutoSize = true;
            this.lblDeskripsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblDeskripsiTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeskripsiTindakan.ForeColor = System.Drawing.Color.Black;
            this.lblDeskripsiTindakan.Location = new System.Drawing.Point(373, 125);
            this.lblDeskripsiTindakan.Name = "lblDeskripsiTindakan";
            this.lblDeskripsiTindakan.Size = new System.Drawing.Size(23, 18);
            this.lblDeskripsiTindakan.TabIndex = 85;
            this.lblDeskripsiTindakan.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(145, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 18);
            this.label17.TabIndex = 86;
            this.label17.Text = "Biaya : ";
            // 
            // lblBiayaTindakan
            // 
            this.lblBiayaTindakan.AutoSize = true;
            this.lblBiayaTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblBiayaTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiayaTindakan.ForeColor = System.Drawing.Color.Black;
            this.lblBiayaTindakan.Location = new System.Drawing.Point(198, 125);
            this.lblBiayaTindakan.Name = "lblBiayaTindakan";
            this.lblBiayaTindakan.Size = new System.Drawing.Size(23, 18);
            this.lblBiayaTindakan.TabIndex = 87;
            this.lblBiayaTindakan.Text = "...";
            // 
            // btnTambahTindakan
            // 
            this.btnTambahTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnTambahTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTambahTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTambahTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahTindakan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahTindakan.Location = new System.Drawing.Point(766, 178);
            this.btnTambahTindakan.Name = "btnTambahTindakan";
            this.btnTambahTindakan.Size = new System.Drawing.Size(33, 26);
            this.btnTambahTindakan.TabIndex = 91;
            this.btnTambahTindakan.Text = "&+";
            this.btnTambahTindakan.UseVisualStyleBackColor = false;
            this.btnTambahTindakan.Click += new System.EventHandler(this.btnTambahTindakan_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(296, 125);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 18);
            this.label22.TabIndex = 92;
            this.label22.Text = "Deskripsi :";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 43);
            this.label23.TabIndex = 93;
            this.label23.Text = "PETUGAS : ";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPetugas
            // 
            this.lblPetugas.AutoSize = true;
            this.lblPetugas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblPetugas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetugas.ForeColor = System.Drawing.Color.Black;
            this.lblPetugas.Location = new System.Drawing.Point(128, 9);
            this.lblPetugas.Name = "lblPetugas";
            this.lblPetugas.Size = new System.Drawing.Size(27, 25);
            this.lblPetugas.TabIndex = 94;
            this.lblPetugas.Text = "...";
            // 
            // btnSimpanIsiTindakan
            // 
            this.btnSimpanIsiTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimpanIsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnSimpanIsiTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpanIsiTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpanIsiTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanIsiTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanIsiTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpanIsiTindakan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanIsiTindakan.Location = new System.Drawing.Point(807, 726);
            this.btnSimpanIsiTindakan.Name = "btnSimpanIsiTindakan";
            this.btnSimpanIsiTindakan.Size = new System.Drawing.Size(101, 30);
            this.btnSimpanIsiTindakan.TabIndex = 95;
            this.btnSimpanIsiTindakan.Text = "&SIMPAN";
            this.btnSimpanIsiTindakan.UseVisualStyleBackColor = false;
            this.btnSimpanIsiTindakan.Click += new System.EventHandler(this.btnSimpanIsiTindakan_Click);
            // 
            // btnKeluarIsiTindakan
            // 
            this.btnKeluarIsiTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKeluarIsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluarIsiTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluarIsiTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluarIsiTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarIsiTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarIsiTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluarIsiTindakan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarIsiTindakan.Location = new System.Drawing.Point(914, 726);
            this.btnKeluarIsiTindakan.Name = "btnKeluarIsiTindakan";
            this.btnKeluarIsiTindakan.Size = new System.Drawing.Size(101, 30);
            this.btnKeluarIsiTindakan.TabIndex = 96;
            this.btnKeluarIsiTindakan.Text = "&KELUAR";
            this.btnKeluarIsiTindakan.UseVisualStyleBackColor = false;
            this.btnKeluarIsiTindakan.Click += new System.EventHandler(this.btnKeluarIsiTindakan_Click);
            // 
            // cmsDaftarTindakan
            // 
            this.cmsDaftarTindakan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hapusToolStripMenuItem});
            this.cmsDaftarTindakan.Name = "cmsDaftarTindakan";
            this.cmsDaftarTindakan.Size = new System.Drawing.Size(109, 26);
            // 
            // hapusToolStripMenuItem
            // 
            this.hapusToolStripMenuItem.Name = "hapusToolStripMenuItem";
            this.hapusToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.hapusToolStripMenuItem.Text = "Hapus";
            this.hapusToolStripMenuItem.Click += new System.EventHandler(this.hapusToolStripMenuItem_Click);
            // 
            // lblDokter
            // 
            this.lblDokter.AutoSize = true;
            this.lblDokter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblDokter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDokter.Location = new System.Drawing.Point(27, 181);
            this.lblDokter.Name = "lblDokter";
            this.lblDokter.Size = new System.Drawing.Size(66, 18);
            this.lblDokter.TabIndex = 99;
            this.lblDokter.Text = "&Dokter : ";
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.BackColor = System.Drawing.Color.White;
            this.txtNamaDokter.Location = new System.Drawing.Point(148, 178);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(612, 26);
            this.txtNamaDokter.TabIndex = 100;
            this.txtNamaDokter.Enter += new System.EventHandler(this.txtNamaDokter_Enter);
            this.txtNamaDokter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNamaDokter_KeyDown);
            this.txtNamaDokter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaDokter_KeyPress);
            this.txtNamaDokter.Leave += new System.EventHandler(this.txtNamaDokter_Leave);
            // 
            // txtTempatLayanan
            // 
            this.txtTempatLayanan.BackColor = System.Drawing.Color.White;
            this.txtTempatLayanan.Location = new System.Drawing.Point(148, 64);
            this.txtTempatLayanan.Name = "txtTempatLayanan";
            this.txtTempatLayanan.Size = new System.Drawing.Size(285, 26);
            this.txtTempatLayanan.TabIndex = 104;
            this.txtTempatLayanan.Enter += new System.EventHandler(this.txtTempatLayanan_Enter);
            this.txtTempatLayanan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempatLayanan_KeyDown);
            this.txtTempatLayanan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempatLayanan_KeyPress);
            this.txtTempatLayanan.Leave += new System.EventHandler(this.txtTempatLayanan_Leave);
            // 
            // btnTampilDaftarTindakan
            // 
            this.btnTampilDaftarTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnTampilDaftarTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTampilDaftarTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilDaftarTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilDaftarTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilDaftarTindakan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilDaftarTindakan.Location = new System.Drawing.Point(766, 96);
            this.btnTampilDaftarTindakan.Name = "btnTampilDaftarTindakan";
            this.btnTampilDaftarTindakan.Size = new System.Drawing.Size(33, 26);
            this.btnTampilDaftarTindakan.TabIndex = 105;
            this.btnTampilDaftarTindakan.Text = "&#";
            this.btnTampilDaftarTindakan.UseVisualStyleBackColor = false;
            this.btnTampilDaftarTindakan.Click += new System.EventHandler(this.btnTampilDaftarTindakan_Click);
            this.btnTampilDaftarTindakan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnTampilDaftarTindakan_KeyPress);
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(8, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 284);
            this.panel1.TabIndex = 112;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.lblInfoPencarian);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNoBilling);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 45);
            this.panel2.TabIndex = 113;
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPencarian.Location = new System.Drawing.Point(581, 14);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(203, 20);
            this.lblInfoPencarian.TabIndex = 2;
            this.lblInfoPencarian.Text = "Proses Menampilkan Data...";
            this.lblInfoPencarian.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.lblPetugas);
            this.panel3.Location = new System.Drawing.Point(8, 713);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 43);
            this.panel3.TabIndex = 114;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(867, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 27);
            this.button1.TabIndex = 115;
            this.button1.Text = "&Cetak";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 1000;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel4.Controls.Add(this.lblStatusPasien);
            this.panel4.Controls.Add(this.lblKelas);
            this.panel4.Controls.Add(this.lblRuangan);
            this.panel4.Controls.Add(this.lblMRPasien);
            this.panel4.Controls.Add(this.lblAlamatPasien);
            this.panel4.Controls.Add(this.lblNamaPasien);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(8, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1007, 123);
            this.panel4.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 111;
            this.label3.Text = "DATA SOSIAL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusPasien
            // 
            this.lblStatusPasien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatusPasien.AutoSize = true;
            this.lblStatusPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblStatusPasien.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPasien.ForeColor = System.Drawing.Color.Black;
            this.lblStatusPasien.Location = new System.Drawing.Point(647, 58);
            this.lblStatusPasien.Name = "lblStatusPasien";
            this.lblStatusPasien.Size = new System.Drawing.Size(23, 18);
            this.lblStatusPasien.TabIndex = 123;
            this.lblStatusPasien.Text = "...";
            // 
            // lblKelas
            // 
            this.lblKelas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKelas.AutoSize = true;
            this.lblKelas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblKelas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKelas.ForeColor = System.Drawing.Color.Black;
            this.lblKelas.Location = new System.Drawing.Point(647, 31);
            this.lblKelas.Name = "lblKelas";
            this.lblKelas.Size = new System.Drawing.Size(23, 18);
            this.lblKelas.TabIndex = 122;
            this.lblKelas.Text = "...";
            // 
            // lblRuangan
            // 
            this.lblRuangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRuangan.AutoSize = true;
            this.lblRuangan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblRuangan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuangan.ForeColor = System.Drawing.Color.Black;
            this.lblRuangan.Location = new System.Drawing.Point(341, 31);
            this.lblRuangan.Name = "lblRuangan";
            this.lblRuangan.Size = new System.Drawing.Size(23, 18);
            this.lblRuangan.TabIndex = 121;
            this.lblRuangan.Text = "...";
            // 
            // lblMRPasien
            // 
            this.lblMRPasien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMRPasien.AutoSize = true;
            this.lblMRPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblMRPasien.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRPasien.ForeColor = System.Drawing.Color.Black;
            this.lblMRPasien.Location = new System.Drawing.Point(119, 31);
            this.lblMRPasien.Name = "lblMRPasien";
            this.lblMRPasien.Size = new System.Drawing.Size(23, 18);
            this.lblMRPasien.TabIndex = 118;
            this.lblMRPasien.Text = "...";
            // 
            // lblAlamatPasien
            // 
            this.lblAlamatPasien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlamatPasien.AutoSize = true;
            this.lblAlamatPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblAlamatPasien.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamatPasien.ForeColor = System.Drawing.Color.Black;
            this.lblAlamatPasien.Location = new System.Drawing.Point(118, 85);
            this.lblAlamatPasien.Name = "lblAlamatPasien";
            this.lblAlamatPasien.Size = new System.Drawing.Size(28, 23);
            this.lblAlamatPasien.TabIndex = 120;
            this.lblAlamatPasien.Text = "...";
            // 
            // lblNamaPasien
            // 
            this.lblNamaPasien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNamaPasien.AutoSize = true;
            this.lblNamaPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblNamaPasien.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaPasien.ForeColor = System.Drawing.Color.Black;
            this.lblNamaPasien.Location = new System.Drawing.Point(118, 54);
            this.lblNamaPasien.Name = "lblNamaPasien";
            this.lblNamaPasien.Size = new System.Drawing.Size(28, 23);
            this.lblNamaPasien.TabIndex = 119;
            this.lblNamaPasien.Text = "...";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(584, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 117;
            this.label8.Text = "Status : ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 116;
            this.label7.Text = "Alamat : ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 115;
            this.label6.Text = "Kelas : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 114;
            this.label5.Text = "Nama : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 113;
            this.label4.Text = "Ruangan : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 112;
            this.label2.Text = "No. KUIP : ";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel5.Controls.Add(this.btnBatalTindakan);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.dtpTglTindakan);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtNamaDokter);
            this.panel5.Controls.Add(this.lblTempatLayanan);
            this.panel5.Controls.Add(this.lblDeskripsiTindakan);
            this.panel5.Controls.Add(this.txtKodeTindakan);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.lblKodeTindakan);
            this.panel5.Controls.Add(this.btnTampilDaftarTindakan);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.txtTempatLayanan);
            this.panel5.Controls.Add(this.lblBiayaTindakan);
            this.panel5.Controls.Add(this.lblDokter);
            this.panel5.Controls.Add(this.btnTambahTindakan);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(8, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1007, 225);
            this.panel5.TabIndex = 117;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 111;
            this.label9.Text = "I&NPUT TINDAKAN ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 112;
            this.label11.Text = "&Komponen";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(148, 146);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 26);
            this.comboBox1.TabIndex = 113;
            // 
            // btnBatalTindakan
            // 
            this.btnBatalTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnBatalTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatalTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatalTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatalTindakan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatalTindakan.Location = new System.Drawing.Point(805, 96);
            this.btnBatalTindakan.Name = "btnBatalTindakan";
            this.btnBatalTindakan.Size = new System.Drawing.Size(59, 26);
            this.btnBatalTindakan.TabIndex = 114;
            this.btnBatalTindakan.Text = "&BATAL";
            this.btnBatalTindakan.UseVisualStyleBackColor = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dokter";
            this.columnHeader6.Width = 74;
            // 
            // inputTindakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKeluarIsiTindakan);
            this.Controls.Add(this.btnSimpanIsiTindakan);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputTindakan";
            this.Text = "INPUT TINDAKAN BILLING";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inputTindakan_FormClosing);
            this.Load += new System.EventHandler(this.inputTindakan_Load);
            this.Shown += new System.EventHandler(this.inputTindakan_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTindakan_KeyPress);
            this.cmsDaftarTindakan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoBilling;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpTglTindakan;
        private System.Windows.Forms.Label lblTempatLayanan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblKodeTindakan;
        private System.Windows.Forms.Label lblDeskripsiTindakan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblBiayaTindakan;
        private System.Windows.Forms.Button btnTambahTindakan;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPetugas;
        private System.Windows.Forms.Button btnSimpanIsiTindakan;
        private System.Windows.Forms.Button btnKeluarIsiTindakan;
        private System.Windows.Forms.ContextMenuStrip cmsDaftarTindakan;
        private System.Windows.Forms.ToolStripMenuItem hapusToolStripMenuItem;
        private System.Windows.Forms.Label lblDokter;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtTempatLayanan;
        public System.Windows.Forms.TextBox txtKodeTindakan;
        public System.Windows.Forms.Button btnTampilDaftarTindakan;
        public System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Label lblInfoPencarian;
        private System.Windows.Forms.Timer timerBlink;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStatusPasien;
        private System.Windows.Forms.Label lblKelas;
        private System.Windows.Forms.Label lblRuangan;
        private System.Windows.Forms.Label lblMRPasien;
        private System.Windows.Forms.Label lblAlamatPasien;
        private System.Windows.Forms.Label lblNamaPasien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnBatalTindakan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
    }
}

