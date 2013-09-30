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
            this.txtsandiUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtuserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeluarProgram = new System.Windows.Forms.Button();
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
            this.label16.Size = new System.Drawing.Size(355, 38);
            this.label16.TabIndex = 64;
            this.label16.Text = "LOGIN APLIKASI";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 65;
            this.label1.Text = "SANDI :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtsandiUser
            // 
            this.txtsandiUser.BackColor = System.Drawing.Color.White;
            this.txtsandiUser.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsandiUser.Location = new System.Drawing.Point(158, 97);
            this.txtsandiUser.Name = "txtsandiUser";
            this.txtsandiUser.PasswordChar = '*';
            this.txtsandiUser.Size = new System.Drawing.Size(176, 30);
            this.txtsandiUser.TabIndex = 66;
            this.txtsandiUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsandiUser_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(0, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(355, 19);
            this.label5.TabIndex = 73;
            this.label5.Text = "Tekan ESC untuk membatalkan login / Keluar dari Program";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtuserId
            // 
            this.txtuserId.BackColor = System.Drawing.Color.White;
            this.txtuserId.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserId.Location = new System.Drawing.Point(158, 61);
            this.txtuserId.Name = "txtuserId";
            this.txtuserId.PasswordChar = '*';
            this.txtuserId.Size = new System.Drawing.Size(176, 30);
            this.txtuserId.TabIndex = 0;
            this.txtuserId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtuserId_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 74;
            this.label2.Text = "USERID/NIP/NBI : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKeluarProgram
            // 
            this.btnKeluarProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluarProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluarProgram.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnKeluarProgram.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarProgram.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnKeluarProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluarProgram.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarProgram.Location = new System.Drawing.Point(244, 142);
            this.btnKeluarProgram.Name = "btnKeluarProgram";
            this.btnKeluarProgram.Size = new System.Drawing.Size(90, 30);
            this.btnKeluarProgram.TabIndex = 76;
            this.btnKeluarProgram.Text = "LOGIN";
            this.btnKeluarProgram.UseVisualStyleBackColor = false;
            this.btnKeluarProgram.Click += new System.EventHandler(this.btnKeluarProgram_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(355, 218);
            this.Controls.Add(this.btnKeluarProgram);
            this.Controls.Add(this.txtuserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsandiUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Aplikasi Billing RSSA";
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
        private System.Windows.Forms.TextBox txtsandiUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtuserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeluarProgram;
    }
}