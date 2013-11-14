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
            this.bwLoadDokter.RunWorkerAsync();
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
                                       "FROM MR_DOKTER WITH (NOLOCK) " +
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



    }
}
