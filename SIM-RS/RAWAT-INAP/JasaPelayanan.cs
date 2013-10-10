using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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
/*
        C4Module.SQLModule _modSql = new C4Module.SQLModule();
        C4Module.EncryptModule _modEncrypt = new C4Module.EncryptModule();
*/
        readonly BackgroundWorker _bw = new BackgroundWorker();

        string _strErr = "";
        string _strQuerySql = "";

        /*List - List yang dipakai*/
        #region tak ubah sesuai ketentuan berlaku
        public class LstDaftarDokter // tak ubah sesuai ketentuan berlaku
        {
            private readonly string _strKodeDokter;
            private readonly string _strNamaDokter;
            private readonly string _strSmf;

            public LstDaftarDokter(string strKodeDokter, string strNamaDokter, string strSmf)
            {
                _strKodeDokter = strKodeDokter;
                _strNamaDokter = strNamaDokter;
                _strSmf = strSmf;
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
            
        }

        public class LstDaftarJasaPelayanan // tak ubah sesuai ketentuan berlaku
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
            readonly string _strKodeTransaksi;

             public LstDaftarJasaPelayanan(string strNoBilling, string strNamaPasien, string strStatusPasien, 
                string strTglPulang, string strNamaTarif, double dblJasaMedis, double dblKeringanan, double dblHslBersih,                
                string strKodeDokter, string strKodeTransaksi)
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

            public string StrNoBilling
            {
                get { return _strNoBilling; }
            }
        }
        #endregion
        readonly List<LstDaftarJasaPelayanan> _grpJasaPelayanan = new List<LstDaftarJasaPelayanan>();
        readonly List<LstDaftarDokter> _grpSemuaDokter = new List<LstDaftarDokter>();

        /*Daftar Autocomplete*/
        readonly AutoCompleteStringCollection _listDokter = new AutoCompleteStringCollection();


        public JasaPelayanan()
        {
            InitializeComponent();
            LoadDataDokter();

            _bw.WorkerSupportsCancellation = true;
            _bw.WorkerReportsProgress = true;
            _bw.DoWork +=
                bw_DoWork;
            _bw.RunWorkerCompleted +=
                bw_RunWorkerCompleted;
        }

        public void LoadDataDokter() {
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
                                       "MR_DOKTER.idmr_tsmf " +                    //2
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
                        _modMain.pbstrgetCol(reader, 1, ref strErr, ""), _modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                }
            }

            reader.Close();

            txtNamaDokter.AutoCompleteCustomSource = _listDokter;
            txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            string strKodeNama = txtNamaDokter.Text.Trim();

            String[] strArrPart = Regex.Split(strKodeNama, "--");

            string strKode = strArrPart[0].Trim();

            lblKodeDokter.Text = strArrPart[0].Trim();

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
                    "BL_TRANSAKSI.idbl_transaksi " +                                    //10
                    "FROM BL_TRANSAKSI  With (nolock) " +
                    "INNER JOIN BL_KASPAV ON BL_TRANSAKSI.idmr_mutasipasien = BL_KASPAV.Idmr_mutasipasien " +
                    "INNER JOIN BL_TRANSAKSIDETAIL ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.idbl_transaksi " +
                    "INNER JOIN MR_PASIEN ON BL_KASPAV.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                    "INNER JOIN MR_DOKTER ON BL_TRANSAKSIDETAIL.idmr_dokter = MR_DOKTER.idmr_dokter " +
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
                        _modMain.pbstrgetCol(reader, 10, ref strErr, "")
                        ));
                }

            }
            else
            {
                MessageBox.Show(@"No Register Billing tidak ditemukan ", @"Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isInEditMode = false;
                Bersih2();
            }

            lblInfoPencarian.SafeControlInvoke(label => lblInfoPencarian.Visible = false);
            reader.Close();
            PvTampilList();
            btnBatalJasPel.SafeControlInvoke(button => btnBatalJasPel.Enabled = true);
        }

        private void Bersih2()
        {
            txtNamaDokter.SafeControlInvoke(textBox =>
            {
                txtNamaDokter.Enabled = true;
                txtNamaDokter.Focus();
            });
            txtNamaDokter.SafeControlInvoke(textBox => txtNamaDokter.Text = "");
            lvJasaPelayanan.SafeControlInvoke(listview => lvJasaPelayanan.Items.Clear());
            _isInEditMode = false;
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
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNoBilling));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNamaPasien));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrStatusPasien));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrTglPulang));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNamaTarif));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel.DblJasaMedis)));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel.DblKeringanan)));
                lvJasaPelayanan.SafeControlInvoke(listView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", jaspel.DblHslBersih)));
                noUrut++;
            }

            var suma = (from s in _grpJasaPelayanan select s.DblHslBersih).Sum();
            lblTotalJasaPelayanan.SafeControlInvoke(label => lblTotalJasaPelayanan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", suma));
            lblJmlJaspel.SafeControlInvoke(label => lblJmlJaspel.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", suma));
            Double biayaAdm = 0.1 * Convert.ToDouble(suma);
            lblJmlJaspelAsli.Text = "" + Convert.ToDouble(suma);
            lblJasaAdministrasi.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", biayaAdm);
            lblJasaAdministrasiAsli.Text = "" + biayaAdm;
            cbKetenagaan.Text = @"Tenaga Ahli";
            cbKetenagaan.Focus();
        }


        private void JasaPelayanan_Load(object sender, EventArgs e)
        {
            _servertime = GetServerTime();
        }

        private void btnBatalJasPel_Click(object sender, EventArgs e)
        {

        }

        private string _servertime;

        private void txtNilaiProsentase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Double pajakAhli = (Convert.ToDouble(txtNilaiProsentase.Text) / 100) * (Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.5);
                lblPPhAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", pajakAhli);
                lblPPhAhliAsli.Text = "" + pajakAhli;
                Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                                            - pajakAhli;
                lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
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
            }
            else
            {
                txtNilaiProsentase.Text = "";
                txtNilaiProsentase.Enabled = false;
                lblPPhAhli.Text = "";
                lblPPhAhliAsli.Text = "";

                Double pajakNonAhli = Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.05;
                lblPPhNonAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", pajakNonAhli);
                lblPPhNonAhliAsli.Text = "" + pajakNonAhli;
                Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                            - pajakNonAhli;
                lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
            }
        }

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
                    Double pajakNonAhli = Convert.ToDouble(lblJmlJaspelAsli.Text) * 0.05;
                    lblPPhNonAhli.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", pajakNonAhli);
                    lblPPhNonAhliAsli.Text = "" + pajakNonAhli;
                    Double totalPenerimaan = Convert.ToDouble(lblJmlJaspelAsli.Text) - Convert.ToDouble(lblJasaAdministrasiAsli.Text)
                           - pajakNonAhli;
                    lblTotalPenerimaan.Text = string.Format(new CultureInfo("id-ID"), "Rp. {0:n}", totalPenerimaan);
                }
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
            if (_isInEditMode |_grpJasaPelayanan.Count > 1)
            {
                if (!_bw.IsBusy)
                    _bw.RunWorkerAsync();
                MessageBox.Show(_grpJasaPelayanan.Count.ToString());
            }
        }

        private bool SaveJazzPelll()
        {
            _strErr = "";
            int noAmbil = GetMaxNoAmbil() + 1;
            _strQuerySql = "UPDATE BILLING..BL_TRANSAKSIDETAIL set noambil  = " + noAmbil + ", " +
                           "tglambil = getdate() where batal = '' " +
                           "and idmr_dokter = '" + lblKodeDokter.Text + "' and idbl_pembayaran > 0 and noambil = 0 ";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return false;
            }
            SqlTransaction trans = conn.BeginTransaction();
            _modDb.pbWriteSQLTrans(conn, _strQuerySql, ref _strErr, trans);
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!SaveJazzPelll())
                MessageBox.Show(@"TRANSAKSI GAGAL");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Error != null ? String.Format("Error : {0}", e.Error.Message) : "TRANSAKSI SUKSES");
            Bersih2();
            _isInEditMode = false;
        } 
        #endregion

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

    }
}
