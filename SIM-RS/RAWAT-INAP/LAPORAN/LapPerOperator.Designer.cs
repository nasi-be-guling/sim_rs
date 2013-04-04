namespace SIM_RS.RAWAT_INAP
{
    partial class LapPerOperator
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dtpPeriodeTgl = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lvDaftarTindakan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lblInfoPencarian = new System.Windows.Forms.Label();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer.Location = new System.Drawing.Point(649, 57);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(146, 425);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblInfoPencarian);
            this.panel1.Controls.Add(this.btnTampilkan);
            this.panel1.Controls.Add(this.dtpPeriodeTgl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 39);
            this.panel1.TabIndex = 115;
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTampilkan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.btnTampilkan.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTampilkan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTampilkan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilkan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilkan.Location = new System.Drawing.Point(461, 5);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(101, 30);
            this.btnTampilkan.TabIndex = 116;
            this.btnTampilkan.Text = "&Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = false;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
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
            // lvDaftarTindakan
            // 
            this.lvDaftarTindakan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDaftarTindakan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvDaftarTindakan.FullRowSelect = true;
            this.lvDaftarTindakan.GridLines = true;
            this.lvDaftarTindakan.HideSelection = false;
            this.lvDaftarTindakan.Location = new System.Drawing.Point(4, 49);
            this.lvDaftarTindakan.Name = "lvDaftarTindakan";
            this.lvDaftarTindakan.Size = new System.Drawing.Size(792, 472);
            this.lvDaftarTindakan.TabIndex = 116;
            this.lvDaftarTindakan.UseCompatibleStateImageBehavior = false;
            this.lvDaftarTindakan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Register";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nama";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ruang";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Bukti Trans";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Uraian Tarif";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nominal";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Dokter";
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
            this.btnKeluar.Location = new System.Drawing.Point(697, 529);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(101, 30);
            this.btnKeluar.TabIndex = 117;
            this.btnKeluar.Text = "&KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluarIsiTindakan_Click);
            // 
            // lblInfoPencarian
            // 
            this.lblInfoPencarian.AutoSize = true;
            this.lblInfoPencarian.ForeColor = System.Drawing.Color.Black;
            this.lblInfoPencarian.Location = new System.Drawing.Point(585, 10);
            this.lblInfoPencarian.Name = "lblInfoPencarian";
            this.lblInfoPencarian.Size = new System.Drawing.Size(200, 21);
            this.lblInfoPencarian.TabIndex = 117;
            this.lblInfoPencarian.Text = "Proses Menampilkan Data...";
            this.lblInfoPencarian.Visible = false;
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 1000;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // LapPerOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(802, 566);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lvDaftarTindakan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LapPerOperator";
            this.Text = "LAPORAN TINDAKAN BILLING PER OPERATOR";
            this.Load += new System.EventHandler(this.LapPerOperator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpPeriodeTgl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.ListView lvDaftarTindakan;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblInfoPencarian;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Timer timerBlink;
    }
}