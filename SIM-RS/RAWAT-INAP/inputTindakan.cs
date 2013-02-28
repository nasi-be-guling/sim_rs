using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SIM_RS.RAWAT_INAP
{
    public partial class inputTindakan : Form
    {

        [DllImport("winspool.Drv",
                  EntryPoint = "GetDefaultPrinter")]
        public static extern bool GetDefaultPrinter(
                    StringBuilder pszBuffer,   // printer name buffer
                    ref int pcchBuffer  // size of name buffer
        );

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();


        string strQuerySQL = "";
        string strErr = "";


        /*VARIABLE INSERT TO BL_TRANSAKSI*/
        string strIdMutasiPasien = "";
        string strIdMR_TempatLayanan = "";
        string strIdMR_TRuangan = "";


        AutoCompleteStringCollection listTarif = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listTempatLayanan = new AutoCompleteStringCollection();

        public class lstDaftarTarif
        {

            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strSMF { get; set; }

        }
        public List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();

        public class lstDaftarKomponenTarif
        {
            public string strKodeTarif { get; set; }
            public string strId_Komponen { get; set; }
            public double dblByKomponen { get; set; }
            public double dblHak1 { get; set; }
            public double dblHak2 { get; set; }
            public double dblHak3 { get; set; }
            public int intPrioritasTunai {get; set;}

        }
        public List<lstDaftarKomponenTarif> grpLstDaftarKomponenTarif = new List<lstDaftarKomponenTarif>();

        public class lstDaftarTindakan
        {
            public int intNoUrut { get; set; }
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strTSMFTindakan { get; set; }
            public string strTempatLayanan { get; set; }
            public int intIdTempatLayanan { get; set; }
            public string strIdMRRuangan { get; set; }
        }
        List<lstDaftarTindakan> grpLstDaftarTindakan = new List<lstDaftarTindakan>();

        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
        }
        List<lstDaftarDokter> grpLstDaftarDokter = new List<lstDaftarDokter>();

        public class lstTempatLayanan
        {
            public string strKodeRuang { get; set; }
            public string strNamaRuang { get; set; }
        }
        List<lstTempatLayanan> grpLstTempatLayanan = new List<lstTempatLayanan>();


        /*  FUNCTION  */

        /*
        *  NAME        : pvLoadDataInisialasi
        *  FUNCTION    : Load data that need for this form on first time.
        *  RESULT      : -
        *  CREATED     : Eka Rudito (eka@rudito.web.id)
        *  DATE        : 19-02-2013    
        */

        private void pvLoadDataInisialasi()
        {
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            this.strQuerySQL = "SELECT "+
                                    "ruangan, "+
                                    "idmr_truangan "+
                                "FROM MR_TRUANGAN WITH (NOLOCK) "+
                                "WHERE dipakai = 'Y' and SUBSTRING(ruangan,1,1) <> '-' "+
                                "ORDER BY ruangan";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listTempatLayanan.Clear();
            grpLstTempatLayanan.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTempatLayanan.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));

                    lstTempatLayanan itemTempatLayanan = new lstTempatLayanan();
                    itemTempatLayanan.strKodeRuang = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemTempatLayanan.strNamaRuang = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    grpLstTempatLayanan.Add(itemTempatLayanan);
                }

            }


            reader.Close();

            txtTempatLayanan.AutoCompleteCustomSource = listTempatLayanan;
            txtTempatLayanan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTempatLayanan.AutoCompleteSource = AutoCompleteSource.CustomSource;


            strQuerySQL = "SELECT " +
                                "BL_TARIP.idbl_tarip, " +        //0
                                "BL_TARIP.uraiantarip, " +       //1
                                "BL_TARIP.idmr_tsmf, " +         //2
                                "BL_TARIP.nilai " +              //3
                           "FROM BL_TARIP WITH (NOLOCK) " +
                           "WHERE BL_TARIP.nilai > 0 " +
                                "AND BL_TARIP.dipakai = 'Y'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listTarif.Clear();
            grpLstDaftarTarif.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTarif.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    lstDaftarTarif itemDaftarTarif = new lstDaftarTarif();
                    itemDaftarTarif.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemDaftarTarif.strUraianTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemDaftarTarif.dblBiaya = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemDaftarTarif.strSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    grpLstDaftarTarif.Add(itemDaftarTarif);
                }
            }


            reader.Close();

            txtKodeTindakan.AutoCompleteCustomSource = listTarif;
            txtKodeTindakan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtKodeTindakan.AutoCompleteSource = AutoCompleteSource.CustomSource;


            this.strQuerySQL = "SELECT " +
                                "MR_DOKTER.idmr_dokter, " +           //0
                                "MR_DOKTER.nama " +                   //1
                               "FROM MR_DOKTER WITH (NOLOCK) " +
                               "WHERE MR_DOKTER.dipakai = 'Y'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listDokter.Clear();
            grpLstDaftarDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listDokter.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));

                    lstDaftarDokter itemDaftarDokter = new lstDaftarDokter();
                    itemDaftarDokter.strKodeDokter = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemDaftarDokter.strNamaDokter = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemDaftarDokter.strNamaDokter = itemDaftarDokter.strNamaDokter.Trim().ToString();

                    grpLstDaftarDokter.Add(itemDaftarDokter);
                }
            }

            

            reader.Close();

            txtNamaDokter.AutoCompleteCustomSource = listDokter;
            txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource;



            conn.Close();


            lblPetugas.Text = halamanUtama.strNamaUser;

        }


        /*
      *  NAME        : pvLoadDataPasien
      *  FUNCTION    : Load patient data from billing register
      *  RESULT      : -
      *  CREATED     : Eka Rudito (eka@rudito.web.id)
      *  DATE        : 19-02-2013    
      */

        private void pvLoadDataPasien(string _strNoTransBilling)
        {

            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            this.strQuerySQL = "SELECT " +
                                    "MR_PASIEN.nama, " +                        //0
                                    "MR_PASIEN.alamat, " +                      //1
                                    "MR_PASIEN.idmr_pasien, " +                 //2
                                    "MR_MUTASIPASIEN.idmr_mutasipasien, " +     //3
                                    "MR_TRUANGAN.ruangan, " +                   //4
                                    "MR_TEMPATLAYANAN.idmr_tempatlayanan, " +   //5
                                    "MR_TRUANGAN.idmr_jeniskelas, " +           //6
                                    "MR_MUTASIPASIEN.idmr_tstatus, " +          //7
                                    "MR_TRUANGAN.idmr_truangan, " +             //8
                                    "MR_MUTASIPASIEN.tanggal_mrs " +            //9
                               "FROM MR_PASIEN WITH (NOLOCK) " +
                               "INNER JOIN MR_MUTASIPASIEN " +
                                    "ON MR_PASIEN.idmr_pasien = MR_MUTASIPASIEN.idmr_pasien " +
                               "INNER JOIN MR_TEMPATLAYANAN " +
                                    "ON MR_MUTASIPASIEN.idmr_tempatlayanan = MR_TEMPATLAYANAN.idmr_tempatlayanan " +
                               "INNER JOIN MR_TRUANGAN " +
                                    "ON MR_TEMPATLAYANAN.idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                               "WHERE MR_MUTASIPASIEN.sistem = 'IRNA' " +
                                    "AND MR_MUTASIPASIEN.batal = '' " +
                                    "AND MR_MUTASIPASIEN.lunas = '' " +
                                    "AND MR_MUTASIPASIEN.regbilling = '" + txtNoBilling.Text.Trim().ToString() + "'";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();

                lblMRPasien.Text = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                lblAlamatPasien.Text = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                lblRuangan.Text = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                lblKelas.Text = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                lblStatusPasien.Text = modMain.pbstrgetCol(reader, 7, ref strErr, "");
                lblNamaPasien.Text = modMain.pbstrgetCol(reader, 0, ref strErr, "");

                strIdMR_TempatLayanan = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                strIdMutasiPasien = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                strIdMR_TRuangan = modMain.pbstrgetCol(reader, 4, ref strErr, "");

                this.pvEnableInput();
                this.dtpTglTindakan.Focus();
                btnKeluarIsiTindakan.Text = "&BATAL";
            }
            else
            {
                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();

        }

        /*
     *  NAME        : pvDisableInput
     *  FUNCTION    : disable input on the first time or after save data
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvDisableInput()
        {

            txtNoBilling.Enabled = true;
            lvDaftarTindakan.Enabled = false;
            txtTempatLayanan.Enabled = false;
            txtKodeTindakan.Enabled = false;
            txtNamaDokter.Enabled = false;
            dtpTglTindakan.Enabled = false;
            btnTampilDaftarTindakan.Enabled = false;
            btnTambahTindakan.Enabled = false;
        }

        /*
     *  NAME        : pvEnableInput
     *  FUNCTION    : enable input after enter and found billing registration number
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvEnableInput()
        {
            txtNoBilling.Enabled = false;
            lvDaftarTindakan.Enabled = true;
            txtTempatLayanan.Enabled = true;
            txtKodeTindakan.Enabled = true;
            txtNamaDokter.Enabled = true;
            dtpTglTindakan.Enabled = true;
            btnTampilDaftarTindakan.Enabled = true;
            btnTambahTindakan.Enabled = true;
        }

        /*
     *  NAME        : pvIniSialisasiObject
     *  FUNCTION    : assign the tab index
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvIniSialisasiObject()
        {
            int intNoUrutObject = 0;

            modMain.pvUrutkanTab(txtNoBilling, ref intNoUrutObject);
            modMain.pvUrutkanTab(lblDaftarTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(lvDaftarTindakan, ref intNoUrutObject);            
            
            modMain.pvUrutkanTab(dtpTglTindakan, ref intNoUrutObject,true);
            modMain.pvUrutkanTab(txtTempatLayanan, ref intNoUrutObject);
            
            modMain.pvUrutkanTab(lblKodeTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtKodeTindakan, ref intNoUrutObject);
            
            modMain.pvUrutkanTab(btnTampilDaftarTindakan, ref intNoUrutObject);
            
            modMain.pvUrutkanTab(lblDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtNamaDokter, ref intNoUrutObject);
            
            modMain.pvUrutkanTab(btnTambahTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnSimpanIsiTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnKeluarIsiTindakan, ref intNoUrutObject);

        }

        private void pvCleanInput()
        {
            txtNoBilling.Text = "";
            lblAlamatPasien.Text = "...";
            lblKelas.Text = "...";
            lblMRPasien.Text = "...";
            lblNamaPasien.Text = "...";
            lblRuangan.Text = "...";
            lblStatusPasien.Text = "...";
            lvDaftarTindakan.Items.Clear();
            dtpTglTindakan.Value = halamanUtama.dtTglServer;
            txtTempatLayanan.Text = "";

            grpLstDaftarTindakan.Clear();
            grpLstDaftarKomponenTarif.Clear();

        }


        public void pvLoadDetailTarif(string _strKodeTarif)
        {

            txtKodeTindakan.Text = _strKodeTarif;

            int intResultTarif = grpLstDaftarTarif.FindIndex(m => m.strKodeTarif == _strKodeTarif);

            if (intResultTarif != -1)
            {
                lblBiayaTindakan.Text = grpLstDaftarTarif[intResultTarif].dblBiaya.ToString();
                lblDeskripsiTindakan.Text = grpLstDaftarTarif[intResultTarif].strUraianTarif;
                                
            }

        }

        private bool pvSimpanData(ref string _strNoBukti)
        {
            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                
                return false;
            }

            SqlTransaction trans = conn.BeginTransaction();

            string strIDTransaksi = "";
            double dblIDTransaksi = 0;
            string strNoBukti = "";
            int  intNoBukti = 0;

            /* CHECK THE PERFOMANCE */
            this.strQuerySQL = "SELECT MAX(CAST(NoBukti AS INT)) "+
                               "FROM BL_TRANSAKSI WITH (NOLOCK) "+
                               "WHERE Regbilling = '" + txtNoBilling.Text + 
                               "' AND sistem = 'IRNA'";

            SqlDataReader reader = modDb.pbreaderSQLTrans(conn,this.strQuerySQL,ref strErr,trans);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                trans.Rollback();
                conn.Close();
                return false;
            }

            if (reader.HasRows)
            {
                reader.Read();
                strNoBukti = modMain.pbstrgetCol(reader, 0, ref strErr, "");
            }
            
            reader.Close();


            if (strNoBukti.Trim().ToString() == "")
            {
                /*berarti blm ada tindakan sama sekali..*/
                strNoBukti = "001";
            }
            else
            {
                intNoBukti = Convert.ToInt32(strNoBukti);
                intNoBukti = intNoBukti + 1;
                strNoBukti = intNoBukti.ToString();

                for (int i = 0; i <= (3-strNoBukti.Length); i++)
                {
                    strNoBukti = "0" + strNoBukti;
                }

                _strNoBukti = strNoBukti;
            }


            this.strQuerySQL = "SELECT MAX(idbl_transaksi) " +
                               "FROM BL_TRANSAKSI";

            reader = modDb.pbreaderSQLTrans(conn, this.strQuerySQL, ref strErr, trans);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                trans.Rollback();
                conn.Close();
                return false;
            }

            if (reader.HasRows)
            {
                reader.Read();
                strIDTransaksi = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                dblIDTransaksi = Convert.ToDouble(strIDTransaksi);
                dblIDTransaksi = dblIDTransaksi + 1;
            }

            reader.Close();


            foreach (lstDaftarTindakan itemTindakan in grpLstDaftarTindakan)
            {

                /*                 
                 INSERT INTO BL_TRANSAKSI WITH (Rowlock) " +
                                          "( "+
                                          "Idbl_transaksi, Idmr_mutasipasien, Idbl_pembayaran, " +
                                          "Idmr_tempatlayanan, Idmr_truangan, "+
                */


                this.strQuerySQL = "INSERT INTO BL_TRANSAKSI WITH (ROWLOCK) " +
                                          "( " +
                                          "Idbl_transaksi, Idmr_mutasipasien, " +
                                          "Idbl_pembayaran, " +
                                          "Idmr_tempatlayanan, " +
                                          "Idmr_truangan, " +
                                          "Idmr_Tsmf, " +
                                          "Idbl_tarip, " +
                                          "uraiantarip, " +
                                          "tgltransaksi, " +
                                          "nobukti, jumlah, subsidi, " +
                                          "tunai, klaimaskes, idmr_jenissubsidi, " +
                                          "jml_kasus_tarip, tanggal_bayar, idmr_penjamin, " +
                                          "idmr_pasnonrs, petugas, sistem, " +
                                          "kasir, idmr_shift, batal, " +
                                          "tglbatal, petugasbtl, regbilling, " +
                                          "tglmskrwt, tglkelrwt, harirwt) " +
                                  "VALUES ( " + dblIDTransaksi.ToString() + ", " + strIdMutasiPasien + ", " + 
                                            "0, " +
                                            "" + itemTindakan.intIdTempatLayanan.ToString() +
                                            ", '" + modMain.pbstrBersihkanInput(itemTindakan.strTempatLayanan) + "', " +
                                            "'" + itemTindakan.strTSMFTindakan +
                                          "', '" + itemTindakan.strKodeTarif + "', " +
                                          "'" + modMain.pbstrBersihkanInput(itemTindakan.strUraianTarif) +
                                          "', " + "'" + halamanUtama.dtTglServer.ToString("MM/dd/yyyy HH:mm:ss") + "', " +
                                          "'" + strNoBukti + "', " + itemTindakan.dblBiaya.ToString() + ", 0, " +
                                          "0, 0, '', " +
                                          "1, '01/01/1900 00:00:00', '', " +
                                          "'', '" + modMain.pbstrBersihkanInput(lblPetugas.Text) + "', 'IRNA', " +
                                          "'', '', '', " +
                                          "'01/01/1900 00:00:00', '', '" + txtNoBilling.Text + "',  " +
                                          "'01/01/1900 00:00:00', '01/01/1900 00:00:00', 0  )";

                modDb.pbWriteSQLTrans(conn, this.strQuerySQL, ref strErr, trans);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    trans.Rollback();
                    conn.Close();
                    return false;
                }


                var query = from i in grpLstDaftarKomponenTarif
                            where i.strKodeTarif == itemTindakan.strKodeTarif
                            select i;
                foreach (lstDaftarKomponenTarif itemKomponen in query)
                {

                    string strKodeDokter = itemTindakan.strKodeDokter;

                    if (itemKomponen.strId_Komponen.Trim().ToString() != "JASA PELAYANAN")
                    {
                        strKodeDokter = "";
                    }

                    this.strQuerySQL = "INSERT INTO BL_TRANSAKSIDETAIL WITH (ROWLOCK) " +
                                           "(idmr_mutasipasien, idbl_transaksi, " +
                                           "idbl_komponen, idmr_dokter, " +
                                           "niltarip, niltamb, " +
                                           "nilai, nilaskes, " +
                                           "hak1, hak2, " +
                                           "hak3 ) VALUES " +
                                           "(" + strIdMutasiPasien + "," + dblIDTransaksi.ToString() + ",'" +
                                                   itemKomponen.strId_Komponen + "','" + strKodeDokter +
                                                   "', " + itemKomponen.dblByKomponen.ToString() + ", 0 " +
                                                   "," + itemKomponen.dblByKomponen.ToString() + ", 0 ," +
                                                   itemKomponen.dblHak1.ToString() +
                                                   "," + itemKomponen.dblHak2.ToString() +
                                                   "," + itemKomponen.dblHak3.ToString() + ")";
                    modDb.pbWriteSQLTrans(conn, this.strQuerySQL, ref strErr, trans);
                    if (strErr != "")
                    {
                        modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                        trans.Rollback();
                        conn.Close();
                        return false;
                    }

                }

                dblIDTransaksi = dblIDTransaksi + 1;

            }




            trans.Commit();
            conn.Close();

            return true;

        }


        private void pvHapusList(string _strKodeTindakan)
        {

            DialogResult msgDlg = MessageBox.Show("Apakah akan dihapus ?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgDlg == DialogResult.No)
                return;

            string strKodeTarif = _strKodeTindakan;

            int intResult = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == strKodeTarif);
            if (intResult == -1)
            {
                return;                
            }

            grpLstDaftarTindakan.RemoveAt(intResult);

            List<lstDaftarKomponenTarif> grpDaftarHapus = new List<lstDaftarKomponenTarif>();

            grpLstDaftarKomponenTarif.RemoveAll(m => m.strKodeTarif == strKodeTarif);

            lvDaftarTindakan.Items.Clear();

            grpLstDaftarTindakan.ForEach(
                    delegate(lstDaftarTindakan itemTindakanFetch)
            {

                lvDaftarTindakan.Items.Add(itemTindakanFetch.intNoUrut.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strKodeTarif.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strUraianTarif.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.dblBiaya.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strNamaDokter);   

            });

            lvDaftarTindakan.Focus();
            
            if(lvDaftarTindakan.Items.Count > 0)
                lvDaftarTindakan.Items[0].Selected = true;

        }


        private void pvCetakTindakan(string _strNoBukti)
        {
            string strInit = ((char)27).ToString() + "@";
            string strBarisBaru  = ((char)10).ToString();
            string strCondensed = ((char)15).ToString();

            string strAwalBaris = modMain.karakter_spasi(0);

            string strBold = ((char)27).ToString() + ((char)30).ToString() + ((char)1).ToString();

            StringBuilder strbPrinterDefault = new StringBuilder(256);
            int length = 100;
            GetDefaultPrinter(strbPrinterDefault, ref length);
            modPrint.pbstrNamaPrinter = strbPrinterDefault.ToString();

            if (!modPrint.pbboolBuka("Print Cetak Tindakan")) return;

            modPrint.pbboolCetak(strInit + strCondensed + strAwalBaris + "     No Bukti : " + _strNoBukti + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(98) + lblRuangan.Text + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(35) + lblNamaPasien.Text + modMain.karakter_spasi(58) + txtNoBilling.Text + strBarisBaru);
            
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

            /*DETAIL TRANSAKSI*/

            int intLenKode2Desc = 42;
            int intLenSpaceKode2Desc = 0;

            int intLenDesc2Nom = 70;
            int intLenSpaceDesc2Nom = 0;

            int intLenFirstSpace = 20;
            //int intLenSecondSpace = 

            /*ASUMSI TARIF TERBESAR 1.000.000.000*/
            int intLenNominal = 13;

            string strNominal = "";
            int intSpaceNominal = 0;
            string strSpaceNominal = "";

            double dblTotalPerPrint = 0;

            int intJmlFetchKosong = 4;

            grpLstDaftarTindakan.ForEach(delegate(lstDaftarTindakan itemFetch)
            {

                strNominal = modMain.addPoint(itemFetch.dblBiaya.ToString());
                intSpaceNominal = intLenNominal - strNominal.Length;
                strSpaceNominal = modMain.karakter_spasi(Convert.ToByte(intSpaceNominal));

                intLenSpaceKode2Desc = intLenKode2Desc - (intLenFirstSpace + itemFetch.strKodeTarif.Length);
                intLenSpaceDesc2Nom = (intLenFirstSpace + itemFetch.strKodeTarif.Length + intLenSpaceKode2Desc + intLenDesc2Nom)
                                - (intLenFirstSpace + itemFetch.strKodeTarif.Length + intLenSpaceKode2Desc + itemFetch.strUraianTarif.Length);
                modPrint.pbboolCetak(strAwalBaris + 
                        modMain.karakter_spasi(Convert.ToByte(intLenFirstSpace)) + itemFetch.strKodeTarif + 
                        modMain.karakter_spasi(Convert.ToByte(intLenSpaceKode2Desc))  + itemFetch.strUraianTarif +
                        modMain.karakter_spasi(Convert.ToByte(intLenSpaceDesc2Nom)) + strSpaceNominal + 
                            modMain.addPoint(itemFetch.dblBiaya.ToString()) +                        
                        strBarisBaru);

                dblTotalPerPrint = dblTotalPerPrint + itemFetch.dblBiaya;



                intJmlFetchKosong = intJmlFetchKosong - 1;
            });


            for (int i = 0; i < intJmlFetchKosong; i++)
            {
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            }

            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

            /* TOTAL */

            
            int intSpaceTotal = intLenNominal - modMain.addPoint(dblTotalPerPrint.ToString()).Length;
            string strSpaceTotal = modMain.karakter_spasi(Convert.ToByte(intSpaceTotal));

            modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(112) + strSpaceTotal +  
                                    modMain.addPoint(dblTotalPerPrint.ToString()) + 
                                    strBarisBaru);

            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            
            /* TANGGAL */
            modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(102) + 
                            halamanUtama.dtTglServer.ToString("dd-MM-yyyy HH:mm:ss") +  strBarisBaru);

            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

            /* OPRATOR*/
            modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(98) + halamanUtama.strNamaUser + strBarisBaru);

            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

            modPrint.pbboolTutup();

        }

        /* EOF FUNCTION*/
        
        public inputTindakan()
        {
            InitializeComponent();

            this.pvCleanInput();
            this.pvIniSialisasiObject();
            this.pvLoadDataInisialasi();            
            this.pvDisableInput();


        }

        private void inputTindakan_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtNoBilling_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = modMain.allowOnlyNumeric(e.KeyChar);

            if (e.KeyChar == 13)
            {
                if (txtNoBilling.Text.Trim().ToString() == "")
                    return;

                this.pvLoadDataPasien(txtNoBilling.Text.Trim());
            }
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {

            //if (!txtNoBilling.Enabled)
            //{
            //    DialogResult msgDlg = MessageBox.Show("Apakah anda akan membatalkan pengisian tindakan ?",
            //                                       "Konfirmasi",
            //                                       MessageBoxButtons.YesNo,
            //                                       MessageBoxIcon.Question);

            //    if (msgDlg == System.Windows.Forms.DialogResult.Yes)
            //    {

            //        this.pvCleanInput();
            //        this.pvDisableInput();
            //        btnKeluarIsiTindakan.Text = "&KELUAR";
            //        txtNoBilling.Select();

            //    }
            //}
            //else
            //{
            //    /*if not entry mode*/
                this.Close();
            //}

            
        }

        private void inputTindakan_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!txtNoBilling.Enabled)
            {
                DialogResult msgDlg = MessageBox.Show("Apakah anda akan membatalkan pengisian tindakan ?",
                                                   "Konfirmasi",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (msgDlg == System.Windows.Forms.DialogResult.Yes)
                {

                    this.pvCleanInput();
                    this.pvDisableInput();
                    btnKeluarIsiTindakan.Text = "&KELUAR";
                    txtNoBilling.Select();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void txtKodeTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
       

        private void cmbTempatLayanan_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtTempatLayanan_KeyDown(object sender, KeyEventArgs e)
        {


            if ((e.KeyCode == Keys.Enter) && (txtTempatLayanan.Text != ""))
            {
                int intResultSearch = grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == txtTempatLayanan.Text);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Ruang yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtTempatLayanan.Focus();
                }
                else
                {
                    txtKodeTindakan.Focus();
                }
            }
            else if ((e.KeyCode == Keys.Enter) && (txtTempatLayanan.Text == ""))
            {
                /*  if EMPTY What should i do.. ;) */
                int intResultSearch = grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == lblRuangan.Text);
                if (intResultSearch == -1)
                    txtTempatLayanan.Text = lblRuangan.Text;
                else
                    txtTempatLayanan.Text = grpLstTempatLayanan[intResultSearch].strKodeRuang; 
                
                txtKodeTindakan.Focus();

            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void txtTempatLayanan_Enter(object sender, EventArgs e)
        {
            txtTempatLayanan.Text = "";
            txtTempatLayanan.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtKodeTindakan_Enter(object sender, EventArgs e)
        {
            txtKodeTindakan.Text = "";
            txtKodeTindakan.CharacterCasing = CharacterCasing.Upper;
            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            btnTampilDaftarTindakan.Enabled = true;
        }

        private void txtNamaDokter_Enter(object sender, EventArgs e)
        {
            txtNamaDokter.Text = "";
            //txtNamaDokter.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtKodeTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKodeTindakan.Text.Trim().ToString() != "")
                    txtNamaDokter.Focus();
                else
                    btnTampilDaftarTindakan.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void txtNamaDokter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTambahTindakan.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            if (txtNamaDokter.Text.Trim().ToString() == "")
            {
                if (lblKelas.Text == "SATU")
                {
                    /* perlu ditanyakan apakah setiap tindakan kelas satu harus memilih dokter */

                }
            }
            else
            {
                /*Cek kode tindakan di database*/

                string strKodeNama = txtNamaDokter.Text.Trim().ToString();

                String[] strArrPart = Regex.Split( strKodeNama, "--");

                string strKode =  strArrPart[0].Trim().ToString() ;
                string strNama = strArrPart[1].Trim().ToString();

                int intResultSearch = grpLstDaftarDokter.FindIndex(
                                        m => m.strKodeDokter == strKode);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtNamaDokter.Focus();

                }
            }
        }

        private void txtKodeTindakan_Leave(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "")
            {
                btnTampilDaftarTindakan.Enabled = true;
            }
            else
            {
                /*Cek kode tindakan di database*/

                String[] strArrPart = Regex.Split(txtKodeTindakan.Text.Trim().ToString(), "--");

                string strKode = strArrPart[0].Trim().ToString();
                string strUraian = strArrPart[1].Trim().ToString();

                int intResultSearch = grpLstDaftarTarif.FindIndex(
                                        m => m.strKodeTarif == strKode);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnTampilDaftarTindakan.Enabled = true;
                    txtKodeTindakan.Focus();

                }
                else
                {

                    lblBiayaTindakan.Text = grpLstDaftarTarif[intResultSearch].dblBiaya.ToString();
                    lblDeskripsiTindakan.Text = grpLstDaftarTarif[intResultSearch].strUraianTarif;
                    btnTampilDaftarTindakan.Enabled = false;

                }
            }
        }

        private void inputTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {

                //if (!txtNoBilling.Enabled)
                //{
                //    DialogResult msgDlg = MessageBox.Show("Apakah anda akan membatalkan pengisian tindakan ?",
                //                                                     "Konfirmasi",
                //                                                     MessageBoxButtons.YesNo,
                //                                                     MessageBoxIcon.Question);

                //    if (msgDlg == System.Windows.Forms.DialogResult.Yes)
                //    {

                //        this.pvCleanInput();
                //        this.pvDisableInput();
                //        btnKeluarIsiTindakan.Text = "&KELUAR";
                //        txtNoBilling.Select();

                //    }
                //}
                //else
                //{
                    this.Close();
                //}
            }
        }

        private void txtTempatLayanan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }            
        }

        private void btnTampilDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                daftarTindakan fDaftarTindakan = new daftarTindakan();
                fDaftarTindakan.ShowDialog();
            }
        }

        private void btnTampilDaftarTindakan_Click(object sender, EventArgs e)
        {
            daftarTindakan fDaftarTindakan = new daftarTindakan();
            fDaftarTindakan.ShowDialog();
        }

        private void btnTambahTindakan_Click(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Kode Tindakan harus di isi terlebih dahulu",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                txtKodeTindakan.Focus();
                return;
            }

            if (txtNamaDokter.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Untuk tindakan KELAS 1 harus disertakan nama dokter",
                                 "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                txtNamaDokter.Focus();
                return;
            }

            //string strNamaDokter = txtNamaDokter.Text.Trim().ToString();
            //string strKodeDokter = "";

            string strKodeNama = txtNamaDokter.Text.Trim().ToString();

            string strKodeDokter = "";
            string strNamaDokter = "";

            String[] strArrPart = null;

            if(strKodeNama != "")
            {

                strArrPart = Regex.Split(strKodeNama, "--");

                strKodeDokter = strArrPart[0].Trim().ToString();
                strNamaDokter = strArrPart[1].Trim().ToString();

                int intResultSearchDoctor = grpLstDaftarDokter.FindIndex(
                                                m => m.strKodeDokter == strKodeDokter);

                if (intResultSearchDoctor != -1)
                {
                    //strKodeDokter = grpLstDaftarDokter[intResultSearchDoctor].strKodeDokter;
                    strNamaDokter = grpLstDaftarDokter[intResultSearchDoctor].strNamaDokter;
                }
                else
                {
                    MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                  "Informasi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    txtNamaDokter.Focus();
                    return;
                }

            }

            strArrPart = Regex.Split(txtKodeTindakan.Text, "--");

            string strKodeTindakan = strArrPart[0].Trim().ToString();
            string strUraianTindakan = strArrPart[1].Trim().ToString();

            

            lstDaftarTindakan itemTindakan = new lstDaftarTindakan();
            itemTindakan.strKodeTarif = strKodeTindakan;
            
            itemTindakan.strKodeDokter = strKodeDokter;
            itemTindakan.strUraianTarif = strUraianTindakan;
            itemTindakan.dblBiaya = Convert.ToDouble(lblBiayaTindakan.Text);
            itemTindakan.intNoUrut = grpLstDaftarTindakan.Count + 1;
            itemTindakan.strNamaDokter = strNamaDokter;
            
            itemTindakan.strTempatLayanan = txtTempatLayanan.Text;

            itemTindakan.intIdTempatLayanan = Convert.ToInt32(strIdMR_TempatLayanan);

            int intResult = grpLstDaftarTarif.FindIndex(m => m.strKodeTarif == strKodeTindakan);
            itemTindakan.strTSMFTindakan = grpLstDaftarTarif[intResult].strSMF;
            

            //int intResult = grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == txtTempatLayanan.Text);

            //itemTindakan.intIdTempatLayanan = 0;

            //if (intResult != -1)
            //{
            //    itemTindakan.intIdTempatLayanan = Convert.ToInt32(grpLstTempatLayanan[intResult].strKodeRuang);
            //}
            
            grpLstDaftarTindakan.Add(itemTindakan);

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            this.strQuerySQL = "SELECT " +
                                    "idbl_tarip, " +        //0
                                    "idbl_komponen, "+      //1
                                    "bykomponen, "+         //2
                                    "Hak1, "+               //3
                                    "Hak2, "+               //4
                                    "Hak3, "+               //5
                                    "PrioritasTunai " +      //6
                                "FROM BL_KOMPTARIP WITH (NOLOCK) " +
                                "WHERE idbl_tarip = '" + strKodeTindakan + "'";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lstDaftarKomponenTarif itemKomponenTarif = new lstDaftarKomponenTarif();
                    itemKomponenTarif.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKomponenTarif.strId_Komponen = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKomponenTarif.dblByKomponen = Convert.ToDouble(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    itemKomponenTarif.dblHak1 = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKomponenTarif.dblHak2 = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKomponenTarif.dblHak3 = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKomponenTarif.intPrioritasTunai = Convert.ToInt32(modMain.pbstrgetCol(reader, 6, ref strErr, ""));

                    grpLstDaftarKomponenTarif.Add(itemKomponenTarif);
                }

            }


            reader.Close();
            conn.Close();

            lvDaftarTindakan.Items.Clear();
            grpLstDaftarTindakan.ForEach(
                delegate(
                    lstDaftarTindakan itemTindakanFetch) 
            {

                lvDaftarTindakan.Items.Add(itemTindakanFetch.intNoUrut.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strKodeTarif.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strUraianTarif.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.dblBiaya.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strNamaDokter);

            });

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 5);

            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            txtKodeTindakan.Text = "";
            txtNamaDokter.Text = "";
            //dtpTglTindakan.Focus();
            lvDaftarTindakan.HideSelection = false;
            lvDaftarTindakan.Focus();           

        }

        private void txtTempatLayanan_Leave(object sender, EventArgs e)
        {

            if (txtTempatLayanan.Text != "")
            {
                int intResultSearch = grpLstTempatLayanan.FindIndex(m => m.strKodeRuang == txtTempatLayanan.Text);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Ruang yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtTempatLayanan.Focus();
                }
                else
                {
                    txtKodeTindakan.Focus();
                }
            }
            else
            {
                /*  if EMPTY What should i do.. ;) */

                int intResultSearch = grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == lblRuangan.Text);
                if (intResultSearch == -1)
                    txtTempatLayanan.Text = lblRuangan.Text;
                else
                    txtTempatLayanan.Text = grpLstTempatLayanan[intResultSearch].strKodeRuang;

                //txtTempatLayanan.Text = lblRuangan.Text;
                txtKodeTindakan.Focus();

            }

        }

        private void btnSimpanIsiTindakan_Click(object sender, EventArgs e)
        {
            if (txtNoBilling.Enabled)
                return;

            if (lvDaftarTindakan.Items.Count == 0)
            {
                MessageBox.Show("Tidak ada yang disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult msgDlg = MessageBox.Show("Apakah akan disimpan ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgDlg == DialogResult.No)
                return;

            string strNoBukti = "";

            if (this.pvSimpanData(ref strNoBukti))
            {
                this.pvCetakTindakan(strNoBukti);

                /*AFTER SUCCESS INSERT THEN CLEAR THIS..*/
                grpLstDaftarKomponenTarif.Clear();
                this.pvCleanInput();
                this.pvDisableInput();
            }

            

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lvDaftarTindakan_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (lvDaftarTindakan.Items.Count > 0))
            {
                cmsDaftarTindakan.Show(this.lvDaftarTindakan, e.Location);
            }
        }

        private void lvDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pvHapusList(lvDaftarTindakan.SelectedItems[0].SubItems[1].Text);
        }

        private void lvDaftarTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.pvHapusList(lvDaftarTindakan.SelectedItems[0].SubItems[1].Text);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                dtpTglTindakan.Focus();
            }
        }

        private void lvDaftarTindakan_Enter(object sender, EventArgs e)
        {
            if (lvDaftarTindakan.Items.Count > 0)
            {
                lvDaftarTindakan.Items[0].Selected = true;
            }
        }

        private void txtNoBilling_Enter(object sender, EventArgs e)
        {
            //txtNoBilling.BackColor = Color.BlanchedAlmond;
        }

        private void txtNoBilling_Leave(object sender, EventArgs e)
        {
            //txtNoBilling.BackColor = Color.White;
        }

        private void dtpTglTindakan_Enter(object sender, EventArgs e)
        {
            
        }

        private void inputTindakan_Shown(object sender, EventArgs e)
        {
            txtNoBilling.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pvCetakTindakan("007");
        } 

      
    } /*EOF*/
}
