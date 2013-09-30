using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SIM_RS.Properties;

namespace SIM_RS.ADMIN
{
    public partial class daftarHakAkses : Form
    {

        string _strErr = "";
        string _strQuerySql = "";

        readonly C4Module.MainModule _modMain = new C4Module.MainModule();
        readonly C4Module.DatabaseModule _modDb = new C4Module.DatabaseModule();
        readonly C4Module.MessageModule _modMsg = new C4Module.MessageModule();
        readonly C4Module.SQLModule _modSql = new C4Module.SQLModule();
        //C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();
        BackgroundWorker bw = new BackgroundWorker();

        AutoCompleteStringCollection _listProgram = new AutoCompleteStringCollection();
        AutoCompleteStringCollection _listPengguna = new AutoCompleteStringCollection();

        public daftarHakAkses()
        {
            InitializeComponent();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
            //bw.ProgressChanged +=
            //    new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        /* PRIVATE FUNCTION */

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
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
            }
        }


        private void FillAutoComplete()
        {
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }
            //=======================================  SELECT PROGRAM ===================================
            _strQuerySql = "SELECT nama " +
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
                    _listProgram.Add(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
                }
                reader.Close();
            }
            //=======================================  SELECT PENGGUNA ===================================
            _strQuerySql = "SELECT nama " +
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
                    _listPengguna.Add(_modMain.pbstrgetCol(reader, 0, ref _strErr, ""));
                }
                reader.Close();
            }
            conn.Close();
        }

        private void PvLoadData(string strCari = "", int kontrol = 0)
        {
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                return;
            }

            #region SQL QUERY SESUAI KONDISI
            if (kontrol == 0)
            {
                _strQuerySql = "SELECT nama " +
                                "FROM HIS_DAFTAR_MENU";
            }
            else if (kontrol == 2)
            {
                if (strCari == "")

                    _strQuerySql = "SELECT user_id, nama, nip_nbi " +
                                   "FROM HIS_DAFTAR_USER";
                else
                    _strQuerySql = "SELECT user_id, nama, nip_nbi " +
                                   "FROM HIS_DAFTAR_USER WHERE nama LIKE '%" + strCari + "%'";
            }
            else if (kontrol == 3)
            {
                if (strCari == "")

                    _strQuerySql = "SELECT idprogram, namaform, kelompok " +
                                   "FROM BILPROGRAM";
                else
                    _strQuerySql = "SELECT idprogram, namaform, kelompok " +
                                   "FROM BILPROGRAM WHERE nama LIKE '%" + strCari + "%'";
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

        private bool PvSimpanData()
        {
            _strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = _modDb.pbconnKoneksiSQL(ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);

                return false;
            }

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


            _modDb.pbWriteSQL(conn, _strQuerySql, ref _strErr);
            if (_strErr != "")
            {
                _modMsg.pvDlgErr(_modMsg.IS_DEV, _strErr, _modMsg.DB_CON, _modMsg.TITLE_ERR);
                conn.Close();
                return false;
            }

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

        private void txtNamaMenu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    PvLoadData(txtNamaMenu.Text, 1);
        }

        private void daftarHakAkses_Load(object sender, EventArgs e)
        {
            _listProgram.Clear();
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

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

        private void cmbStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                lvDaftarMenu.Columns.Add("Unit Kerja",
                    10*Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular | FontStyle.Regular);
            }
            else
            {
                // ============================= Select Program ===========================================
                //// Set the view to show details
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

                lvDaftarMenu.Columns.Add("ID Program",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Nama Form",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Columns.Add("Kelompok",
                    10 * Convert.ToInt16(lvDaftarMenu.Font.SizeInPoints), HorizontalAlignment.Center);
                lvDaftarMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular | FontStyle.Regular);
            }
            _modSql.pvAutoResizeLV(lvDaftarMenu, 3);
        }

        private void txtCariMenu_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvDaftarMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this.lvDaftarMenu, e.Location);
            }
        }

        private void lvDaftarMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* EOF PRIVATE FUNCTION */


    }
}
