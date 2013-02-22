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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPetugas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUnitKerja = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.btnLoginLagi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(381, 25);
            this.label16.TabIndex = 64;
            this.label16.Text = "Login Aplikasi";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(25, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 2);
            this.label3.TabIndex = 63;
            this.label3.Text = "label3";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Sandi Operator : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdPetugas
            // 
            this.txtIdPetugas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdPetugas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPetugas.Location = new System.Drawing.Point(161, 64);
            this.txtIdPetugas.Name = "txtIdPetugas";
            this.txtIdPetugas.PasswordChar = '*';
            this.txtIdPetugas.Size = new System.Drawing.Size(176, 30);
            this.txtIdPetugas.TabIndex = 66;
            this.txtIdPetugas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdPetugas_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 67;
            this.label2.Text = "Unit Kerja : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "Shift : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUnitKerja
            // 
            this.cmbUnitKerja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitKerja.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnitKerja.FormattingEnabled = true;
            this.cmbUnitKerja.Location = new System.Drawing.Point(161, 100);
            this.cmbUnitKerja.Name = "cmbUnitKerja";
            this.cmbUnitKerja.Size = new System.Drawing.Size(176, 31);
            this.cmbUnitKerja.TabIndex = 71;
            this.cmbUnitKerja.SelectedIndexChanged += new System.EventHandler(this.cmbUnitKerja_SelectedIndexChanged);
            this.cmbUnitKerja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnitKerja_KeyPress);
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "PAGI",
            "SORE",
            "MALAM"});
            this.cmbShift.Location = new System.Drawing.Point(161, 135);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(176, 31);
            this.cmbShift.TabIndex = 72;
            this.cmbShift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbShift_KeyPress);
            // 
            // btnLoginLagi
            // 
            this.btnLoginLagi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginLagi.Location = new System.Drawing.Point(353, 64);
            this.btnLoginLagi.Name = "btnLoginLagi";
            this.btnLoginLagi.Size = new System.Drawing.Size(35, 30);
            this.btnLoginLagi.TabIndex = 73;
            this.btnLoginLagi.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 213);
            this.Controls.Add(this.btnLoginLagi);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbUnitKerja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdPetugas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Aplikasi Billing RSSA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPetugas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUnitKerja;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Button btnLoginLagi;
    }
}