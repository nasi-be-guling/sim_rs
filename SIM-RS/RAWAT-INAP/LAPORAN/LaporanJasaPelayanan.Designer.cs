namespace SIM_RS.RAWAT_INAP
{
    partial class LaporanJasaPelayanan
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbPilihanExport = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbJenisLaporan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFilterTgl2 = new System.Windows.Forms.DateTimePicker();
            this.btnCari = new System.Windows.Forms.Button();
            this.dtpFilterTgl1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.bgWorkLoadFromDB = new System.ComponentModel.BackgroundWorker();
            this.bgWorkExport = new System.ComponentModel.BackgroundWorker();
            this.tmrWaktuLoad = new System.Windows.Forms.Timer(this.components);
            this.tmrBlink = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.btnTampilkan);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.cmbPilihanExport);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmbUnit);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbJenisLaporan);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpFilterTgl2);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.dtpFilterTgl1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 127);
            this.panel2.TabIndex = 115;
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnTampilkan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnTampilkan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTampilkan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilkan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilkan.Location = new System.Drawing.Point(584, 46);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(119, 32);
            this.btnTampilkan.TabIndex = 108;
            this.btnTampilkan.Text = "&Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(584, 84);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(119, 32);
            this.btnExport.TabIndex = 107;
            this.btnExport.Text = "&Export Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbPilihanExport
            // 
            this.cmbPilihanExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPilihanExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPilihanExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPilihanExport.FormattingEnabled = true;
            this.cmbPilihanExport.Items.AddRange(new object[] {
            "1. Export Rekap",
            "2. Export Detail Umum",
            "3. Export Detail Gakin",
            "4. Export Detail Jamkesmas",
            "5. Export Detail Jamkesda"});
            this.cmbPilihanExport.Location = new System.Drawing.Point(178, 84);
            this.cmbPilihanExport.Name = "cmbPilihanExport";
            this.cmbPilihanExport.Size = new System.Drawing.Size(210, 28);
            this.cmbPilihanExport.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "Export : ";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(402, 46);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(176, 28);
            this.cmbUnit.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 103;
            this.label5.Text = "Unit : ";
            // 
            // cmbJenisLaporan
            // 
            this.cmbJenisLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbJenisLaporan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJenisLaporan.FormattingEnabled = true;
            this.cmbJenisLaporan.Items.AddRange(new object[] {
            "1. REKAP",
            "2. REKAP PER UNIT",
            "3. RINCIAN PER UNIT"});
            this.cmbJenisLaporan.Location = new System.Drawing.Point(178, 46);
            this.cmbJenisLaporan.Name = "cmbJenisLaporan";
            this.cmbJenisLaporan.Size = new System.Drawing.Size(176, 28);
            this.cmbJenisLaporan.TabIndex = 102;
            this.cmbJenisLaporan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbJenisLaporan_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "Tanggal : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 100;
            this.label3.Text = "Jenis Laporan : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "-";
            // 
            // dtpFilterTgl2
            // 
            this.dtpFilterTgl2.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl2.Location = new System.Drawing.Point(392, 9);
            this.dtpFilterTgl2.Name = "dtpFilterTgl2";
            this.dtpFilterTgl2.Size = new System.Drawing.Size(186, 27);
            this.dtpFilterTgl2.TabIndex = 98;
            this.dtpFilterTgl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFilterTgl2_KeyPress);
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCari.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCari.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(584, 8);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(119, 32);
            this.btnCari.TabIndex = 96;
            this.btnCari.Text = "&Proses";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // dtpFilterTgl1
            // 
            this.dtpFilterTgl1.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl1.Location = new System.Drawing.Point(176, 9);
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
            this.label1.Size = new System.Drawing.Size(56, 127);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPencarian.Location = new System.Drawing.Point(4, 536);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(139, 20);
            this.lblInfoPencarian.TabIndex = 97;
            this.lblInfoPencarian.Text = "Proses Pencarian...";
            this.lblInfoPencarian.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(4, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 390);
            this.panel1.TabIndex = 116;
            this.panel1.Visible = false;
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(4, 24);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(784, 363);
            this.lvDaftarTindakan.TabIndex = 75;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
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
            this.lblDaftarTindakan.Size = new System.Drawing.Size(188, 20);
            this.lblDaftarTindakan.TabIndex = 111;
            this.lblDaftarTindakan.Text = "D&AFTAR JASA PELAYANAN";
            this.lblDaftarTindakan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnKeluar
            // 
            this.btnKeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(696, 530);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 117;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // bgWorkLoadFromDB
            // 
            this.bgWorkLoadFromDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkLoadFromDB_DoWork);
            // 
            // bgWorkExport
            // 
            this.bgWorkExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkExport_DoWork);
            // 
            // tmrWaktuLoad
            // 
            this.tmrWaktuLoad.Enabled = true;
            this.tmrWaktuLoad.Interval = 1000;
            this.tmrWaktuLoad.Tick += new System.EventHandler(this.tmrWaktuLoad_Tick);
            // 
            // tmrBlink
            // 
            this.tmrBlink.Interval = 1000;
            this.tmrBlink.Tick += new System.EventHandler(this.tmrBlink_Tick);
            // 
            // LaporanJasaPelayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblInfoPencarian);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LaporanJasaPelayanan";
            this.Text = "LaporanJasaPelayanan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaporanJasaPelayanan_FormClosing);
            this.Load += new System.EventHandler(this.LaporanJasaPelayanan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl2;
        private System.Windows.Forms.Label lblInfoPencarian;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJenisLaporan;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bgWorkLoadFromDB;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbPilihanExport;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker bgWorkExport;
        private System.Windows.Forms.Timer tmrWaktuLoad;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Timer tmrBlink;
    }
}