namespace SIM_RS.RAWAT_INAP
{
    partial class LapTindPerOperator
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoBilling = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPeriodeTgl = new System.Windows.Forms.DateTimePicker();
            this.btnSimpanIsiTindakan = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer.Location = new System.Drawing.Point(8, 108);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(787, 451);
            this.reportViewer.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNoBilling);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 39);
            this.panel2.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "OPERATOR : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoBilling
            // 
            this.txtNoBilling.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoBilling.BackColor = System.Drawing.Color.White;
            this.txtNoBilling.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBilling.Location = new System.Drawing.Point(209, 4);
            this.txtNoBilling.Name = "txtNoBilling";
            this.txtNoBilling.Size = new System.Drawing.Size(188, 30);
            this.txtNoBilling.TabIndex = 1;
            this.txtNoBilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.dtpPeriodeTgl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 39);
            this.panel1.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "PERIODE TANGGAL : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPeriodeTgl
            // 
            this.dtpPeriodeTgl.CustomFormat = "dd MMMM yyyy";
            this.dtpPeriodeTgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodeTgl.Location = new System.Drawing.Point(209, 6);
            this.dtpPeriodeTgl.Name = "dtpPeriodeTgl";
            this.dtpPeriodeTgl.Size = new System.Drawing.Size(244, 29);
            this.dtpPeriodeTgl.TabIndex = 1;
            // 
            // btnSimpanIsiTindakan
            // 
            this.btnSimpanIsiTindakan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimpanIsiTindakan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnSimpanIsiTindakan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSimpanIsiTindakan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSimpanIsiTindakan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanIsiTindakan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSimpanIsiTindakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpanIsiTindakan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanIsiTindakan.Location = new System.Drawing.Point(480, 59);
            this.btnSimpanIsiTindakan.Name = "btnSimpanIsiTindakan";
            this.btnSimpanIsiTindakan.Size = new System.Drawing.Size(101, 30);
            this.btnSimpanIsiTindakan.TabIndex = 116;
            this.btnSimpanIsiTindakan.Text = "&Tampilkan";
            this.btnSimpanIsiTindakan.UseVisualStyleBackColor = false;
            // 
            // LapTindPerOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.btnSimpanIsiTindakan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.reportViewer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LapTindPerOperator";
            this.Text = "LAPORAN TINDAKAN BILLING PER OPERATOR";
            this.Load += new System.EventHandler(this.LapPerOperator_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoBilling;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpPeriodeTgl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSimpanIsiTindakan;
    }
}