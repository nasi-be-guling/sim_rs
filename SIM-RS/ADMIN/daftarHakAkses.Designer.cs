﻿using System.Collections.Generic;

namespace SIM_RS.ADMIN
{
    partial class DaftarHakAkses
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
            this.cmbStatusID = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtNamaAppLama = new System.Windows.Forms.TextBox();
            this.txtNamaMenu = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.lblTempatLayanan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKelompok = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnCariMenu = new System.Windows.Forms.Button();
            this.txtCariMenu = new System.Windows.Forms.TextBox();
            this.lblInfoDaftarPengguna = new System.Windows.Forms.Label();
            this.lvDaftarMenu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aktifkanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batalkanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.cmbStatusID);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnKeluar);
            this.panel1.Controls.Add(this.btnCariMenu);
            this.panel1.Controls.Add(this.txtCariMenu);
            this.panel1.Controls.Add(this.lblInfoDaftarPengguna);
            this.panel1.Controls.Add(this.lvDaftarMenu);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 586);
            this.panel1.TabIndex = 119;
            // 
            // cmbStatusID
            // 
            this.cmbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusID.FormattingEnabled = true;
            this.cmbStatusID.Items.AddRange(new object[] {
            "PENGGUNA",
            "PROGRAM"});
            this.cmbStatusID.Location = new System.Drawing.Point(6, 190);
            this.cmbStatusID.Name = "cmbStatusID";
            this.cmbStatusID.Size = new System.Drawing.Size(175, 28);
            this.cmbStatusID.TabIndex = 147;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel6.Controls.Add(this.txtNamaAppLama);
            this.panel6.Controls.Add(this.txtNamaMenu);
            this.panel6.Controls.Add(this.btnBatal);
            this.panel6.Controls.Add(this.lblTempatLayanan);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtKelompok);
            this.panel6.Controls.Add(this.btnSimpan);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(6, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(774, 156);
            this.panel6.TabIndex = 146;
            // 
            // txtNamaAppLama
            // 
            this.txtNamaAppLama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaAppLama.BackColor = System.Drawing.Color.White;
            this.txtNamaAppLama.Location = new System.Drawing.Point(237, 46);
            this.txtNamaAppLama.Name = "txtNamaAppLama";
            this.txtNamaAppLama.Size = new System.Drawing.Size(242, 27);
            this.txtNamaAppLama.TabIndex = 125;
            this.txtNamaAppLama.Leave += new System.EventHandler(this.txtNamaAppLama_Leave);
            // 
            // txtNamaMenu
            // 
            this.txtNamaMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaMenu.BackColor = System.Drawing.Color.White;
            this.txtNamaMenu.Location = new System.Drawing.Point(237, 13);
            this.txtNamaMenu.Name = "txtNamaMenu";
            this.txtNamaMenu.Size = new System.Drawing.Size(376, 27);
            this.txtNamaMenu.TabIndex = 113;
            this.txtNamaMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNamaMenu_KeyDown);
            this.txtNamaMenu.Leave += new System.EventHandler(this.txtNamaMenu_Leave);
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
            this.btnBatal.Location = new System.Drawing.Point(685, 112);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(77, 32);
            this.btnBatal.TabIndex = 124;
            this.btnBatal.Text = "&Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // lblTempatLayanan
            // 
            this.lblTempatLayanan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTempatLayanan.AutoSize = true;
            this.lblTempatLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblTempatLayanan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempatLayanan.Location = new System.Drawing.Point(36, 17);
            this.lblTempatLayanan.Name = "lblTempatLayanan";
            this.lblTempatLayanan.Size = new System.Drawing.Size(131, 18);
            this.lblTempatLayanan.TabIndex = 112;
            this.lblTempatLayanan.Text = "Nama Pengguna : ";
            this.lblTempatLayanan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Nama Menu Aplikasi : ";
            // 
            // txtKelompok
            // 
            this.txtKelompok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKelompok.BackColor = System.Drawing.Color.White;
            this.txtKelompok.Enabled = false;
            this.txtKelompok.Location = new System.Drawing.Point(237, 80);
            this.txtKelompok.Name = "txtKelompok";
            this.txtKelompok.Size = new System.Drawing.Size(116, 27);
            this.txtKelompok.TabIndex = 121;
            this.txtKelompok.Text = "  ---------------";
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
            this.btnSimpan.Location = new System.Drawing.Point(602, 112);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(77, 32);
            this.btnSimpan.TabIndex = 118;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 120;
            this.label2.Text = "GRUP : ";
            // 
            // btnKeluar
            // 
            this.btnKeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnKeluar.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnKeluar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(681, 551);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 119;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnCariMenu
            // 
            this.btnCariMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnCariMenu.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCariMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnCariMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCariMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariMenu.Location = new System.Drawing.Point(552, 190);
            this.btnCariMenu.Name = "btnCariMenu";
            this.btnCariMenu.Size = new System.Drawing.Size(130, 28);
            this.btnCariMenu.TabIndex = 96;
            this.btnCariMenu.Text = "&Filter Pencarian";
            this.btnCariMenu.UseVisualStyleBackColor = false;
            this.btnCariMenu.Click += new System.EventHandler(this.btnCariMenu_Click);
            // 
            // txtCariMenu
            // 
            this.txtCariMenu.BackColor = System.Drawing.Color.White;
            this.txtCariMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCariMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCariMenu.Location = new System.Drawing.Point(187, 190);
            this.txtCariMenu.Name = "txtCariMenu";
            this.txtCariMenu.Size = new System.Drawing.Size(359, 28);
            this.txtCariMenu.TabIndex = 3;
            this.txtCariMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCariMenu_KeyDown);
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
            this.lblInfoDaftarPengguna.Size = new System.Drawing.Size(178, 25);
            this.lblInfoDaftarPengguna.TabIndex = 111;
            this.lblInfoDaftarPengguna.Text = "DAFTAR HAK AKSES";
            this.lblInfoDaftarPengguna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvDaftarMenu
            // 
            this.lvDaftarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDaftarMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDaftarMenu.FullRowSelect = true;
            this.lvDaftarMenu.GridLines = true;
            this.lvDaftarMenu.HideSelection = false;
            this.lvDaftarMenu.Location = new System.Drawing.Point(6, 224);
            this.lvDaftarMenu.Name = "lvDaftarMenu";
            this.lvDaftarMenu.Size = new System.Drawing.Size(773, 320);
            this.lvDaftarMenu.TabIndex = 0;
            this.lvDaftarMenu.UseCompatibleStateImageBehavior = false;
            this.lvDaftarMenu.View = System.Windows.Forms.View.Details;
            this.lvDaftarMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvDaftarMenu_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nama Pengguna";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama Menu Aplikasi";
            this.columnHeader2.Width = 162;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "GRUP";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aktifkanToolStripMenuItem,
            this.batalkanToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // aktifkanToolStripMenuItem
            // 
            this.aktifkanToolStripMenuItem.Name = "aktifkanToolStripMenuItem";
            this.aktifkanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aktifkanToolStripMenuItem.Text = "Aktifkan";
            this.aktifkanToolStripMenuItem.Click += new System.EventHandler(this.aktifkanToolStripMenuItem_Click);
            // 
            // batalkanToolStripMenuItem
            // 
            this.batalkanToolStripMenuItem.Name = "batalkanToolStripMenuItem";
            this.batalkanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.batalkanToolStripMenuItem.Text = "Batalkan";
            this.batalkanToolStripMenuItem.Click += new System.EventHandler(this.batalkanToolStripMenuItem_Click);
            // 
            // DaftarHakAkses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DaftarHakAkses";
            this.Text = "daftarHakAkses";
            this.Load += new System.EventHandler(this.daftarHakAkses_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daftarHakAkses_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtNamaAppLama;
        private System.Windows.Forms.TextBox txtNamaMenu;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label lblTempatLayanan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKelompok;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnCariMenu;
        private System.Windows.Forms.TextBox txtCariMenu;
        private System.Windows.Forms.Label lblInfoDaftarPengguna;
        private System.Windows.Forms.ListView lvDaftarMenu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox cmbStatusID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem batalkanToolStripMenuItem;
        private readonly List<Pengguna> listProgram = new List<Pengguna>();
        private readonly List<Pengguna> listPengguna = new List<Pengguna>();
        private System.Windows.Forms.ToolStripMenuItem aktifkanToolStripMenuItem;
    }
}