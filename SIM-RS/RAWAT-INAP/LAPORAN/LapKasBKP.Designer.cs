namespace SIM_RS.RAWAT_INAP
{
    partial class LapKasBKP
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHari = new System.Windows.Forms.TextBox();
            this.txtNomor = new System.Windows.Forms.TextBox();
            this.cmbKode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFilterTgl2 = new System.Windows.Forms.DateTimePicker();
            this.btnCari = new System.Windows.Forms.Button();
            this.dtpFilterTgl1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.bgWork_1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.txtHari);
            this.panel2.Controls.Add(this.txtNomor);
            this.panel2.Controls.Add(this.cmbKode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpFilterTgl2);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.dtpFilterTgl1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 110);
            this.panel2.TabIndex = 116;
            // 
            // txtHari
            // 
            this.txtHari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHari.BackColor = System.Drawing.Color.White;
            this.txtHari.Location = new System.Drawing.Point(404, 41);
            this.txtHari.Name = "txtHari";
            this.txtHari.Size = new System.Drawing.Size(176, 27);
            this.txtHari.TabIndex = 118;
            // 
            // txtNomor
            // 
            this.txtNomor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomor.BackColor = System.Drawing.Color.White;
            this.txtNomor.Location = new System.Drawing.Point(176, 41);
            this.txtNomor.Name = "txtNomor";
            this.txtNomor.Size = new System.Drawing.Size(176, 27);
            this.txtNomor.TabIndex = 117;
            // 
            // cmbKode
            // 
            this.cmbKode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbKode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKode.FormattingEnabled = true;
            this.cmbKode.Items.AddRange(new object[] {
            "KELOMPOK TARIP",
            "UNIT KERJA"});
            this.cmbKode.Location = new System.Drawing.Point(176, 75);
            this.cmbKode.Name = "cmbKode";
            this.cmbKode.Size = new System.Drawing.Size(176, 28);
            this.cmbKode.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "PER : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 103;
            this.label5.Text = "Hari : ";
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
            this.label3.Location = new System.Drawing.Point(62, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 100;
            this.label3.Text = "Nomor : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "-";
            // 
            // dtpFilterTgl2
            // 
            this.dtpFilterTgl2.CustomFormat = "dd MMMM yyyy";
            this.dtpFilterTgl2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterTgl2.Location = new System.Drawing.Point(404, 9);
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
            this.btnCari.Location = new System.Drawing.Point(685, 73);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(101, 30);
            this.btnCari.TabIndex = 96;
            this.btnCari.Text = "&CARI";
            this.btnCari.UseVisualStyleBackColor = false;
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
            this.label1.Size = new System.Drawing.Size(56, 110);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lvDaftarTindakan);
            this.panel1.Location = new System.Drawing.Point(5, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 402);
            this.panel1.TabIndex = 117;
            // 
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(4, 3);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(784, 396);
            this.lvDaftarTindakan.TabIndex = 75;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
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
            this.btnKeluar.Location = new System.Drawing.Point(697, 528);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 119;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Location = new System.Drawing.Point(5, 538);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(128, 20);
            this.lblInfoPencarian.TabIndex = 120;
            this.lblInfoPencarian.Text = "Proses Pencarian...";
            this.lblInfoPencarian.Visible = false;
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // bgWork_1
            // 
            this.bgWork_1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_1_DoWork);
            // 
            // LapKasBKP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.lblInfoPencarian);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LapKasBKP";
            this.Text = "LapKasBKP";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl2;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DateTimePicker dtpFilterTgl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHari;
        private System.Windows.Forms.TextBox txtNomor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Label lblInfoPencarian;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.ComponentModel.BackgroundWorker bgWork_1;
    }
}