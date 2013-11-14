using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SIM_RS.RAWAT_INAP
{
    public partial class ManajemenPajak : Form
    {
        readonly C4Module.MainModule _modMain = new C4Module.MainModule();
        readonly C4Module.DatabaseModule _modDb = new C4Module.DatabaseModule();
        readonly C4Module.MessageModule _modMsg = new C4Module.MessageModule();
        readonly C4Module.SQLModule _modSql = new C4Module.SQLModule();
        readonly BackgroundWorker _bw = new BackgroundWorker();

        private string _strSQL;

        private class LstDaftarDokter
        {
            private readonly string _strKodeDokter;
            private readonly string _strNamaDokter;
            private readonly string _strSmf;
            private readonly string _npwp;
            private readonly string _strAlamat;

            public LstDaftarDokter(string strKodeDokter, string strNamaDokter, string strSmf, string npwp, string alamat)
            {
                _strKodeDokter = strKodeDokter;
                _strNamaDokter = strNamaDokter;
                _strSmf = strSmf;
                _npwp = npwp;
                _strAlamat = alamat;
            }

            public string StrSmf
            {
                get { return _strSmf; }
            }

            public string StrNamaDokter
            {
                get { return _strNamaDokter; }
            }

            public string StrKodeDokter
            {
                get { return _strKodeDokter; }
            }

            public string Npwp
            {
                get { return _npwp; }
            }

            public string Alamat
            {
                get { return _strAlamat; }
            }
        }
        readonly List<LstDaftarDokter> _grpSemuaDokter = new List<LstDaftarDokter>();
        readonly AutoCompleteStringCollection _listDokter = new AutoCompleteStringCollection();

        private bool _isInEditMode;

        public ManajemenPajak()
        {
            InitializeComponent();
            _bw.WorkerSupportsCancellation = true;
            _bw.WorkerReportsProgress = true;
            _bw.DoWork +=
                bw_DoWork;
            _bw.RunWorkerCompleted +=
                bw_RunWorkerCompleted;

            this.bwLoadDokter.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("id-ID");

            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }
            _strSQL =
                "SELECT MONTH(dbo.TR_PAV_PAJAK.tglSPJ), sum(dbo.TR_PAV_PAJAK.bruto), sum(dbo.TR_PAV_PAJAK.pph), " +
                "sum(dbo.TR_PAV_PAJAK.netto) " +
                "FROM dbo.TR_PAV_PAJAK WHERE dbo.TR_PAV_PAJAK.idmar_dokter = '" + lblKodeDokter.Text.Trim() + "' and year(dbo.TR_PAV_PAJAK.tglSPJ) = 2013 " +
                "GROUP BY MONTH(dbo.TR_PAV_PAJAK.tglSPJ)";
            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strSQL, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }
            if (reader.HasRows)
            {
                int increment = 1;
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(increment++));
                    item.SubItems.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)reader[0]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[1]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[2]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[3]));
                    lvPajakPerDokter.SafeControlInvoke(listview => lvPajakPerDokter.Items.Add(item));
                }
                _modSql.pvAutoResizeLV(lvPajakPerDokter, 5);
            }

            reader.Close();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //reserved
        }

        private void ManajemenPajak_Load(object sender, EventArgs e)
        {

            this.RVPajakBulanan.RefreshReport();
        }

        private void bwLoadDokter_DoWork(object sender, DoWorkEventArgs e)
        {
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            const string strQuerySql = "SELECT " +
                                       "MR_DOKTER.idmr_dokter, " +                 //0
                                       "MR_DOKTER.nama, " +                        //1
                                       "MR_DOKTER.idmr_tsmf, " +                    //2
                                       "MR_DOKTER.npwp, " +                        //3
                                       "MR_DOKTER.Alamat " +                        //4
                                       "FROM MR_DOKTER " +
                                       "WHERE MR_DOKTER.dipakai = 'Y'";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _listDokter.Clear();
            _grpSemuaDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _listDokter.Add(_modMain.pbstrgetCol(reader, 1, ref strErr, "") + " -- " + _modMain.pbstrgetCol(reader, 0, ref strErr, ""));
                    _grpSemuaDokter.Add(new LstDaftarDokter(_modMain.pbstrgetCol(reader, 0, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 1, ref strErr, ""), _modMain.pbstrgetCol(reader, 2, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 3, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 4, ref strErr, "")));
                }
            }

            reader.Close();

            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteCustomSource = _listDokter);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource);
        }

        private void txtNamaDokter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (!bgCariDataJaspel.IsBusy)
                //    bgCariDataJaspel.RunWorkerAsync();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }    
        }

        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            string strKodeNama = txtNamaDokter.Text.Trim();

            String[] strArrPart = Regex.Split(strKodeNama, "--");

            string strKode = strArrPart[1].Trim();

            lblKodeDokter.Text = strArrPart[1].Trim();
            lblNamaDokter.Text = strArrPart[0].Trim();

            int intResultSearch = _grpSemuaDokter.FindIndex(
                                    m => m.StrKodeDokter == strKode);
            if (!string.IsNullOrEmpty(txtNamaDokter.Text.Trim()))
            {
                if (intResultSearch == -1)
                {
                    MessageBox.Show(@"Nama Dokter yang anda masukkan tidak terdaftar",
                        @"Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    pvClearAll();
                    return;
                }
                _isInEditMode = false;
            }
            _isInEditMode = true;
        }

        private void pvClearAll()
        {
            tabControl1.SafeControlInvoke(tabControl => tabControl1.SelectedTab = tabPage1);
            txtNamaDokter.SafeControlInvoke(textBox =>
            {
                txtNamaDokter.Enabled = true;
                txtNamaDokter.Focus();
            });
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.Text = "");
            lvPajakPerDokter.SafeControlInvoke(listview => lvPajakPerDokter.Items.Clear());
            _isInEditMode = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _bw.RunWorkerAsync();
        }



    }
}
