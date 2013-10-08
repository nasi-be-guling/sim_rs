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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblJumlahJasPel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDaftarTindakan = new System.Windows.Forms.Label();
            this.lvJasaPelayanan = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalJasaPelayanan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPetugas = new System.Windows.Forms.Label();
            this.btnKeluarJasPel = new System.Windows.Forms.Button();
            this.btnSimpanJasPel = new System.Windows.Forms.Button();
            this.bgCariDataJaspel = new System.ComponentModel.BackgroundWorker();
            this.lblKodeDokter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPencarian.Location = new System.Drawing.Point(638, 12);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(203, 20);
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
            this.label1.Size = new System.Drawing.Size(184, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAMA DOKTER : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamaDokter.BackColor = System.Drawing.Color.White;
            this.txtNamaDokter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaDokter.Location = new System.Drawing.Point(194, 9);
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
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 45);
            this.panel2.TabIndex = 114;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblJumlahJasPel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblDaftarTindakan);
            this.panel1.Controls.Add(this.lvJasaPelayanan);
            this.panel1.Location = new System.Drawing.Point(13, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 500);
            this.panel1.TabIndex = 115;
            // 
            // lblJumlahJasPel
            // 
            this.lblJumlahJasPel.AutoSize = true;
            this.lblJumlahJasPel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahJasPel.Location = new System.Drawing.Point(643, 430);
            this.lblJumlahJasPel.Name = "lblJumlahJasPel";
            this.lblJumlahJasPel.Size = new System.Drawing.Size(32, 25);
            this.lblJumlahJasPel.TabIndex = 120;
            this.lblJumlahJasPel.Text = "....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 119;
            this.label2.Text = "JUMLAH : Rp.";
            // 
            // lblDaftarTindakan
            // 
            this.lblDaftarTindakan.AutoSize = true;
            this.lblDaftarTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblDaftarTindakan.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDaftarTindakan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarTindakan.ForeColor = System.Drawing.Color.White;
            this.lblDaftarTindakan.Location = new System.Drawing.Point(602, 0);
            this.lblDaftarTindakan.Name = "lblDaftarTindakan";
            this.lblDaftarTindakan.Size = new System.Drawing.Size(250, 20);
            this.lblDaftarTindakan.TabIndex = 112;
            this.lblDaftarTindakan.Text = "D&AFTAR URAIAN JASA PELAYANAN ";
            this.lblDaftarTindakan.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.lvJasaPelayanan.FullRowSelect = true;
            this.lvJasaPelayanan.GridLines = true;
            this.lvJasaPelayanan.HideSelection = false;
            this.lvJasaPelayanan.Location = new System.Drawing.Point(0, 20);
            this.lvJasaPelayanan.Name = "lvJasaPelayanan";
            this.lvJasaPelayanan.Size = new System.Drawing.Size(852, 404);
            this.lvJasaPelayanan.TabIndex = 75;
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
            this.columnHeader7.Width = 100;
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
            this.columnHeader6.Width = 130;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel4.Controls.Add(this.lblTotalJasaPelayanan);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(13, 575);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(852, 44);
            this.panel4.TabIndex = 117;
            // 
            // lblTotalJasaPelayanan
            // 
            this.lblTotalJasaPelayanan.AutoSize = true;
            this.lblTotalJasaPelayanan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJasaPelayanan.Location = new System.Drawing.Point(313, 7);
            this.lblTotalJasaPelayanan.Name = "lblTotalJasaPelayanan";
            this.lblTotalJasaPelayanan.Size = new System.Drawing.Size(37, 30);
            this.lblTotalJasaPelayanan.TabIndex = 118;
            this.lblTotalJasaPelayanan.Text = "....";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 30);
            this.label9.TabIndex = 117;
            this.label9.Text = "TOTAL YANG DITERIMA : Rp.";
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
            this.panel5.Location = new System.Drawing.Point(13, 696);
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
            this.btnKeluarJasPel.Location = new System.Drawing.Point(764, 625);
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
            this.btnSimpanJasPel.Location = new System.Drawing.Point(657, 625);
            this.btnSimpanJasPel.Name = "btnSimpanJasPel";
            this.btnSimpanJasPel.Size = new System.Drawing.Size(101, 30);
            this.btnSimpanJasPel.TabIndex = 119;
            this.btnSimpanJasPel.Text = "&SIMPAN";
            this.btnSimpanJasPel.UseVisualStyleBackColor = false;
            // 
            // bgCariDataJaspel
            // 
            this.bgCariDataJaspel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCariDataJaspel_DoWork);
            // 
            // lblKodeDokter
            // 
            this.lblKodeDokter.AutoSize = true;
            this.lblKodeDokter.Location = new System.Drawing.Point(6, 668);
            this.lblKodeDokter.Name = "lblKodeDokter";
            this.lblKodeDokter.Size = new System.Drawing.Size(23, 18);
            this.lblKodeDokter.TabIndex = 121;
            this.lblKodeDokter.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(643, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 25);
            this.label3.TabIndex = 122;
            this.label3.Text = "....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(462, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 121;
            this.label4.Text = "PAJAK (15%) : Rp.";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Keringanan";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Jumlah";
            // 
            // JasaPelayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(883, 747);
            this.Controls.Add(this.lblKodeDokter);
            this.Controls.Add(this.btnKeluarJasPel);
            this.Controls.Add(this.btnSimpanJasPel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JasaPelayanan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengambilan Jasa Pelayanan";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfoPencarian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvJasaPelayanan;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblDaftarTindakan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalJasaPelayanan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPetugas;
        private System.Windows.Forms.Button btnKeluarJasPel;
        private System.Windows.Forms.Button btnSimpanJasPel;
        private System.Windows.Forms.Label lblJumlahJasPel;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgCariDataJaspel;
        private System.Windows.Forms.Label lblKodeDokter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}