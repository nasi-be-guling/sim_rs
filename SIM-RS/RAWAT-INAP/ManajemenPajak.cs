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
        private int intLvNoRekap = 1;
        private string strNamaFile = "";  

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
        public class LstRekapPajakDokter
        {
            public string strtglspj { get; set; }
            public string strnamadokter { get; set; }
            public string strbruto { get; set; }
            public string strpph { get; set; }
            public string netto { get; set; }
        }    

        public class LstPajakPerDokter{
            public string strNoUrut { get; set; }
            public string strbulanSPJ { get; set; }
            public double dblBruto { get; set; }
            public double dblPph { get; set; }
            public string strNamaDokter { get; set; }
            public string strNPWP { get; set; }
        }

        #region LIST UNTUK REPORT

        public class ReportPajakPerDokter
        {
            public ReportPajakPerDokter(string npwp, string namaDokter, string bulan, decimal bruto, decimal pph, decimal netto)
            {
                Npwp = npwp;
                NamaDokter = namaDokter;
                Bulan = bulan;
                Bruto = bruto;
                Pph = pph;
                Netto = netto;
            }
            public string Npwp { get; set; }
            public string NamaDokter { get; set; }
            public string Bulan { get; set; }
            public decimal Bruto { get; set; }
            public decimal Pph { get; set; }
            public decimal Netto { get; set; }
        }

        #endregion

        readonly List<LstDaftarDokter> _grpSemuaDokter = new List<LstDaftarDokter>();
        readonly List<LstMasterPajak> _grpMasterPajak = new List<LstMasterPajak>();
        readonly List<LstPajakPerDokter> _grpPajakPerDokter = new List<LstPajakPerDokter>();
        readonly List<LstRekapPajakDokter> _grpRekapPajakDokter = new List<LstRekapPajakDokter>();
        readonly AutoCompleteStringCollection _listDokter = new AutoCompleteStringCollection();
        readonly AutoCompleteStringCollection _listDokterSPJ = new AutoCompleteStringCollection();
        readonly List<ReportPajakPerDokter> _listPajakPerDokter = new List<ReportPajakPerDokter>();

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
            this.bwLoadPajak.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string namadokter = null;
            string npwpdokter = null;
            lvPajakPerDokter.SafeControlInvoke(listview => lvPajakPerDokter.Items.Clear());
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
            SqlDataReader reader = _modDb.pbreaderSQL(conn, "select nama, npwp from mr_dokter where idmr_dokter = '"+lblKodeDokter.Text.Trim()+"'", ref strErr);
            if (reader.HasRows)
            {
                reader.Read();
                namadokter = _modMain.pbstrgetCol(reader, 0, ref strErr, "");
                npwpdokter = _modMain.pbstrgetCol(reader, 1, ref strErr, "");
                reader.Close();
            }
            _strSQL =
                "SELECT MONTH(dbo.TR_PAV_PAJAK.tglSPJ), sum(dbo.TR_PAV_PAJAK.bruto), sum(dbo.TR_PAV_PAJAK.pph), " +
                "sum(dbo.TR_PAV_PAJAK.netto) " +
                "FROM dbo.TR_PAV_PAJAK WHERE dbo.TR_PAV_PAJAK.idmar_dokter = '" + lblKodeDokter.Text.Trim() + "' and year(dbo.TR_PAV_PAJAK.tglSPJ) = 2013 " +
                "GROUP BY MONTH(dbo.TR_PAV_PAJAK.tglSPJ)";
            reader = _modDb.pbreaderSQL(conn, _strSQL, ref strErr);
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
                    _listPajakPerDokter.Add(new ReportPajakPerDokter(npwpdokter, namadokter, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)reader[0]), 
                        Convert.ToDecimal(reader[1]), Convert.ToDecimal(reader[2]), Convert.ToDecimal(reader[3])));
                    
                    ListViewItem item = new ListViewItem(Convert.ToString(increment++));
                    item.SubItems.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)reader[0]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[1]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[2]));
                    item.SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[3]));
                    lvPajakPerDokter.SafeControlInvoke(listview => lvPajakPerDokter.Items.Add(item));

                    // ngisor iki gawe opo vi????????
                    LstPajakPerDokter itemPajakPerDokter = new LstPajakPerDokter();
                    //itemPajakPerDokter.strNoUrut = Convert.ToString(increment++); << ayahab
                    itemPajakPerDokter.strbulanSPJ = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)reader[0]);
                    itemPajakPerDokter.dblBruto = Convert.ToDouble(reader[1]);
                    itemPajakPerDokter.dblPph = Convert.ToDouble(reader[2]);
                    _grpPajakPerDokter.Add(itemPajakPerDokter);
                }
                _modSql.pvAutoResizeLV(lvPajakPerDokter, 5);
            }

            reader.Close();
            conn.Close();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RVPajakBulanan.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource buktiPajak = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", _listPajakPerDokter); // set the datasource
            RVPajakBulanan.LocalReport.DataSources.Add(buktiPajak);
            buktiPajak.Value = _listPajakPerDokter;
            RVPajakBulanan.LocalReport.Refresh();
            RVPajakBulanan.RefreshReport();
        }

        private void ManajemenPajak_Load(object sender, EventArgs e)
        {
            RVPajakBulanan.RefreshReport();
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

            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.AutoCompleteCustomSource = _listDokter);
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource);
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
            lvDokterPajak.Items.Clear();
            lvDokterPajak.Enabled = true;
            btnSimpan.Enabled = false;
            
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

        private void bwRekapitulasi_DoWork(object sender, DoWorkEventArgs e)
        {
            InfoProsesExcell.SafeControlInvoke(Label => InfoProsesExcell.Visible = true);
            InfoProsesExcell.SafeControlInvoke(Label => InfoProsesExcell.Text = "Proses Load Data Rekap...");
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = false);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = false);

            DateTime dtTglServer = DateTime.Now;
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            string strQuerySql = "SELECT a.tglSPJ, b.Nama, a.bruto, a.pph, a.netto " +
                                 "FROM TR_PAV_PAJAK a INNER JOIN MR_DOKTER b ON b.idmr_dokter = a.idmar_dokter " +
                                 "WHERE a.tglSPJ BETWEEN '" + dtpRentang1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                 "' AND '" + dtpRentang2.Value.ToString("MM/dd/yyyy 23:59:59") +
                                 "' ORDER BY a.tglSPJ DESC";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            InfoProsesExcell.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items.Clear());
            _grpRekapPajakDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LstRekapPajakDokter itemRekapPajakDokter = new LstRekapPajakDokter();
                    itemRekapPajakDokter.strtglspj = string.Format(new CultureInfo("id-ID"), "{0:dd/MMMM/yyyy}", reader[0]);
                    itemRekapPajakDokter.strnamadokter = _modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemRekapPajakDokter.strbruto = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[2]);
                    itemRekapPajakDokter.strpph = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[3]);
                    itemRekapPajakDokter.netto = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[4]);
                    _grpRekapPajakDokter.Add(itemRekapPajakDokter);

                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items.Add(Convert.ToString(intLvNoRekap)));
                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items[lvPajakRekapitulasi.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "{0:dd/MMMM/yyyy}", reader[0])));
                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items[lvPajakRekapitulasi.Items.Count - 1].SubItems.Add(_modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items[lvPajakRekapitulasi.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[2])));
                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items[lvPajakRekapitulasi.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[3])));
                    lvPajakRekapitulasi.SafeControlInvoke(ListView => lvPajakRekapitulasi.Items[lvPajakRekapitulasi.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", reader[4])));
                    intLvNoRekap++;
                }
            }

            reader.Close();
            conn.Close();

            InfoProsesExcell.SafeControlInvoke(Label => InfoProsesExcell.Visible = false);
            InfoProsesExcell.SafeControlInvoke(Label => InfoProsesExcell.Text = "");
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = false);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.Title = "Pilih Lokasi Export File";
                dialog.DefaultExt = "*.xlsx";
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    strNamaFile = dialog.FileName;
                }
            }

            if (strNamaFile.Trim().ToString() != "")
            {
                if (!bwRekapitulasi.IsBusy)
                    this.bwRekapitulasi.RunWorkerAsync();
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (!bwRekapitulasi.IsBusy)
                this.bwRekapitulasi.RunWorkerAsync();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }






    }
}
