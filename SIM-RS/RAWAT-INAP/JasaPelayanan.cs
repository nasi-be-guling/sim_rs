using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SIM_RS.RAWAT_INAP
{
    public partial class JasaPelayanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();
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

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {                
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            String strQuerySQL = "SELECT " +
                                 "MR_DOKTER.idmr_dokter, " +                 //0
                                 "MR_DOKTER.nama, " +                        //1
                                 "MR_DOKTER.idmr_tsmf " +                    //2
                                 "FROM MR_DOKTER WITH (NOLOCK) " +
                                 "WHERE MR_DOKTER.dipakai = 'Y'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _listDokter.Clear();
            _grpSemuaDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _listDokter.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    //LstDaftarDokter itemDaftarDokter = new LstDaftarDokter();
                    //itemDaftarDokter.StrKodeDokter = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    //itemDaftarDokter.StrNamaDokter = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    //itemDaftarDokter.StrSmf = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    //_grpSemuaDokter.Add(itemDaftarDokter);
                    _grpSemuaDokter.Add(new LstDaftarDokter(modMain.pbstrgetCol(reader, 0, ref strErr, ""), 
                        modMain.pbstrgetCol(reader, 1, ref strErr, ""), modMain.pbstrgetCol(reader, 2, ref strErr, "")));
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
                this.bgCariDataJaspel.RunWorkerAsync();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }     
        }

        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            string strKodeNama = txtNamaDokter.Text.Trim().ToString();

            String[] strArrPart = Regex.Split(strKodeNama, "--");

            string strKode = strArrPart[0].Trim().ToString();

            lblKodeDokter.Text = strArrPart[0].Trim().ToString();

            int intResultSearch = _grpSemuaDokter.FindIndex(
                                    m => m.StrKodeDokter == strKode);

            if (intResultSearch == -1)
            {
                MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                txtNamaDokter.Focus();

            }
            else
            {
                //btnTambahKompDokter.Focus();

            }
        }

        private void bgCariDataJaspel_DoWork(object sender, DoWorkEventArgs e)
        {

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.Enabled = false);
            btnBatalJasPel.SafeControlInvoke(Button => btnBatalJasPel.Enabled = false);
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "MENCARI JASA PELAYANAN");
            String strQuerySQL =
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

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            _grpJasaPelayanan.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    //LstDaftarJasaPelayanan itemJasaLayanan = new LstDaftarJasaPelayanan();
                    //itemJasaLayanan.StrNoBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    //itemJasaLayanan.StrNamaPasien = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    //itemJasaLayanan.StrStatusPasien = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    //itemJasaLayanan.StrTglPulang = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    //itemJasaLayanan.StrNamaTarif = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                    //itemJasaLayanan.DblJasaMedis = Convert.ToDouble(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    //itemJasaLayanan.DblKeringanan = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    //itemJasaLayanan.DblHslBersih = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    //itemJasaLayanan.StrKodeDokter = modMain.pbstrgetCol(reader, 9, ref strErr, "");
                    //itemJasaLayanan.StrKodeTransaksi = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                    //grpJasaPelayanan.Add(itemJasaLayanan);
                    _grpJasaPelayanan.Add(new LstDaftarJasaPelayanan(modMain.pbstrgetCol(reader, 0, ref strErr, ""),
                        modMain.pbstrgetCol(reader, 1, ref strErr, ""), modMain.pbstrgetCol(reader, 2, ref strErr, ""),
                        modMain.pbstrgetCol(reader, 3, ref strErr, ""), modMain.pbstrgetCol(reader, 4, ref strErr, ""),
                        Convert.ToDouble(modMain.pbstrgetCol(reader, 6, ref strErr, "")), Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, "")),
                        Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, "")), modMain.pbstrgetCol(reader, 9, ref strErr, ""),
                        modMain.pbstrgetCol(reader, 10, ref strErr, "")
                        ));
                }

            }
            else
            {
                
                txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.Enabled = true);
                txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.Text = "");
                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            reader.Close();
            pvTampilList();
            btnBatalJasPel.SafeControlInvoke(Button => btnBatalJasPel.Enabled = true);
        }

        private void pvTampilList()
        {
            int noUrut = 1;
            var query = (from i in _grpJasaPelayanan
                         select i);

            lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items.Clear());
            foreach (var jaspel in query)
            {
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items.Add(noUrut.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNoBilling));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNamaPasien));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrStatusPasien));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrTglPulang));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.StrNamaTarif));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.DblJasaMedis.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.DblKeringanan.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.DblHslBersih.ToString()));
                noUrut++;
            }

            var suma = (from s in _grpJasaPelayanan select s.DblHslBersih).Sum();
            lblTotalJasaPelayanan.SafeControlInvoke(label => lblTotalJasaPelayanan.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp. {0:n}", suma));
            lblJmlJaspel.SafeControlInvoke(label => lblJmlJaspel.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp. {0:n}", suma));
        }


        private void JasaPelayanan_Load(object sender, EventArgs e)
        {
            _servertime = GetServerTime();
        }

        private void btnBatalJasPel_Click(object sender, EventArgs e)
        {

        }

        private string _servertime;

        private int GetMaxNoAmbil()
        {
            _strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_CON, modMsg.TITLE_ERR);

                return 0;
            }
            _strQuerySql = "select MAX(noambil) from BILLING..BL_TRANSAKSIDETAIL where tglambil " +
                "between CONVERT(datetime, '" + _servertime + " 00:00:00', 121) and CONVERT(datetime, '" + _servertime + 
                " 23:59:59', 121)";

            SqlDataReader reader = modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return 0;
            }
            if (reader.HasRows)
            {
                reader.Read();
                int noambil = Convert.ToInt16(modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
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

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_CON, modMsg.TITLE_ERR);

                return null;
            }
            _strQuerySql = "select convert(VARCHAR(10), GETDATE(), 120)";
            
            SqlDataReader reader = modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return null;
            }
            if (reader.HasRows)
            {
                reader.Read();
                string servertime = modMain.pbstrgetCol(reader, 0, ref _strErr, "");
                reader.Close();
                return servertime;
            }            
            conn.Close();
            return null;
        }

        private void btnSimpanJasPel_Click(object sender, EventArgs e)
        {
            _bw.RunWorkerAsync();
        }

        private bool SaveJazzPelll()
        {
            _strErr = "";
            int noAmbil = GetMaxNoAmbil() + 1;
            _strQuerySql = "UPDATE BILLING..BL_TRANSAKSIDETAIL set noambil  = " + noAmbil + ", " +
                           "tglambil = getdate() where batal = '' " +
                           "and idmr_dokter = '" + lblKodeDokter.Text + "' and idbl_pembayaran > 0 and noambil = 0 ";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            SqlConnection conn = modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return false;
            }
            SqlTransaction trans = conn.BeginTransaction();
            modDb.pbWriteSQLTrans(conn, _strQuerySql, ref _strErr, trans);
            if (_strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, _strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
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
                MessageBox.Show("TRANSAKSI GAGAL");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Error : {0}", e.Error.Message));
            }
            else
            {
                MessageBox.Show("TRANSAKSI SUKSES");
            }
        }

    }
}
