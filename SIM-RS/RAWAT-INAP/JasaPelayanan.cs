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
    public partial class JasaPelayanan : Form
    {
        readonly C4Module.MainModule _modMain = new C4Module.MainModule();
        readonly C4Module.DatabaseModule _modDb = new C4Module.DatabaseModule();
        readonly C4Module.MessageModule _modMsg = new C4Module.MessageModule();
        readonly BackgroundWorker _bw1 = new BackgroundWorker();
        readonly BackgroundWorker _bw2 = new BackgroundWorker();

        string _strErr = "";
        string _strQuerySql = "";
        private decimal _netto;
        private decimal _pphGlobal;

        /*
        *  NAME        : Kumpulan List
        *  FUNCTION    : merapikan List-list yang ada
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 24-10-2013    
        */

        #region

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

        private class LstDaftarJasaPelayanan // tak ubah sesuai ketentuan berlaku
        {
            readonly string _strNoBilling;
            readonly string _strNamaPasien;
            readonly string _strStatusPasien;
            readonly string _strTglPulang;
            readonly string _strNamaTarif;
            readonly double _dblJasaMedis;
            readonly double _dblKeringanan;
            readonly double _dblHslBersih;
            readonly string _strKodeDokter;
            readonly string _strNamaSMF;
            readonly string _strKodeTransaksi;
            readonly string _strNamaDokter;

             public LstDaftarJasaPelayanan(string strNoBilling, string strNamaPasien, string strStatusPasien, 
                string strTglPulang, string strNamaTarif, double dblJasaMedis, double dblKeringanan, double dblHslBersih,                
                string strKodeDokter, string strKodeTransaksi, string strNamaDokter, string strNamaSMF)
            {
                _dblHslBersih = dblHslBersih;
                _dblJasaMedis = dblJasaMedis;
                _dblKeringanan = dblKeringanan;
                _strKodeDokter = strKodeDokter;
                _strKodeTransaksi = strKodeTransaksi;
                _strNamaPasien = strNamaPasien;
                _strNamaTarif = strNamaTarif;
                _strNoBilling = strNoBilling;
                _strStatusPasien = strStatusPasien;
                _strTglPulang = strTglPulang;
                _strNamaDokter = strNamaDokter;
                _strNamaSMF = strNamaSMF;
            }

            public string StrKodeTransaksi
            {
                get { return _strKodeTransaksi; }
            }

            public string StrKodeDokter
            {
                get { return _strKodeDokter; }
            }

            public double DblHslBersih
            {
                get { return _dblHslBersih; }
            }

            public double DblKeringanan
            {
                get { return _dblKeringanan; }
            }

            public double DblJasaMedis
            {
                get { return _dblJasaMedis; }
            }

            public string StrNamaTarif
            {
                get { return _strNamaTarif; }
            }

            public string StrTglPulang
            {
                get { return _strTglPulang; }
            }

            public string StrStatusPasien
            {
                get { return _strStatusPasien; }
            }

            public string StrNamaPasien
            {
                get { return _strNamaPasien; }
            }

            public string StrNamaDokter
            {
                get { return _strNamaDokter; }
            }

            public string StrNoBilling
            {
                get { return _strNoBilling; }
            }

            public string StrNamaSMF
            {
                get { return _strNamaSMF; }
            }
        }

        public class KwitansiDokter
        {
            private readonly string _nama;
            private readonly decimal _bruto;
            private readonly decimal _jasaAdm;
            private readonly decimal _pph21;
            private readonly DateTime _tglambil;
            private readonly decimal _netto;
            private readonly string _idmrDokter;
            private readonly string _terbilang;
            private readonly string _npwp;
            
            public KwitansiDokter(decimal bruto, string idmrDokter, decimal jasaAdm, string nama, decimal netto, string npwp, decimal pph21, string terbilang, DateTime tglambil)
            {
                _bruto = bruto;
                _idmrDokter = idmrDokter;
                _jasaAdm = jasaAdm;
                _nama = nama;
                _netto = netto;
                _npwp = npwp;
                _pph21 = pph21;
                _terbilang = terbilang;
                _tglambil = tglambil;
            }

            public string Npwp
            {
                get { return _npwp; }
            }

            public string Terbilang
            {
                get { return _terbilang; }
            }

            public string IdmrDokter
            {
                get { return _idmrDokter; }
            }

            public decimal Netto
            {
                get { return _netto; }
            }

            public DateTime Tglambil
            {
                get { return _tglambil; }
            }

            public decimal Pph21
            {
                get { return _pph21; }
            }

            public decimal JasaAdm
            {
                get { return _jasaAdm; }
            }

            public decimal Bruto
            {
                get { return _bruto; }
            }

            public string Nama
            {
                get { return _nama; }
            }
        }

        public class lstKwitansiNonDokter
        {
            private readonly string _nama;
            private readonly decimal _bruto;
            private readonly decimal _jasaAdm;
            private readonly decimal _pph21;
            private readonly DateTime _tglambil;
            private readonly decimal _netto;
            private readonly string _idmrDokter;
            private readonly string _terbilang;
            private readonly string _npwp;

            public lstKwitansiNonDokter(decimal bruto, string idmrDokter, decimal jasaAdm, string nama, decimal netto, string npwp, decimal pph21, string terbilang, DateTime tglambil)
            {
                _bruto = bruto;
                _idmrDokter = idmrDokter;
                _jasaAdm = jasaAdm;
                _nama = nama;
                _netto = netto;
                _npwp = npwp;
                _pph21 = pph21;
                _terbilang = terbilang;
                _tglambil = tglambil;
            }

            public string Npwp
            {
                get { return _npwp; }
            }

            public string Terbilang
            {
                get { return _terbilang; }
            }

            public string IdmrDokter
            {
                get { return _idmrDokter; }
            }

            public decimal Netto
            {
                get { return _netto; }
            }

            public DateTime Tglambil
            {
                get { return _tglambil; }
            }

            public decimal Pph21
            {
                get { return _pph21; }
            }

            public decimal JasaAdm
            {
                get { return _jasaAdm; }
            }

            public decimal Bruto
            {
                get { return _bruto; }
            }

            public string Nama
            {
                get { return _nama; }
            }
        }

        public class LstBuktiPajak 
        {
            private readonly string _nama;
            private readonly string _npwp;
            private readonly string _alamat;
            private readonly string _bruto;
            private readonly string _pph21;
            private readonly DateTime _tglambil;
            
            public LstBuktiPajak(string bruto, string nama, string npwp, string pph21, DateTime tglambil,string alamat)
            {
                _bruto = bruto;      
                _nama = nama;
                _npwp = npwp;
                _pph21 = pph21;
                _tglambil = tglambil;
                _alamat = alamat;
            }

            public string Npwp
            {
                get { return _npwp; }
            }

            public string Alamat
            {
                get { return _alamat; }
            }

            public DateTime Tglambil
            {
                get { return _tglambil; }
            }

            public string Pph21
            {
                get { return _pph21; }
            }

            public string Bruto
            {
                get { return _bruto; }
            }

            public string Nama
            {
                get { return _nama; }
            }
        }

        readonly List<LstDaftarJasaPelayanan> _grpJasaPelayanan = new List<LstDaftarJasaPelayanan>();
        readonly List<LstDaftarDokter> _grpSemuaDokter = new List<LstDaftarDokter>();
        List<KwitansiDokter> _kwitansis = new List<KwitansiDokter>();
        List<LstBuktiPajak> _BuktiPajak = new List<LstBuktiPajak>();
     

        #endregion


        halamanUtama fHalamanUtama = null;

        /*Daftar Autocomplete*/
        readonly AutoCompleteStringCollection _listDokter = new AutoCompleteStringCollection();
        
        public JasaPelayanan()
        {
            InitializeComponent();           
            #region backgroundworker
            _bw1.WorkerSupportsCancellation = true;
            _bw1.WorkerReportsProgress = true;
            _bw1.DoWork +=
                bw1_DoWork;
            _bw1.RunWorkerCompleted +=
                bw1_RunWorkerCompleted;

            _bw2.WorkerSupportsCancellation = true;
            _bw2.WorkerReportsProgress = true;
            _bw2.DoWork +=
                bw2_DoWork;
            _bw2.RunWorkerCompleted +=
                bw2_RunWorkerCompleted; 
            #endregion
            this.bgLaodDokter.RunWorkerAsync();
            txtNamaDokter.Focus();

        }

        private void txtNamaDokter_Enter(object sender, EventArgs e)
        {
            txtNamaDokter.Text = "";
            txtNamaDokter.CharacterCasing = CharacterCasing.Upper;             
        }

        private void txtNamaDokter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!bgCariDataJaspel.IsBusy)
                bgCariDataJaspel.RunWorkerAsync();
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

        private bool _isInEditMode;

        /*
        *  NAME        : PvTampilan Laporan
        *  FUNCTION    : Menampilkan Laporan Detail Jasa Pelayanan
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 24-10-2013    
        */

        private void PvTampilLaporan() {

            RVDetailJaspel.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource dsDetailJasaPelayanan = new Microsoft.Reporting.WinForms.ReportDataSource("dsDetailJasaPelayanan", _grpJasaPelayanan); // set the datasource
            RVDetailJaspel.LocalReport.DataSources.Add(dsDetailJasaPelayanan);
            dsDetailJasaPelayanan.Value = _grpJasaPelayanan;
            RVDetailJaspel.LocalReport.Refresh();
            RVDetailJaspel.RefreshReport();

        }

        /*
        *  NAME        : PvTampilLaporanBuktiPajak
        *  FUNCTION    : Menampilkan Laporan Bukti telah dipotong PPh pasal 21
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 24-10-2013    
        */

        private void PvTampilLaporanBuktiPajak()
        {
            rvBuktiPajak.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource BuktiPajak = new Microsoft.Reporting.WinForms.ReportDataSource("BuktiPajak", _BuktiPajak); // set the datasource
            rvBuktiPajak.LocalReport.DataSources.Add(BuktiPajak);
            BuktiPajak.Value = _BuktiPajak;
            rvBuktiPajak.LocalReport.Refresh();
            rvBuktiPajak.RefreshReport();

        }

        /*
        *  NAME        : PvTampilLaporanKwi
        *  FUNCTION    : Menampilkan Laporan Kuitansi 
        *  RESULT      : -
        *  CREATED     : Team Software RSSA
        *  DATE        : 24-10-2013    
        */

        private void PvTampilLaporanKwi()
        {
            if (cbKetenagaan.SelectedIndex == 0)
            {
                kwi_viewer.LocalReport.DataSources.Clear(); //clear report

                Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", _kwitansis); // set the datasource
                kwi_viewer.LocalReport.DataSources.Add(DataSet1);
                DataSet1.Value = _kwitansis;
                this.kwi_viewer.LocalReport.ReportEmbeddedResource = "SIM_RS.LAPORAN_PRINOUT.KuitansiDokter.rdlc";
                kwi_viewer.LocalReport.Refresh();

                kwi_viewer.RefreshReport();
            }
            else if (cbKetenagaan.SelectedIndex == 1)
            {
                kwi_viewer.LocalReport.DataSources.Clear(); //clear report

                Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", _kwitansis); // set the datasource
                kwi_viewer.LocalReport.DataSources.Add(DataSet1);
                DataSet1.Value = _kwitansis;


                kwi_viewer.LocalReport.ReportEmbeddedResource = "SIM_RS.LAPORAN_PRINOUT.KuitansiNonDokter.rdlc";

                kwi_viewer.LocalReport.Refresh();

                kwi_viewer.RefreshReport();
            }
        }

        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            string strKodeNama = txtNamaDokter.Text.Trim();

            String[] strArrPart = Regex.Split(strKodeNama, "--");

            string strKode = strArrPart[0].Trim();

            lblKodeDokter.Text = strArrPart[0].Trim();
            lblNamaDokter.Text = strArrPart[1].Trim();

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
                    Bersih2();
                    return;
                }
                _isInEditMode = false;
            }
            _isInEditMode = true;
        }

        private void bgCariDataJaspel_DoWork(object sender, DoWorkEventArgs e)
        {
            lblInfoPencarian.SafeControlInvoke(label => lblInfoPencarian.Visible = true);
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.Enabled = false);
            btnBatalJasPel.SafeControlInvoke(button => btnBatalJasPel.Enabled = false);
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                lblInfoPencarian.SafeControlInvoke(label => lblInfoPencarian.Visible = false);
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            lblInfoPencarian.SafeControlInvoke(label => lblInfoPencarian.Text = @"MENCARI JASA PELAYANAN");
            String strQuerySql =
                    "SELECT BL_KASPAV.Regbilling, " +                                   //0
                    "MR_PASIEN.Nama, " +                                                //1
                    "BL_KASPAV.Idmr_Tstatus, " +                                        //2
                    "Convert(Varchar(12),BL_KASPAV.Tanggal,105), " +                    //3            
                    "BL_TRANSAKSI.Uraiantarip, " +                                      //4    
                    "BL_TRANSAKSIDETAIL.idbl_komponen, " +                              //5    
                    "BL_TRANSAKSIDETAIL.nilai, " +                                      //6
                    "BL_TRANSAKSIDETAIL.Ringan, " +                                     //7
                    "BL_TRANSAKSIDETAIL.nilai - BL_TRANSAKSIDETAIL.Ringan as tunai, " + //8
                    "BL_TRANSAKSIDETAIL.idmr_dokter, " +                                //9
                    "BL_TRANSAKSI.idbl_transaksi, " +                                   //10
                    "MR_DOKTER.Nama, " +                                                 //11
                    "MR_TSMF.idmr_smf " +                                                //12
                    "FROM BL_TRANSAKSI  With (nolock) " +
                    "INNER JOIN BL_KASPAV ON BL_TRANSAKSI.idmr_mutasipasien = BL_KASPAV.Idmr_mutasipasien " +
                    "INNER JOIN BL_TRANSAKSIDETAIL ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.idbl_transaksi " +
                    "INNER JOIN MR_PASIEN ON BL_KASPAV.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                    "INNER JOIN MR_DOKTER ON BL_TRANSAKSIDETAIL.idmr_dokter = MR_DOKTER.idmr_dokter " +
                    "INNER JOIN MR_TSMF ON MR_TSMF.idmr_tsmf = MR_DOKTER.idmr_tsmf " +
                    "WHERE (BL_TRANSAKSI.Batal = '') AND (BL_KASPAV.Batal = '') " +
                    "AND (BL_TRANSAKSIDETAIL.idbl_komponen = 'JASA PELAYANAN') " +
                    "AND (BL_TRANSAKSIDETAIL.noambil = 0) " +
                    "AND (BL_TRANSAKSIDETAIL.idbl_pembayaran > 0) " +
                    "AND BL_TRANSAKSIDETAIL.idmr_dokter = '"+lblKodeDokter.Text+"' " +
                    "ORDER BY BL_KASPAV.Regbilling,BL_KASPAV.Tanggal,BL_TRANSAKSI.idbl_transaksi";

            
            SqlDataReader reader = _modDb.pbreaderSQL(conn, strQuerySql, ref strErr);
            if (strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _grpJasaPelayanan.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _grpJasaPelayanan.Add(new LstDaftarJasaPelayanan(_modMain.pbstrgetCol(reader, 0, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 1, ref strErr, ""), _modMain.pbstrgetCol(reader, 2, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 3, ref strErr, ""), _modMain.pbstrgetCol(reader, 4, ref strErr, ""),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 6, ref strErr, "")), Convert.ToDouble(_modMain.pbstrgetCol(reader, 7, ref strErr, "")),
                        Convert.ToDouble(_modMain.pbstrgetCol(reader, 8, ref strErr, "")), _modMain.pbstrgetCol(reader, 9, ref strErr, ""),
                        _modMain.pbstrgetCol(reader, 10, ref strErr, ""), _modMain.pbstrgetCol(reader, 11, ref strErr, ""), _modMain.pbstrgetCol(reader, 12, ref strErr, "")
                        ));
                }

            }
            else
            {
                MessageBox.Show(@"Semua Jasa Pelayanan Sudah Diambil ", @"Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isInEditMode = false;
                Bersih2();
            }
            _isEntryPajak = false;
            lblInfoPencarian.SafeControlInvoke(label => lblInfoPencarian.Visible = false);
            reader.Close();
            btnBatalJasPel.SafeControlInvoke(button => btnBatalJasPel.Enabled = true);
        }

        private void Bersih2()
        {
            tabControl1.SafeControlInvoke(tabControl => tabControl1.SelectedTab = tabPage1);
            txtNamaDokter.SafeControlInvoke(textBox =>
            {
                txtNamaDokter.Enabled = true;
                txtNamaDokter.Focus();
            });
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.Text = "");
            lvJasaPelayanan.SafeControlInvoke(listview => lvJasaPelayanan.Items.Clear());
            _isInEditMode = false;
            _grpJasaPelayanan.Clear();
            _isEntryPajak = false;
            lblJmlJaspel.SafeControlInvoke(label => lblJmlJaspel.Text = @".......");
            lblJmlJaspelAsli.SafeControlInvoke(label => lblJmlJaspelAsli.Text = @".......");
            lblJasaAdministrasi.SafeControlInvoke(label => lblJasaAdministrasi.Text = @".......");
            lblJasaAdministrasiAsli.SafeControlInvoke(label => lblJasaAdministrasiAsli.Text = @".......");
            lblPPhAhli.SafeControlInvoke(label => lblPPhAhli.Text = @".......");
            lblPPhAhliAsli.SafeControlInvoke(label => lblPPhAhliAsli.Text = @".......");
            lblPPhNonAhli.SafeControlInvoke(label => lblPPhNonAhli.Text = @".......");
            lblPPhNonAhliAsli.SafeControlInvoke(label => lblPPhNonAhliAsli.Text = @".......");
            lblTotalPenerimaan.SafeControlInvoke(label => lblTotalPenerimaan.Text = @".......");
            lblTotalJasaPelayanan.SafeControlInvoke(label => lblTotalJasaPelayanan.Text = @".......");
            txtNilaiProsentase.SafeControlInvoke(label => lblPPhNonAhli.Text = @".......");
        }

        private void PvTampilList()
        {
            int noUrut = 1;
            var query = (from i in _grpJasaPelayanan
                         select i);

            lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items.Clear());
            foreach (var jaspel in query)
            {
                int urut = noUrut;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items.Add(urut.ToString(CultureInfo.InvariantCulture)));
                LstDaftarJasaPelayanan jaspel1 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel1.StrNoBilling));
                LstDaftarJasaPelayanan jaspel2 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel2.StrNamaPasien));
                LstDaftarJasaPelayanan jaspel3 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel3.StrStatusPasien));
                LstDaftarJasaPelayanan jaspel4 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel4.StrTglPulang));
                LstDaftarJasaPelayanan jaspel5 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel5.StrNamaTarif));
                LstDaftarJasaPelayanan jaspel6 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel6.DblJasaMedis)));
                LstDaftarJasaPelayanan jaspel7 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel7.DblKeringanan)));
                LstDaftarJasaPelayanan jaspel8 = jaspel;
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel8.DblHslBersih)));
                noUrut++;
            }

            var suma = (from s in _grpJasaPelayanan select s.DblHslBersih).Sum();
            lblTotalJasaPelayanan.SafeControlInvoke(label => lblTotalJasaPelayanan.Text = "Jumlah : " + string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", suma));
            lblJmlJaspel.SafeControlInvoke(label => lblJmlJaspel.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", suma));
            _biayaAdm = 0.1 * Convert.ToDouble(suma);
            lblJmlJaspelAsli.Text = "" + Convert.ToDouble(suma);
            _bruto = (decimal) suma;
            lblJasaAdministrasi.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", _biayaAdm);
            lblJasaAdministrasiAsli.Text = "" + _biayaAdm;
            cbKetenagaan.Text = @"Tenaga Ahli";
            cbKetenagaan.Focus();
        }

        private decimal _bruto;
        private Double _biayaAdm;

        private void JasaPelayanan_Load(object sender, EventArgs e)
        {
            

            fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];
            lblPetugas.Text = fHalamanUtama.txtPetugas.Text;
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("id-ID");
            _servertime = GetServerTime();
            RVDetailJaspel.RefreshReport();
            kwi_viewer.RefreshReport();
        }

        private void btnBatalJasPel_Click(object sender, EventArgs e)
        {
            Bersih2();
        }

        private string _servertime;

        private void txtNilaiProsentase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String pajak = _modMain.pbstrBersihkanInput(txtNilaiProsentase.Text);
                Double pajakAhli = (Convert.ToDouble(pajak) / 100) * (Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.5);
                lblPPhAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", pajakAhli);
                lblPPhAhliAsli.Text = "" + pajakAhli;
                Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                                            - pajakAhli;
                lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
                _pphGlobal = (decimal) pajakAhli;
                CekIsentryPajak();
                _bw2.RunWorkerAsync();
                this.pvReportBuktiPajak();
            }
        }

        private void cbKetenagaan_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbKetenagaan.Text == @"Tenaga Ahli")
            {
                txtNilaiProsentase.Enabled = true;
                txtNilaiProsentase.Focus();
                lblPPhNonAhli.Text = "";
                lblPPhNonAhliAsli.Text = "";
                PvTampilLaporanKwi();
                PvTampilLaporanBuktiPajak();
            }
            else
            {
                PvTampilLaporanKwi();
                txtNilaiProsentase.Text = "";
                txtNilaiProsentase.Enabled = false;
                lblPPhAhli.Text = "";
                lblPPhAhliAsli.Text = "";

                _pajakNonAhli = Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.05;
                lblPPhNonAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", _pajakNonAhli);
                lblPPhNonAhliAsli.Text = "" + _pajakNonAhli;
                Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                            - _pajakNonAhli;
                lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
                _pphGlobal = (decimal)_pajakNonAhli;
                PvTampilLaporanBuktiPajak();
            }
            CekIsentryPajak();
            _bw2.RunWorkerAsync();
        }

        private Double _pajakNonAhli;
        private void cbKetenagaan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbKetenagaan.Text == @"Tenaga Ahli")
                {
                    txtNilaiProsentase.Enabled = true;
                    txtNilaiProsentase.Focus();
                }
                else
                {
                    txtNilaiProsentase.Text = "";
                    txtNilaiProsentase.Enabled = false;
                    lblPPhAhli.Text = "";
                    lblPPhAhliAsli.Text = "";
                    _pajakNonAhli = Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.05;
                    _pphGlobal = (decimal) _pajakNonAhli;
                    lblPPhNonAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", _pajakNonAhli);
                    lblPPhNonAhliAsli.Text = "" + _pajakNonAhli;
                    Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                           - _pajakNonAhli;
                    _netto = Convert.ToDecimal(totalPenerimaan);
                    lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
                }
                CekIsentryPajak();
            }
        }

        #region PROSES UPDATE KE BL_TRAKSAKSI_DETAIL
        private int GetMaxNoAmbil()
        {
            _strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);

                return 0;
            }
            _strQuerySql = "select MAX(noambil) from BILLING..BL_TRANSAKSIDETAIL where tglambil " +
                "between CONVERT(datetime, '" + _servertime + " 00:00:00', 121) and CONVERT(datetime, '" + _servertime +
                " 23:59:59', 121)";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                conn.Close();
                return 0;
            }
            if (reader.HasRows)
            {
                reader.Read();
                int noambil = Convert.ToInt16(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
                reader.Close();
                return noambil;
            }
            conn.Close();
            return 1;
        }

        private string GetServerTime()
        {
            _strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);

                return null;
            }
            _strQuerySql = "select convert(VARCHAR(10), GETDATE(), 120)";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                conn.Close();
                return null;
            }
            if (reader.HasRows)
            {
                reader.Read();
                string servertime = _modMain.pbstrgetCol(reader, 0, ref _strErr, "");
                reader.Close();
                return servertime;
            }
            conn.Close();
            return null;
        }

        private void btnSimpanJasPel_Click(object sender, EventArgs e)
        {
            if (_grpJasaPelayanan.Count < 1 & !bgCariDataJaspel.IsBusy)
            {
                MessageBox.Show(@"PILIH DOKTER YG MEMILIKI JASA PELAYANAN");
                txtNamaDokter.Text = "";
                txtNamaDokter.Focus();
                return;
            }

            if (bgCariDataJaspel.IsBusy)
            {
                MessageBox.Show(@"MASIH ADA PROSES PENCARIAN");
                return;
            }

            if (_bw1.IsBusy)
            {
                MessageBox.Show(@"MASIH ADA PROSES PENYIMPANAN");
                return;
            }

            if (_isInEditMode |_grpJasaPelayanan.Count > 1)
            {
                if (_isEntryPajak)
                {
                    _bw1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show(@"Silahkan Hitung Pajak/Potongan");
                    tabControl1.SafeControlInvoke(tabcontrol => tabControl1.SelectedTab = tabPage2);
                }
            }
        }

        private bool SaveJazzPelll()
        {
            _strErr = "";
            int noAmbil = GetMaxNoAmbil() + 1;
            _strQuerySql = "UPDATE BILLING..BL_TRANSAKSIDETAIL set noambil  = " + noAmbil + ", " +
                           "tglambil = getdate() where batal = '' " +
                           "and idmr_dokter = '" + lblKodeDokter.Text + "' and idbl_pembayaran > 0 and noambil = 0 ";

           
            string strQueryPajak = "insert into tr_pav_pajak values ('" + lblKodeDokter.Text + "', " +
                _bruto + ", " + _biayaAdm + ", " + _pphGlobal + ", getdate(),"+ (_bruto - (Convert.ToDecimal(_biayaAdm) + _pphGlobal)) +")";
         
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return false;
            }

            SqlTransaction trans = conn.BeginTransaction();
            _modDb.pbWriteSQLTrans(conn, _strQuerySql, ref _strErr, trans);
            _modDb.pbWriteSQLTrans(conn, strQueryPajak, ref _strErr, trans);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                trans.Rollback();
                conn.Close();
                return false;
            }
            trans.Commit();
            conn.Close();

            return true;
        }

        private void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!SaveJazzPelll())
                MessageBox.Show(@"TRANSAKSI GAGAL");
        }

        private void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Error != null ? String.Format("Error : {0}", e.Error.Message) : "TRANSAKSI SUKSES");
            Bersih2();
            _isInEditMode = false;
            _pphGlobal = 0;
        }

        private void bw2_DoWork(object sender, DoWorkEventArgs e)
        {
            
            _kwitansis.Clear();
            string namadokter = "";
            string npwp = "";

            var nama =
                (from s in _grpSemuaDokter
                    where s.StrKodeDokter.ToUpper() == lblKodeDokter.Text.ToUpper()
                    select s);
            foreach (var lstDaftarDokters in nama)
            {
                namadokter = lstDaftarDokters.StrNamaDokter;
                npwp = lstDaftarDokters.Npwp;
            }
          
            _kwitansis.Add(new KwitansiDokter(_bruto, lblKodeDokter.Text, (decimal)_biayaAdm, namadokter, 
                (_bruto - (Convert.ToDecimal(_biayaAdm) + _pphGlobal)), npwp, _pphGlobal, 
                _modMain.psTerbilang((double)_bruto), DateTime.Now));
           
        }

        private void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PvTampilLaporanKwi();

        } 

        #endregion

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isInEditMode | _grpJasaPelayanan.Count < 1 | _bw1.IsBusy)
                e.Cancel = true;
            else
                CekIsentryPajak();
        }

        private void CekIsentryPajak()
        {
            if ((string.IsNullOrEmpty(txtNilaiProsentase.Text.Trim()) & cbKetenagaan.SelectedIndex < 1) | _pphGlobal < 1)
            {
                _isEntryPajak = false;
            }
            else
            {
                _isEntryPajak = true;
            }
        }

        private bool _isEntryPajak;

        private void bgCariDataJaspel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PvTampilList();
            PvTampilLaporan();
        }

        private void btnKeluarJasPel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kwi_viewer_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("id-ID");
        }

        private void pvReportBuktiPajak() {

            _BuktiPajak.Clear();
            string alamat = "";
            string npwp = "";
            string namaDokter= "";

            var nama =
                (from s in _grpSemuaDokter
                 where s.StrKodeDokter.ToUpper() == lblKodeDokter.Text.ToUpper()
                 select s);

            foreach (var lstDaftarDokters in nama)
            {
                alamat = lstDaftarDokters.Alamat;
                npwp = lstDaftarDokters.Npwp;
                namaDokter = lstDaftarDokters.StrNamaDokter;
            }



            _BuktiPajak.Add(new LstBuktiPajak(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", _bruto), 
                                                namaDokter,                                
                                                npwp,
                                                string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", _pphGlobal),
                                                DateTime.Now,
                                                alamat));
            PvTampilLaporanBuktiPajak();
        }      

        private void bgLaodDokter_DoWork(object sender, DoWorkEventArgs e)
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
                    _listDokter.Add(_modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + _modMain.pbstrgetCol(reader, 1, ref strErr, ""));
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
    }
}
