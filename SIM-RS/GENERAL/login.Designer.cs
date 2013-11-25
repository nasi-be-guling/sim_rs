namespace SIM_RS
{
    partial class login
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
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPetugas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUnitKerja = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(377, 38);
            this.label16.TabIndex = 64;
            this.label16.Text = "LOGIN APLIKASI";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 65;
            this.label1.Text = "Sandi Operator : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdPetugas
            // 
            this.txtIdPetugas.BackColor = System.Drawing.Color.White;
            this.txtIdPetugas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPetugas.Location = new System.Drawing.Point(164, 57);
            this.txtIdPetugas.Name = "txtIdPetugas";
            this.txtIdPetugas.PasswordChar = '*';
            this.txtIdPetugas.Size = new System.Drawing.Size(176, 30);
            this.txtIdPetugas.TabIndex = 66;
            this.txtIdPetugas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdPetugas_KeyPress);
            this.txtIdPetugas.Leave += new System.EventHandler(this.txtIdPetugas_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 67;
            this.label2.Text = "Unit Kerja : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 69;
            this.label4.Text = "Shift : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUnitKerja
            // 
            this.cmbUnitKerja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitKerja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnitKerja.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnitKerja.FormattingEnabled = true;
            this.cmbUnitKerja.Location = new System.Drawing.Point(164, 93);
            this.cmbUnitKerja.Name = "cmbUnitKerja";
            this.cmbUnitKerja.Size = new System.Drawing.Size(176, 33);
            this.cmbUnitKerja.TabIndex = 71;
            this.cmbUnitKerja.SelectedIndexChanged += new System.EventHandler(this.cmbUnitKerja_SelectedIndexChanged);
            this.cmbUnitKerja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnitKerja_KeyPress);
            this.cmbUnitKerja.Leave += new System.EventHandler(this.cmbUnitKerja_Leave);
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbShift.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "PAGI",
            "SORE",
            "MALAM"});
            this.cmbShift.Location = new System.Drawing.Point(164, 133);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(176, 33);
            this.cmbShift.TabIndex = 72;
            this.cmbShift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbShift_KeyPress);
            this.cmbShift.Leave += new System.EventHandler(this.cmbShift_Leave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(0, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 19);
            this.label5.TabIndex = 73;
            this.label5.Text = "Tekan ESC untuk membatalkan login / Keluar dari Program";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(377, 218);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbUnitKerja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdPetugas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Aplikasi Billing RSSA";
            this.Activated += new System.EventHandler(this.login_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.Load += new System.EventHandler(this.login_Load);
            this.Shown += new System.EventHandler(this.login_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.login_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPetugas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUnitKerja;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Label label5;
    }
}