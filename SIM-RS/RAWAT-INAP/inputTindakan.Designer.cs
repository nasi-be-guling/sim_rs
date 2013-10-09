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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoBilling = new System.Windows.Forms.TextBox();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.hapusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDokter = new System.Windows.Forms.Label();
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.txtTempatLayanan = new System.Windows.Forms.TextBox();
            this.btnTampilDaftarTarif = new System.Windows.Forms.Button();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTambahKompDokter = new System.Windows.Forms.Button();
            this.btnDaftarKompTarif = new System.Windows.Forms.Button();
            this.btnBatalTindakan = new System.Windows.Forms.Button();
            this.cmbKomponenTarif = new System.Windows.Forms.ComboBox();
            this.lblKomponen = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bgWorkLoadDataInit = new System.ComponentModel.BackgroundWorker();
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
            this.label1.Size = new System.Drawing.Size(184, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "NO REGISTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoBilling
            // 
            this.txtNoBilling.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoBilling.BackColor = System.Drawing.Color.White;
            this.txtNoBilling.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBilling.Location = new System.Drawing.Point(190, 9);
            this.txtNoBilling.Name = "txtNoBilling";
            this.txtNoBilling.Size = new System.Drawing.Size(188, 30);
            this.txtNoBilling.TabIndex = 1;
            this.txtNoBilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoBilling.Enter += new System.EventHandler(this.txtNoBilling_Enter);
            this.txtNoBilling.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoBilling_KeyPress);
            this.txtNoBilling.Leave += new System.EventHandler(this.txtNoBilling_Leave);
            // 
////<<<<<<< HEAD
//            // label2
//            // 
//            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label2.AutoSize = true;
//            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(16, 66);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(84, 18);
//            this.label2.TabIndex = 65;
//            this.label2.Text = "No. KUIP : ";
//            // 
//            // label4
//            // 
//            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label4.AutoSize = true;
//            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.Location = new System.Drawing.Point(235, 66);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(80, 18);
//            this.label4.TabIndex = 67;
//            this.label4.Text = "Ruangan : ";
//            // 
//            // label5
//            // 
//            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label5.AutoSize = true;
//            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.Location = new System.Drawing.Point(16, 93);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(62, 18);
//            this.label5.TabIndex = 69;
//            this.label5.Text = "Nama : ";
//            // 
//            // label6
//            // 
//            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label6.AutoSize = true;
//            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.Location = new System.Drawing.Point(573, 66);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(57, 18);
//            this.label6.TabIndex = 71;
//            this.label6.Text = "Kelas : ";
//            // 
//            // label7
//            // 
//            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label7.AutoSize = true;
//            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label7.Location = new System.Drawing.Point(16, 124);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(68, 18);
//            this.label7.TabIndex = 72;
//            this.label7.Text = "Alamat : ";
//            // 
//            // label8
//            // 
//            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.label8.AutoSize = true;
//            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
//            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label8.Location = new System.Drawing.Point(573, 93);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(64, 18);
//            this.label8.TabIndex = 73;
//            this.label8.Text = "Status : ";
//            // 
//=======
//>>>>>>> 25a2cd9f69d4d6b452a300099c4fec092dda4569
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
            this.lvDaftarTindakan.Location = new System.Drawing.Point(6, 25);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(994, 179);
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
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dokter";
            this.columnHeader6.Width = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 18);
            this.label10.TabIndex = 76;
            this.label10.Text = "Tanggal : ";
            // 
            // dtpTglTindakan
            // 
            this.dtpTglTindakan.CustomFormat = "dd MMMM yyyy";
            this.dtpTglTindakan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTglTindakan.Location = new System.Drawing.Point(148, 36);
            this.dtpTglTindakan.Name = "dtpTglTindakan";
            this.dtpTglTindakan.Size = new System.Drawing.Size(188, 27);
            this.dtpTglTindakan.TabIndex = 77;
            this.dtpTglTindakan.Enter += new System.EventHandler(this.dtpTglTindakan_Enter);
            // 
            // lblTempatLayanan
            // 
            this.lblTempatLayanan.AutoSize = true;
            this.lblTempatLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblTempatLayanan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempatLayanan.Location = new System.Drawing.Point(27, 74);
            this.lblTempatLayanan.Name = "lblTempatLayanan";
            this.lblTempatLayanan.Size = new System.Drawing.Size(114, 18);
            this.lblTempatLayanan.TabIndex = 78;
            this.lblTempatLayanan.Text = "&Tmpt Layanan :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(533, 42);
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
            this.label13.Location = new System.Drawing.Point(645, 42);
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
            this.lblKodeTindakan.Location = new System.Drawing.Point(27, 122);
            this.lblKodeTindakan.Name = "lblKodeTindakan";
            this.lblKodeTindakan.Size = new System.Drawing.Size(120, 18);
            this.lblKodeTindakan.TabIndex = 83;
            this.lblKodeTindakan.Text = "K&ode Tindakan : ";
            // 
            // txtKodeTindakan
            // 
            this.txtKodeTindakan.BackColor = System.Drawing.Color.White;
            this.txtKodeTindakan.Location = new System.Drawing.Point(148, 119);
            this.txtKodeTindakan.Name = "txtKodeTindakan";
            this.txtKodeTindakan.Size = new System.Drawing.Size(612, 27);
            this.txtKodeTindakan.TabIndex = 84;
            this.txtKodeTindakan.Enter += new System.EventHandler(this.txtKodeTindakan_Enter);
            this.txtKodeTindakan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKodeTindakan_KeyDown);
            this.txtKodeTindakan.Leave += new System.EventHandler(this.txtKodeTindakan_Leave);
            // 
            // lblDeskripsiTindakan
            // 
            this.lblDeskripsiTindakan.AutoSize = true;
            this.lblDeskripsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblDeskripsiTindakan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeskripsiTindakan.ForeColor = System.Drawing.Color.Black;
            this.lblDeskripsiTindakan.Location = new System.Drawing.Point(373, 151);
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
            this.label17.Location = new System.Drawing.Point(145, 151);
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
            this.lblBiayaTindakan.Location = new System.Drawing.Point(198, 151);
            this.lblBiayaTindakan.Name = "lblBiayaTindakan";
            this.lblBiayaTindakan.Size = new System.Drawing.Size(23, 18);
            this.lblBiayaTindakan.TabIndex = 87;
            this.lblBiayaTindakan.Text = "...";
            // 
            // btnTambahTindakan
            // 
            this.btnTambahTindakan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTambahTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTambahTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTambahTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahTindakan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahTindakan.Location = new System.Drawing.Point(789, 247);
            this.btnTambahTindakan.Name = "btnTambahTindakan";
            this.btnTambahTindakan.Size = new System.Drawing.Size(138, 33);
            this.btnTambahTindakan.TabIndex = 91;
            this.btnTambahTindakan.Text = "&TAMBAH TINDAKAN";
            this.btnTambahTindakan.UseVisualStyleBackColor = false;
            this.btnTambahTindakan.Click += new System.EventHandler(this.btnTambahTindakan_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(296, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 18);
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
            this.label23.Size = new System.Drawing.Size(126, 48);
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
            this.lblPetugas.Location = new System.Drawing.Point(128, 10);
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
            this.btnSimpanIsiTindakan.Location = new System.Drawing.Point(807, 731);
            this.btnSimpanIsiTindakan.Name = "btnSimpanIsiTindakan";
            this.btnSimpanIsiTindakan.Size = new System.Drawing.Size(101, 33);
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
            this.btnKeluarIsiTindakan.Location = new System.Drawing.Point(914, 731);
            this.btnKeluarIsiTindakan.Name = "btnKeluarIsiTindakan";
            this.btnKeluarIsiTindakan.Size = new System.Drawing.Size(101, 33);
            this.btnKeluarIsiTindakan.TabIndex = 96;
            this.btnKeluarIsiTindakan.Text = "&KELUAR";
            this.btnKeluarIsiTindakan.UseVisualStyleBackColor = false;
            this.btnKeluarIsiTindakan.Click += new System.EventHandler(this.btnKeluarIsiTindakan_Click);
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
            this.lblDokter.Location = new System.Drawing.Point(27, 213);
            this.lblDokter.Name = "lblDokter";
            this.lblDokter.Size = new System.Drawing.Size(66, 18);
            this.lblDokter.TabIndex = 99;
            this.lblDokter.Text = "&Dokter : ";
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.BackColor = System.Drawing.Color.White;
            this.txtNamaDokter.Location = new System.Drawing.Point(148, 210);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(612, 27);
            this.txtNamaDokter.TabIndex = 100;
            this.txtNamaDokter.Enter += new System.EventHandler(this.txtNamaDokter_Enter);
            this.txtNamaDokter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNamaDokter_KeyDown);
            this.txtNamaDokter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaDokter_KeyPress);
            this.txtNamaDokter.Leave += new System.EventHandler(this.txtNamaDokter_Leave);
            // 
            // txtTempatLayanan
            // 
            this.txtTempatLayanan.BackColor = System.Drawing.Color.White;
            this.txtTempatLayanan.Location = new System.Drawing.Point(148, 71);
            this.txtTempatLayanan.Name = "txtTempatLayanan";
            this.txtTempatLayanan.Size = new System.Drawing.Size(285, 27);
            this.txtTempatLayanan.TabIndex = 104;
            this.txtTempatLayanan.Enter += new System.EventHandler(this.txtTempatLayanan_Enter);
            this.txtTempatLayanan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempatLayanan_KeyDown);
            this.txtTempatLayanan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempatLayanan_KeyPress);
            this.txtTempatLayanan.Leave += new System.EventHandler(this.txtTempatLayanan_Leave);
            // 
            // btnTampilDaftarTarif
            // 
            this.btnTampilDaftarTarif.BackColor = System.Drawing.Color.Gold;
            this.btnTampilDaftarTarif.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTampilDaftarTarif.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilDaftarTarif.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilDaftarTarif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilDaftarTarif.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilDaftarTarif.Location = new System.Drawing.Point(766, 119);
            this.btnTampilDaftarTarif.Name = "btnTampilDaftarTarif";
            this.btnTampilDaftarTarif.Size = new System.Drawing.Size(109, 29);
            this.btnTampilDaftarTarif.TabIndex = 105;
            this.btnTampilDaftarTarif.Text = "&DAFTAR TARIF";
            this.btnTampilDaftarTarif.UseVisualStyleBackColor = false;
            this.btnTampilDaftarTarif.Click += new System.EventHandler(this.btnTampilDaftarTarif_Click);
            this.btnTampilDaftarTarif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnTampilDaftarTarif_KeyPress);
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
            this.panel1.Location = new System.Drawing.Point(8, 503);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 210);
            this.panel1.TabIndex = 112;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.lblInfoPencarian);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNoBilling);
            this.panel2.Location = new System.Drawing.Point(8, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 50);
            this.panel2.TabIndex = 113;
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPencarian.Location = new System.Drawing.Point(581, 16);
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
            this.panel3.Location = new System.Drawing.Point(8, 716);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 48);
            this.panel3.TabIndex = 114;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(922, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
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
            this.panel4.Location = new System.Drawing.Point(8, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1007, 137);
            this.panel4.TabIndex = 116;
            // 
            // lblStatusPasien
            // 
            this.lblStatusPasien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatusPasien.AutoSize = true;
            this.lblStatusPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblStatusPasien.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPasien.ForeColor = System.Drawing.Color.Black;
            this.lblStatusPasien.Location = new System.Drawing.Point(647, 64);
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
            this.lblKelas.Location = new System.Drawing.Point(647, 34);
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
            this.lblRuangan.Location = new System.Drawing.Point(341, 34);
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
            this.lblMRPasien.Location = new System.Drawing.Point(119, 34);
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
            this.lblAlamatPasien.Location = new System.Drawing.Point(118, 94);
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
            this.lblNamaPasien.Location = new System.Drawing.Point(118, 60);
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
            this.label8.Location = new System.Drawing.Point(584, 64);
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
            this.label7.Location = new System.Drawing.Point(27, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 116;
            this.label7.Text = "Alamat : ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 115;
            this.label6.Text = "Kelas : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 64);
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
            this.label4.Location = new System.Drawing.Point(246, 34);
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
            this.label2.Location = new System.Drawing.Point(27, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 112;
            this.label2.Text = "No. KUIP : ";
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
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.btnTambahKompDokter);
            this.panel5.Controls.Add(this.btnDaftarKompTarif);
            this.panel5.Controls.Add(this.btnBatalTindakan);
            this.panel5.Controls.Add(this.cmbKomponenTarif);
            this.panel5.Controls.Add(this.lblKomponen);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.dtpTglTindakan);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtNamaDokter);
            this.panel5.Controls.Add(this.lblTempatLayanan);
            this.panel5.Controls.Add(this.lblDeskripsiTindakan);
            this.panel5.Controls.Add(this.txtKodeTindakan);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.lblKodeTindakan);
            this.panel5.Controls.Add(this.btnTampilDaftarTarif);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.txtTempatLayanan);
            this.panel5.Controls.Add(this.lblBiayaTindakan);
            this.panel5.Controls.Add(this.lblDokter);
            this.panel5.Controls.Add(this.btnTambahTindakan);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(8, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1007, 291);
            this.panel5.TabIndex = 117;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(962, 3);
            this.label14.TabIndex = 117;
            this.label14.Text = "No Transaksi : ";
            this.label14.Visible = false;
            // 
            // btnTambahKompDokter
            // 
            this.btnTambahKompDokter.BackColor = System.Drawing.Color.Gold;
            this.btnTambahKompDokter.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTambahKompDokter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahKompDokter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTambahKompDokter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahKompDokter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahKompDokter.Location = new System.Drawing.Point(766, 210);
            this.btnTambahKompDokter.Name = "btnTambahKompDokter";
            this.btnTambahKompDokter.Size = new System.Drawing.Size(33, 29);
            this.btnTambahKompDokter.TabIndex = 116;
            this.btnTambahKompDokter.Text = "&+";
            this.btnTambahKompDokter.UseVisualStyleBackColor = false;
            this.btnTambahKompDokter.Click += new System.EventHandler(this.btnTambahKompDokter_Click);
            // 
            // btnDaftarKompTarif
            // 
            this.btnDaftarKompTarif.BackColor = System.Drawing.Color.Gold;
            this.btnDaftarKompTarif.Enabled = false;
            this.btnDaftarKompTarif.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnDaftarKompTarif.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDaftarKompTarif.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnDaftarKompTarif.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnDaftarKompTarif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftarKompTarif.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaftarKompTarif.Location = new System.Drawing.Point(439, 174);
            this.btnDaftarKompTarif.Name = "btnDaftarKompTarif";
            this.btnDaftarKompTarif.Size = new System.Drawing.Size(152, 29);
            this.btnDaftarKompTarif.TabIndex = 115;
            this.btnDaftarKompTarif.Text = "DAFTAR K&OMPONEN";
            this.btnDaftarKompTarif.UseVisualStyleBackColor = false;
            this.btnDaftarKompTarif.Click += new System.EventHandler(this.btnKomponenTarif_Click);
            // 
            // btnBatalTindakan
            // 
            this.btnBatalTindakan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBatalTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatalTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatalTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatalTindakan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatalTindakan.Location = new System.Drawing.Point(933, 247);
            this.btnBatalTindakan.Name = "btnBatalTindakan";
            this.btnBatalTindakan.Size = new System.Drawing.Size(59, 33);
            this.btnBatalTindakan.TabIndex = 114;
            this.btnBatalTindakan.Text = "&BATAL";
            this.btnBatalTindakan.UseVisualStyleBackColor = false;
            this.btnBatalTindakan.Click += new System.EventHandler(this.btnBatalTindakan_Click);
            // 
            // cmbKomponenTarif
            // 
            this.cmbKomponenTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKomponenTarif.FormattingEnabled = true;
            this.cmbKomponenTarif.Location = new System.Drawing.Point(148, 174);
            this.cmbKomponenTarif.Name = "cmbKomponenTarif";
            this.cmbKomponenTarif.Size = new System.Drawing.Size(285, 28);
            this.cmbKomponenTarif.TabIndex = 113;
            // 
            // lblKomponen
            // 
            this.lblKomponen.AutoSize = true;
            this.lblKomponen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblKomponen.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKomponen.Location = new System.Drawing.Point(27, 178);
            this.lblKomponen.Name = "lblKomponen";
            this.lblKomponen.Size = new System.Drawing.Size(88, 18);
            this.lblKomponen.TabIndex = 112;
            this.lblKomponen.Text = "&Komponen :";
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
            this.label9.Size = new System.Drawing.Size(208, 20);
            this.label9.TabIndex = 111;
            this.label9.Text = "I&NPUT TINDAKAN  && DOKTER";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bgWorkLoadDataInit
            // 
            this.bgWorkLoadDataInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkLoadDataInit_DoWork);
            // 
            // inputTindakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        public System.Windows.Forms.Button btnTampilDaftarTarif;
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
        private System.Windows.Forms.ComboBox cmbKomponenTarif;
        private System.Windows.Forms.Label lblKomponen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDaftarKompTarif;
        private System.ComponentModel.BackgroundWorker bgWorkLoadDataInit;
        public System.Windows.Forms.Button btnTambahKompDokter;
        private System.Windows.Forms.Label label14;
    }
}

