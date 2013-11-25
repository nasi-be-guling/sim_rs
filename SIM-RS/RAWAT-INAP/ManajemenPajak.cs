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
        private class LstMasterPajak
        {
            private readonly string _strIdPajak;
            private readonly string _strKodeDokter;
            private readonly string _strNamaDokter;
            private readonly DateTime _tglSPJ;
            private readonly DateTime _tglAmbil;
            private readonly double _bruto;
            private readonly double _pph;
            private readonly string _strNpwp;

            public LstMasterPajak(string strKodeDokter, string strNamaDokter, DateTime tglSPJ, DateTime tglAmbil, double bruto, double pph, string strNpwp, string strIdPajak )
            {
                _strKodeDokter = strKodeDokter;
                _strNamaDokter = strNamaDokter;
                _tglSPJ = tglSPJ;
                _tglAmbil = tglAmbil;
                _bruto = bruto;
                _pph = pph;
                _strNpwp = strNpwp;
                _strIdPajak = strIdPajak;
            }

            public string StrIdPajak
            {
                get { return _strIdPajak; }
            }

            public string StrKodeDokter
            {
                get { return _strKodeDokter; }
            }

            public string StrNamaDokter
            {
                get { return _strNamaDokter; }
            }

            public DateTime TglSPJ
            {
                get { return _tglSPJ; }
            }

            public DateTime TglAmbil
            {
                get { return _tglAmbil; }
            }

            public string strNpwp
            {
                get { return _strNpwp; }
            }

            public double bruto
            {
                get { return _bruto; }
            }

            public double pph
            {
                get { return _pph; }
            }
        }

        readonly List<LstDaftarDokter> _grpSemuaDokter = new List<LstDaftarDokter>();
        readonly List<LstMasterPajak> _grpMasterPajak = new List<LstMasterPajak>();
        readonly AutoCompleteStringCollection _listDokter = new AutoCompleteStringCollection();
        readonly AutoCompleteStringCollection _listDokterSPJ = new AutoCompleteStringCollection();

        private bool _isInEditMode;

        public ManajemenPajak()
        {
            InitializeComponent();
            this.bwLoadDokter.RunWorkerAsync();
            this.bwLoadPajak.RunWorkerAsync();
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
                                       "MR_DOKTER.idmr_tsmf, " +                   //2
                                       "MR_DOKTER.npwp, " +                        //3
                                       "MR_DOKTER.Alamat " +                       //4
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

       

        /*
        *  NAME        : PvTampilPajak
        *  FUNCTION    : Menampilkan Semua Data Pajak dari grpMasterPajak ke List View
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 21-11-2013    
        */

        private void pvTampilPajak() {
            int noUrut = 1;
            lvDokterPajak.Items.Clear();
            var query = (from i in _grpMasterPajak
                         where i.TglAmbil.ToShortDateString() == dtpTglAmbil.Value.ToShortDateString()
                         select i);

            foreach (var pph in query)
            {
                lvDokterPajak.Items.Add(noUrut.ToString());
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.TglAmbil.ToString());
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.TglSPJ.ToString());
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.StrNamaDokter);
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.bruto.ToString());
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.pph.ToString());
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.StrKodeDokter);
                lvDokterPajak.Items[lvDokterPajak.Items.Count - 1].SubItems.Add(pph.StrIdPajak);
                noUrut++;
               
            }
        }
        private void btnTglAmbil_Click(object sender, EventArgs e)
        {           
            this.pvTampilPajak();
        }

        /*
        *  NAME        : PvLoadPajak
        *  FUNCTION    : Menampilkan Semua Data Pajak sejak Awal Form Dipanggil
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 25-11-2013    
        */
        private void bwLoadPajak_DoWork(object sender, DoWorkEventArgs e)
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
                                       "TR_PAV_PAJAK.idmar_dokter, " +      //0
                                       "MR_DOKTER.Nama, " +                 //1
                                       "TR_PAV_PAJAK.tglSPJ, " +            //2
                                       "TR_PAV_PAJAK.bruto, " +             //3
                                       "TR_PAV_PAJAK.pph, " +               //4
                                       "MR_DOKTER.npwp, " +                 //5
                                       "TR_PAV_PAJAK.tgl, " +               //6
                                       "TR_PAV_PAJAK.idPajak " +            //7
                                       "FROM TR_PAV_PAJAK " +
                                       "LEFT JOIN MR_DOKTER ON TR_PAV_PAJAK.idmar_dokter = MR_DOKTER.idmr_dokter ";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _grpMasterPajak.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _grpMasterPajak.Add(new LstMasterPajak(
                        _modMain.pbstrgetCol(reader, 0, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 1, ref strErr, ""),
                        Convert.ToDateTime(reader[2]),
                        Convert.ToDateTime(reader[6]),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 3, ref strErr, "")),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 4, ref strErr, "")),
                        _modMain.pbstrgetCol(reader, 5, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 7, ref strErr, "")));
                }
            }

            reader.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvDokterPajak_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) &&
                (lvDokterPajak.Items.Count > 0))
                {
                   cmsRubahTglSPJ.Show(this.lvDokterPajak, e.Location);
                }
        }

        private void rubahTanggalSPJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvDokterPajak.Enabled = false;
            var query = (from i in _grpMasterPajak
                         where i.StrIdPajak == lvDokterPajak.SelectedItems[0].SubItems[7].Text
                         select i);

            foreach (var pph in query)
            {
                lblIdPajak.Text = pph.StrIdPajak.ToString();
            }
        }

        /*
        *  NAME        : pvRefreshDataPajak
        *  FUNCTION    : Me-Refreshkan data Pajak baru setelah penggantian data SPJ 
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 25-11-2013    
        */
        private void pvRefreshDataPajak()
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
                                       "TR_PAV_PAJAK.idmar_dokter, " +      //0
                                       "MR_DOKTER.Nama, " +                 //1
                                       "TR_PAV_PAJAK.tglSPJ, " +            //2
                                       "TR_PAV_PAJAK.bruto, " +             //3
                                       "TR_PAV_PAJAK.pph, " +               //4
                                       "MR_DOKTER.npwp, " +                 //5
                                       "TR_PAV_PAJAK.tgl, " +               //6
                                       "TR_PAV_PAJAK.idPajak " +            //7
                                       "FROM TR_PAV_PAJAK " +
                                       "LEFT JOIN MR_DOKTER ON TR_PAV_PAJAK.idmar_dokter = MR_DOKTER.idmr_dokter ";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _grpMasterPajak.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _grpMasterPajak.Add(new LstMasterPajak(
                        _modMain.pbstrgetCol(reader, 0, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 1, ref strErr, ""),
                        Convert.ToDateTime(reader[2]),
                        Convert.ToDateTime(reader[6]),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 3, ref strErr, "")),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 4, ref strErr, "")),
                        _modMain.pbstrgetCol(reader, 5, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 7, ref strErr, "")));
                }
            }

            reader.Close();
            this.pvTampilPajak();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            /* UPDATE changes TO DATABASE */
            string strQuerySql = "UPDATE TR_PAV_PAJAK " +
                                    "SET tglSPJ = '" + string.Format("{0: MM/dd/yyyy HH:mm:ss}", dtpTglSPJ.Value) + "' " +
                                    "WHERE idPajak = " + lblIdPajak.Text;

            _modDb.pbWriteSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {

                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            MessageBox.Show("Data Berhasil Disimpan");
            conn.Close();
            lblIdPajak.Text = "";
            lvDokterPajak.Enabled = true;
            this.pvRefreshDataPajak();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }












    }
}
