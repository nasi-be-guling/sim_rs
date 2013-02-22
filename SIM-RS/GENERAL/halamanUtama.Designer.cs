namespace SIM_RS
{
    partial class halamanUtama
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
            this.lbDaftarMenu = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKeluarProgram = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPetugas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnitKerja = new System.Windows.Forms.TextBox();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDaftarMenu
            // 
            this.lbDaftarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDaftarMenu.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDaftarMenu.FormattingEnabled = true;
            this.lbDaftarMenu.HorizontalExtent = 40;
            this.lbDaftarMenu.HorizontalScrollbar = true;
            this.lbDaftarMenu.ItemHeight = 25;
            this.lbDaftarMenu.Items.AddRange(new object[] {
            "MENU 1",
            "MENU 2",
            "MENU 3",
            "MENU 4"});
            this.lbDaftarMenu.Location = new System.Drawing.Point(15, 187);
            this.lbDaftarMenu.Name = "lbDaftarMenu";
            this.lbDaftarMenu.ScrollAlwaysVisible = true;
            this.lbDaftarMenu.Size = new System.Drawing.Size(531, 229);
            this.lbDaftarMenu.TabIndex = 0;
            this.lbDaftarMenu.DoubleClick += new System.EventHandler(this.lbDaftarMenu_DoubleClick);
            this.lbDaftarMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbDaftarMenu_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 161);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnKeluarProgram
            // 
            this.btnKeluarProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluarProgram.Location = new System.Drawing.Point(674, 422);
            this.btnKeluarProgram.Name = "btnKeluarProgram";
            this.btnKeluarProgram.Size = new System.Drawing.Size(75, 29);
            this.btnKeluarProgram.TabIndex = 3;
            this.btnKeluarProgram.Text = "&KELUAR";
            this.btnKeluarProgram.UseVisualStyleBackColor = true;
            this.btnKeluarProgram.Click += new System.EventHandler(this.btnKeluarProgram_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Petugas";
            // 
            // txtPetugas
            // 
            this.txtPetugas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPetugas.Location = new System.Drawing.Point(19, 55);
            this.txtPetugas.Name = "txtPetugas";
            this.txtPetugas.ReadOnly = true;
            this.txtPetugas.Size = new System.Drawing.Size(156, 26);
            this.txtPetugas.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Unit Kerja";
            // 
            // txtUnitKerja
            // 
            this.txtUnitKerja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitKerja.Location = new System.Drawing.Point(19, 120);
            this.txtUnitKerja.Name = "txtUnitKerja";
            this.txtUnitKerja.ReadOnly = true;
            this.txtUnitKerja.Size = new System.Drawing.Size(156, 26);
            this.txtUnitKerja.TabIndex = 7;
            // 
            // txtShift
            // 
            this.txtShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShift.Location = new System.Drawing.Point(19, 185);
            this.txtShift.Name = "txtShift";
            this.txtShift.ReadOnly = true;
            this.txtShift.Size = new System.Drawing.Size(156, 26);
            this.txtShift.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Shift";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtShift);
            this.groupBox1.Controls.Add(this.txtPetugas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUnitKerja);
            this.groupBox1.Location = new System.Drawing.Point(552, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 237);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ": Info Petugas :";
            // 
            // halamanUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 463);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnKeluarProgram);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbDaftarMenu);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "halamanUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi BILLING RSSA Malang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.halamanUtama_FormClosing);
            this.Load += new System.EventHandler(this.halamanUtama_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.halamanUtama_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.halamanUtama_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDaftarMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKeluarProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtPetugas;
        public System.Windows.Forms.TextBox txtUnitKerja;
        public System.Windows.Forms.TextBox txtShift;

    }
}