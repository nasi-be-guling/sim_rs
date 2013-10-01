using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using SIM_RS.Properties;

namespace SIM_RS.ADMIN
{
    public partial class DaftarHakAkses : Form
    {

        string _strErr = "";
        string _strQuerySql = "";

        readonly C4Module.MainModule _modMain = new C4Module.MainModule();
        readonly C4Module.DatabaseModule _modDb = new C4Module.DatabaseModule();
        readonly C4Module.MessageModule _modMsg = new C4Module.MessageModule();
        readonly C4Module.SQLModule _modSql = new C4Module.SQLModule();
        //C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();
        readonly BackgroundWorker _bw = new BackgroundWorker();

        readonly AutoCompleteStringCollection _listProgram = new AutoCompleteStringCollection();
        readonly AutoCompleteStringCollection _listPengguna = new AutoCompleteStringCollection();

        public DaftarHakAkses()
        {
            InitializeComponent();
            _bw.WorkerSupportsCancellation = true;
            _bw.WorkerReportsProgress = true;
            _bw.DoWork +=
                bw_DoWork;
            //bw.ProgressChanged +=
            //    new ProgressChangedEventHandler(bw_ProgressChanged);
            _bw.RunWorkerCompleted +=
                bw_RunWorkerCompleted;

            // ============================ URUTKAN INDEKS DARI BOS MASTER EKA NDUT =================================
            int intNoIdx = 0;
            _modMain.pvUrutkanTab(lblTempatLayanan, ref intNoIdx);
            _modMain.pvUrutkanTab(txtNamaMenu, ref intNoIdx);
            _modMain.pvUrutkanTab(label1, ref intNoIdx, true);
            _modMain.pvUrutkanTab(txtNamaAppLama, ref intNoIdx, true);
            _modMain.pvUrutkanTab(label2, ref intNoIdx, true);
            _modMain.pvUrutkanTab(txtKelompok, ref intNoIdx, true);
            _modMain.pvUrutkanTab(cmbStatusID, ref intNoIdx, true);
            _modMain.pvUrutkanTab(txtCariMenu, ref intNoIdx, true);
            _modMain.pvUrutkanTab(btnCariMenu, ref intNoIdx, true);
            _modMain.pvUrutkanTab(btnSimpan, ref intNoIdx, true);
            _modMain.pvUrutkanTab(btnBatal, ref intNoIdx, true);
        }

        private int Idpetugas { get; set; }

        private int Idprogram { get; set; }

        /* PRIVATE FUNCTION */

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            FillAutoComplete();
            //for (int i = 1; (i <= 10); i++)
            //{
            //    if ((worker.CancellationPending == true))
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        System.Threading.Thread.Sleep(500);
            //        worker.ReportProgress((i * 10));
            //    }
            //}
        }

        //private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
        //}

        private class Pengguna
        {
            //http://stackoverflow.com/questions/7905651/how-to-databind-a-textbox-to-a-particular-index-in-a-list

            public Pengguna(string id, string nama)
            {
                Id = id;
                Nama = nama;
            }

            public string Nama { get; private set; }

            public string Id { get; private set; }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Error : {0}", e.Error.Message));
            }
            else
            {
                txtNamaAppLama.AutoCompleteCustomSource = _listProgram;
                txtNamaAppLama.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNamaAppLama.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtNamaMenu.AutoCompleteCustomSource = _listPengguna;
                txtNamaMenu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNamaMenu.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtNamaMenu.Enabled = true;
                txtNamaAppLama.Enabled = true;
            }
        }

        private void FillAutoComplete()
        {
            _strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            //=======================================  SELECT PROGRAM ===================================
            _strQuerySql = "SELECT id, nama " +
                                "FROM HIS_DAFTAR_MENU";

            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listProgram.Add(new Pengguna(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""), 
                        _modMain.pbstrgetCol(reader, 1, ref _strErr, "")));
                    _listProgram.Add(_modMain.pbstrgetCol(reader, 1, ref _strErr, ""));
                }
                reader.Close();
            }

            //=======================================  SELECT PENGGUNA ===================================
            _strQuerySql = "SELECT id, nama " +
                                "FROM HIS_DAFTAR_USER";
            reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listPengguna.Add(new Pengguna(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""), 
                        _modMain.pbstrgetCol(reader, 1, ref _strErr, "")));
                    _listPengguna.Add(_modMain.pbstrgetCol(reader, 1, ref _strErr, ""));
                }
                reader.Close();
            }
            conn.Close();
        }

        private void PvLoadData(string strCari = "", int kontrol = 0)
        {

            _strErr = "";


            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }
            #region SQL QUERY SESUAI KONDISI
            switch (kontrol)
            {
                case 0:
                    _strQuerySql = "SELECT nama " +
                                   "FROM HIS_DAFTAR_MENU";
                    break;
                case 2:
                    _strQuerySql = strCari == ""
                        ? "SELECT A.user_id, A.nama, A.nip_nbi, B.nama " +
                          "FROM HIS_DAFTAR_USER A inner join HIS_DAFTAR_UNITKERJA B ON B.id = A.id_unitkerja"
                        : "SELECT A.user_id, A.nama, A.nip_nbi, B.nama " +
                          "FROM HIS_DAFTAR_USER A inner join HIS_DAFTAR_UNITKERJA B ON B.id = A.id_unitkerja " +
                          "WHERE A.user_id LIKE '%" + strCari +
                          "%' OR A.nama LIKE '%" + strCari + "%'";
                    break;
                case 3:
                    _strQuerySql = strCari == ""
                        ? "SELECT idprogram, nama " +
                          "FROM HIS_DAFTAR_MENU"
                        : "SELECT id, nama " +
                          "FROM HIS_DAFTAR_MENU WHERE nama LIKE '%" + strCari + "%'";
                    break;
                case 4:
                    _strQuerySql = strCari == ""
                        ? "SELECT A.no_urut,C.nama,B.nama " +
                            "FROM " +
                            "dbo.HIS_DAFTAR_HAKAKSES AS A INNER JOIN dbo.HIS_DAFTAR_MENU AS B ON B.id = A.id_menu " +
                            "INNER JOIN dbo.HIS_DAFTAR_USER AS C ON C.id = A.id_user"
                        : "SELECT A.no_urut,C.nama,B.nama " +
                            "FROM " +
                            "dbo.HIS_DAFTAR_HAKAKSES AS A INNER JOIN dbo.HIS_DAFTAR_MENU AS B ON B.id = A.id_menu " +
                            "INNER JOIN dbo.HIS_DAFTAR_USER AS C ON C.id = A.id_user " +
                            "WHERE C.id = " + strCari + "";
                    break;
            } 
            
            #endregion
            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                lvDaftarMenu.Items.Clear();
                while (reader.Read())
                {
                    if (kontrol == 0)
                    {
                        _listProgram.Add(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
                    }
                    else if (kontrol > 0)
                    {
                        lvDaftarMenu.Items.Add(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
                        lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                            _modMain.pbstrgetCol(reader, 1, ref _strErr, ""));

                        lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                            _modMain.pbstrgetCol(reader, 2, ref _strErr, ""));
                        lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                            _modMain.pbstrgetCol(reader, 3, ref _strErr, ""));
                    }
                }
                //_modSql.pvAutoResizeLV(lvDaftarMenu, 3);
                reader.Close();
            }
            conn.Close();
        }

        private int GetMaxNoUrut(int idPetugas)
        {
            _strErr = "";
            int maxNoUrut = 0;

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);

                return 0;
            }
            /*FIRST get last nomor urut*/
            _strQuerySql = "SELECT Max(A.no_urut) FROM dbo.HIS_DAFTAR_HAKAKSES AS A " +
                "INNER JOIN dbo.HIS_DAFTAR_MENU AS B ON B.id = A.id_menu " +
                "INNER JOIN dbo.HIS_DAFTAR_USER AS C ON C.id = A.id_user " +
                "WHERE C.id = " + idPetugas + "";
            SqlDataReader reader = _modDb.pbreaderSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return 0;
            }

            if (reader.HasRows)
            {
                reader.Read();
                maxNoUrut = Convert.ToInt16(_modMain.pbstrgetCol(reader, 0, ref _strErr, "")) + 1;
            }
            reader.Close();
            conn.Close();
            return maxNoUrut;
        }

        private bool Cekifalreadyhasornot(SqlConnection conn, int idPetugas, int idProgram, SqlTransaction trans)
        /*
        *  NAME        : cekifalreadyhasornot
        *  FUNCTION    : Checking if user already had the menu or not
        *  RESULT      : bool
        *  CREATED     : Putu (nasi.be.guling@gmail.com)
        *  DATE        : 10-01-2013
        */
        {
            _strErr = "";
            _strQuerySql = "SELECT A.id " +
                           "FROM BILLING_NEW.dbo.HIS_DAFTAR_HAKAKSES A " +
                           "WHERE A.id_user = " + idPetugas + " AND A.id_menu = " + idProgram + "";
            SqlDataReader reader = _modDb.pbreaderSQLTrans(conn, _strQuerySql, ref _strErr, trans);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_GET, _modMsg.TITLE_ERR);
                trans.Rollback();
                conn.Close();
                return true;
            }
            if (reader.HasRows)
            {      
                return true;
            }
            reader.Close();
            return false;
        }

        private bool PvSimpanData()
        {
            _strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);

                return false;
            }
            SqlTransaction trans = conn.BeginTransaction();           
            //if (!isUpdate)
            //    this.strQuerySQL = "INSERT INTO BILHAKAKSES (idpetugas,idprogram,grup,urut) " +
            //                        "VALUES ('" + modMain.pbstrBersihkanInput(.Text.Trim().ToString()) +
            //                        "','" + modMain.pbstrBersihkanInput(txtKelompok.Text.Trim().ToString()) +
            //                        "','" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
            //                        "')";
            //else
            //    /* JIKA BUKAN MENU DARI APLIKASI LAMA MAKA BISA MENGUPDATE JUGA NAMA MENU DAN NAMA FORM */
            //    if (txtNamaAppLama.Text.Trim().ToString() == "")
            //        this.strQuerySQL = "UPDATE BILPROGRAM " +
            //                            "SET idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) +
            //                            "', NamaFormERD = '" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
            //                            "' WHERE idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) + "'";
            //    else
            //        this.strQuerySQL = "UPDATE BILPROGRAM " +
            //                            "SET NamaFormERD = '" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
            //                            "' WHERE idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) + "'";

            if (Cekifalreadyhasornot(conn, Idpetugas, Idprogram, trans))
            {
                MessageBox.Show(Resources.DaftarHakAkses_PvSimpanData_, 
                    Resources.daftarHakAkses_txtNamaMenu_Leave_PERHATIAN);
                return false;
            }

            _strQuerySql = "INSERT INTO BILLING_NEW.dbo.HIS_DAFTAR_HAKAKSES VALUES (" +
                Idpetugas + ", " + Idprogram + ", " + GetMaxNoUrut(Idpetugas) + ", 1)";

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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void daftarHakAkses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }

        private void btnCariMenu_Click(object sender, EventArgs e)
        {
            Pencarian();
        }

        private void daftarHakAkses_Load(object sender, EventArgs e)
        {
            _listProgram.Clear();
            if (!_bw.IsBusy)
            {
                txtNamaMenu.Enabled = false;
                txtNamaAppLama.Enabled = false;
                _bw.RunWorkerAsync();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaMenu.Text.Trim()) | string.IsNullOrEmpty(txtNamaAppLama.Text.Trim()) 
                | Idpetugas == 0 | Idprogram == 0)
            {
                MessageBox.Show(Resources.DaftarHakAkses_btnSimpan_Click_SILAHKAN_LENGKAPI_DATA, 
                    Resources.daftarHakAkses_txtNamaMenu_Leave_PERHATIAN);
            }
            else
            {
                if (!PvSimpanData())
                    MessageBox.Show(Resources.DaftarHakAkses_btnSimpan_Click_,
                        Resources.daftarHakAkses_txtNamaMenu_Leave_PERHATIAN);
                else
                {
                    PvLoadData(Idpetugas.ToString(CultureInfo.InvariantCulture), 4);
                    InisiasiListView(2);
                }
            }
        }

        private void txtCariMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Pencarian();
            }
        }

        private
            void Pencarian()
        {
            switch (cmbStatusID.SelectedIndex)
            {
                case 0:
                    PvLoadData(txtCariMenu.Text, 2);
                    InisiasiListView(0);
                    break;
                case 1:
                    PvLoadData(txtCariMenu.Text, 3);
                    InisiasiListView(1);
                    break;
                default:
                    MessageBox.Show(Resources.daftarHakAkses_Pencarian_Pilih_Kriteria);
                    break;
            }
        }

        private void InisiasiListView(int statustampil)
        {
            lvDaftarMenu.Columns.Clear();
            if (statustampil == 0)
            {
                // ============================= Select Pengguna ===========================================
                // Set the view to show details
                //lvDaftarMenu.View = View.Details;
                //// Disallow the user from edit the item
                ////lvTampil.LabelEdit = false;
                //// Allow the user to rearrange columns
                //lvDaftarMenu.AllowColumnReorder = true;
                //// Select the item and subitems when selection is made
                //lvDaftarMenu.FullRowSelect = true;
                //// Display the gridline
                //lvDaftarMenu.GridLines = true;
                //// Sort the items in the list in accending order
                //lvDaftarMenu.Sorting = System.Windows.Forms.SortOrder.Ascending;
                //// Restrict the multiselect
                //lvDaftarMenu.MultiSelect = false;
                lvDaftarMenu.Columns.Add("ID Petugas",
                    10*Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Petugas",
                    10*Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("NBI/NIP",
                    10*Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Unit Kerja",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular | FontStyle.Regular);
                _modSql.pvAutoResizeLV(lvDaftarMenu, 3);
            }
            else if (statustampil == 1)
            {
                // ============================= Select Program ===========================================
                lvDaftarMenu.Columns.Add("ID Program",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Nama Form",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular | FontStyle.Regular);
                _modSql.pvAutoResizeLV(lvDaftarMenu, 2);
            }
            else if (statustampil == 2)
            {
                // ============================= Select Hak Akses ===========================================
                lvDaftarMenu.Columns.Add("No.",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Nama Petugas",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Nama Form",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular | FontStyle.Regular);
                _modSql.pvAutoResizeLV(lvDaftarMenu, 3);
            }
        }
        #region MENCARI ID
        /*
        *  NAME        : Getidpengguna, Getidprogram
        *  FUNCTION    : Get table id from currently selected string
        *  RESULT      : int
        *  CREATED     : Putu (nasi.be.guling@gmail.com)
        *  DATE        : 09-30-2013
        */
        private int Getidpengguna(string strcari)
        {
            int id = 0;
            IEnumerable<Pengguna> bla = (from s in listPengguna where s.Nama.ToUpper() == strcari.ToUpper() select s);

            foreach (var pengguna in bla)
            {
                id = Convert.ToInt16(pengguna.Id);
            }
            return id;
        }

        private int Getidprogram(string strcari)
        {
            int id = 0;
            IEnumerable<Pengguna> bla = (from s in listProgram where s.Nama.ToUpper() == strcari.ToUpper() select s);

            foreach (var pengguna in bla)
            {
                id = Convert.ToInt16(pengguna.Id);
            }
            return id;
        }
        #endregion
        private void lvDaftarMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lvDaftarMenu, e.Location);
            }
        }

        private void txtNamaMenu_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNamaMenu.Text))
            {
                int id = Getidpengguna(txtNamaMenu.Text);
                if (id == 0)
                    MessageBox.Show(Resources.daftarHakAkses_txtNamaMenu_Leave_PETUGAS_TIDAK_DITEMUKAN,
                        Resources.daftarHakAkses_txtNamaMenu_Leave_PERHATIAN);
                else
                {
                    Idpetugas = id;
                    PvLoadData(Idpetugas.ToString(CultureInfo.InvariantCulture), 4);
                    InisiasiListView(2);
                }
            }
        }

        private void txtNamaAppLama_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNamaAppLama.Text))
            {
                int id = Getidprogram(txtNamaAppLama.Text);
                if (id == 0)
                    MessageBox.Show(Resources.daftarHakAkses_txtNamaAppLama_Leave_PROGRAM_TIDAK_DITEMUKAN, 
                        Resources.daftarHakAkses_txtNamaMenu_Leave_PERHATIAN);
                else
                    Idprogram = id;
            }
        }

        private void txtNamaMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (Idpetugas > 0)
                {
                    PvLoadData(Idpetugas.ToString(CultureInfo.InvariantCulture), 4);
                    InisiasiListView(2);
                }
            }
        }

        /* EOF PRIVATE FUNCTION */


    }
}
