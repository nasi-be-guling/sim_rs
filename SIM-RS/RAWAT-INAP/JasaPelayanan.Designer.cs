namespace SIM_RS.RAWAT_INAP
{
    partial class JasaPelayanan
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
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPetugas = new System.Windows.Forms.Label();
            this.btnKeluarJasPel = new System.Windows.Forms.Button();
            this.btnSimpanJasPel = new System.Windows.Forms.Button();
            this.bgCariDataJaspel = new System.ComponentModel.BackgroundWorker();
            this.lblKodeDokter = new System.Windows.Forms.Label();
            this.btnBatalJasPel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotalJasaPelayanan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lvJasaPelayanan = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblJmlJaspel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPencarian.Location = new System.Drawing.Point(605, 16);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(181, 17);
            this.lblInfoPencarian.TabIndex = 2;
            this.lblInfoPencarian.Text = "Proses Menampilkan Data...";
            this.lblInfoPencarian.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAMA DOKTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamaDokter.BackColor = System.Drawing.Color.White;
            this.txtNamaDokter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaDokter.Location = new System.Drawing.Point(161, 11);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(438, 27);
            this.txtNamaDokter.TabIndex = 1;
            this.txtNamaDokter.Enter += new System.EventHandler(this.txtNamaDokter_Enter);
            this.txtNamaDokter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNamaDokter_KeyDown);
            this.txtNamaDokter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaDokter_KeyPress);
            this.txtNamaDokter.Leave += new System.EventHandler(this.txtNamaDokter_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.lblInfoPencarian);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNamaDokter);
            this.panel2.Location = new System.Drawing.Point(15, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 45);
            this.panel2.TabIndex = 114;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(15, 659);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(852, 44);
            this.panel4.TabIndex = 117;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 30);
            this.label2.TabIndex = 122;
            this.label2.Text = "....";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 30);
            this.label3.TabIndex = 121;
            this.label3.Text = "TOTAL YANG DITERIMA :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(673, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 25);
            this.label7.TabIndex = 116;
            this.label7.Text = "....";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(541, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 25);
            this.label8.TabIndex = 113;
            this.label8.Text = "JUMLAH : Rp.";
            this.label8.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.lblPetugas);
            this.panel5.Location = new System.Drawing.Point(12, 736);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 43);
            this.panel5.TabIndex = 118;
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
            // btnKeluarJasPel
            // 
            this.btnKeluarJasPel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKeluarJasPel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluarJasPel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluarJasPel.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluarJasPel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarJasPel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarJasPel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluarJasPel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarJasPel.Location = new System.Drawing.Point(750, 733);
            this.btnKeluarJasPel.Name = "btnKeluarJasPel";
            this.btnKeluarJasPel.Size = new System.Drawing.Size(101, 30);
            this.btnKeluarJasPel.TabIndex = 120;
            this.btnKeluarJasPel.Text = "&KELUAR";
            this.btnKeluarJasPel.UseVisualStyleBackColor = false;
            // 
            // btnSimpanJasPel
            // 
            this.btnSimpanJasPel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimpanJasPel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnSimpanJasPel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpanJasPel.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpanJasPel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanJasPel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanJasPel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpanJasPel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanJasPel.Location = new System.Drawing.Point(524, 733);
            this.btnSimpanJasPel.Name = "btnSimpanJasPel";
            this.btnSimpanJasPel.Size = new System.Drawing.Size(107, 30);
            this.btnSimpanJasPel.TabIndex = 119;
            this.btnSimpanJasPel.Text = "&AMBIL";
            this.btnSimpanJasPel.UseVisualStyleBackColor = false;
            this.btnSimpanJasPel.Click += new System.EventHandler(this.btnSimpanJasPel_Click);
            // 
            // bgCariDataJaspel
            // 
            this.bgCariDataJaspel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCariDataJaspel_DoWork);
            // 
            // lblKodeDokter
            // 
            this.lblKodeDokter.AutoSize = true;
            this.lblKodeDokter.Location = new System.Drawing.Point(436, 740);
            this.lblKodeDokter.Name = "lblKodeDokter";
            this.lblKodeDokter.Size = new System.Drawing.Size(23, 18);
            this.lblKodeDokter.TabIndex = 121;
            this.lblKodeDokter.Text = "...";
            this.lblKodeDokter.Visible = false;
            // 
            // btnBatalJasPel
            // 
            this.btnBatalJasPel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBatalJasPel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnBatalJasPel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatalJasPel.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBatalJasPel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalJasPel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBatalJasPel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatalJasPel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatalJasPel.Location = new System.Drawing.Point(637, 733);
            this.btnBatalJasPel.Name = "btnBatalJasPel";
            this.btnBatalJasPel.Size = new System.Drawing.Size(107, 30);
            this.btnBatalJasPel.TabIndex = 122;
            this.btnBatalJasPel.Text = "&BATAL";
            this.btnBatalJasPel.UseVisualStyleBackColor = false;
            this.btnBatalJasPel.Click += new System.EventHandler(this.btnBatalJasPel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 590);
            this.tabControl1.TabIndex = 113;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotalJasaPelayanan);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lvJasaPelayanan);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(845, 559);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jasa Pelayanan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotalJasaPelayanan
            // 
            this.lblTotalJasaPelayanan.AutoSize = true;
            this.lblTotalJasaPelayanan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJasaPelayanan.Location = new System.Drawing.Point(614, 521);
            this.lblTotalJasaPelayanan.Name = "lblTotalJasaPelayanan";
            this.lblTotalJasaPelayanan.Size = new System.Drawing.Size(37, 30);
            this.lblTotalJasaPelayanan.TabIndex = 120;
            this.lblTotalJasaPelayanan.Text = "....";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(334, 521);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 30);
            this.label9.TabIndex = 119;
            this.label9.Text = "TOTAL SEBELUM PAJAK :";
            // 
            // lvJasaPelayanan
            // 
            this.lvJasaPelayanan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvJasaPelayanan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9});
            this.lvJasaPelayanan.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvJasaPelayanan.FullRowSelect = true;
            this.lvJasaPelayanan.GridLines = true;
            this.lvJasaPelayanan.HideSelection = false;
            this.lvJasaPelayanan.Location = new System.Drawing.Point(5, 4);
            this.lvJasaPelayanan.Name = "lvJasaPelayanan";
            this.lvJasaPelayanan.Size = new System.Drawing.Size(833, 509);
            this.lvJasaPelayanan.TabIndex = 116;
            this.lvJasaPelayanan.UseCompatibleStateImageBehavior = false;
            this.lvJasaPelayanan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "No";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "No RM";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nama Pasien";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tgl Pulang";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nama Tindakan";
            this.columnHeader4.Width = 210;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Jasa Medis";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Keringanan";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Jumlah";
            this.columnHeader9.Width = 100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.lblJmlJaspel);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(845, 559);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pemotongan Pajak";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 18);
            this.label11.TabIndex = 5;
            this.label11.Text = "PPh Pasal 21";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(197, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 19);
            this.label10.TabIndex = 4;
            this.label10.Text = "....";
            // 
            // lblJmlJaspel
            // 
            this.lblJmlJaspel.AutoSize = true;
            this.lblJmlJaspel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJmlJaspel.Location = new System.Drawing.Point(195, 51);
            this.lblJmlJaspel.Name = "lblJmlJaspel";
            this.lblJmlJaspel.Size = new System.Drawing.Size(29, 19);
            this.lblJmlJaspel.TabIndex = 3;
            this.lblJmlJaspel.Text = "....";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Jasa Administrasi (10%)  :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tenaga Ahli",
            "Non Tenaga Ahli"});
            this.comboBox1.Location = new System.Drawing.Point(199, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 26);
            this.comboBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Jumlah Sebelum Pajak :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ketenagaan :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(13, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 87);
            this.panel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(206, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 18);
            this.label13.TabIndex = 7;
            this.label13.Text = "% x (Bruto x 50%)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 26);
            this.textBox1.TabIndex = 8;
            // 
            // JasaPelayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(883, 791);
            this.Controls.Add(this.btnBatalJasPel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblKodeDokter);
            this.Controls.Add(this.btnKeluarJasPel);
            this.Controls.Add(this.btnSimpanJasPel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JasaPelayanan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengambilan Jasa Pelayanan";
            this.Load += new System.EventHandler(this.JasaPelayanan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfoPencarian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPetugas;
        private System.Windows.Forms.Button btnKeluarJasPel;
        private System.Windows.Forms.Button btnSimpanJasPel;
        private System.ComponentModel.BackgroundWorker bgCariDataJaspel;
        private System.Windows.Forms.Label lblKodeDokter;
        private System.Windows.Forms.Button btnBatalJasPel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTotalJasaPelayanan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvJasaPelayanan;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblJmlJaspel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
    }
}