﻿namespace SIM_RS.RAWAT_INAP
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUnitKerja = new System.Windows.Forms.ComboBox();
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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbUnitKerja);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpFilterTgl2);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.dtpFilterTgl1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 76);
            this.panel2.TabIndex = 115;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(402, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 28);
            this.comboBox1.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 103;
            this.label5.Text = "Unit : ";
            // 
            // cmbUnitKerja
            // 
            this.cmbUnitKerja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitKerja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnitKerja.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnitKerja.FormattingEnabled = true;
            this.cmbUnitKerja.Items.AddRange(new object[] {
            "1. REKAP",
            "2. REKAP PER UNIT",
            "3. RINCIAN PER UNIT"});
            this.cmbUnitKerja.Location = new System.Drawing.Point(178, 41);
            this.cmbUnitKerja.Name = "cmbUnitKerja";
            this.cmbUnitKerja.Size = new System.Drawing.Size(176, 28);
            this.cmbUnitKerja.TabIndex = 102;
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
            this.btnCari.Location = new System.Drawing.Point(688, 42);
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
            this.label1.Size = new System.Drawing.Size(56, 76);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.Location = new System.Drawing.Point(4, 536);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(128, 20);
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
            this.panel1.Location = new System.Drawing.Point(4, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 437);
            this.panel1.TabIndex = 116;
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
            this.lvDaftarTindakan.Size = new System.Drawing.Size(784, 410);
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
        private System.Windows.Forms.ComboBox cmbUnitKerja;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bgWorkLoadFromDB;
    }
}