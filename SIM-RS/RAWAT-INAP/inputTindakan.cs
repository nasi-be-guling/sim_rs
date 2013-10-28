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
using System.Diagnostics;
using System.IO;

namespace SIM_RS.RAWAT_INAP
{
    public partial class inputTindakan : Form
    {

        /* TEST NO REGISTER BILLING : 1329274 */
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

        bool boolBypassDokter = false;
        

        /*VARIABLE INSERT TO BL_TRANSAKSI*/
        string strIdMutasiPasien = "";
        string strIdMR_TempatLayanan = "";
        string strIdMR_TRuangan = "";
        int intUrutanTrans = 0;        
        int intUrutanTindakan = 1;
        int intUrutanTindakanDetail = 1;
        int intIDDetailTindakanUpdate = 0;

        //string strSMFTindakan = "";
        string strSMFDokter = "";

        bool isProsesUpdate = false;
        bool isProsesRubahResolusi = false;
        
        private int intDefaultHeightScreen = 0; 
        private int intDefaultWidthScreen = 0;

        halamanUtama fHalamanUtama = null;

        AutoCompleteStringCollection listTarif = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listTempatLayanan = new AutoCompleteStringCollection();

        public class lstDaftarKomponenTarif
        {
            public string strKodeTarif { get; set; }
            public string strId_Komponen { get; set; }
            public double dblByKomponen { get; set; }
            public double dblHak1 { get; set; }
            public double dblHak2 { get; set; }
            public double dblHak3 { get; set; }
            public int intPrioritasTunai {get; set;}
            public int intNoUrut { get; set; }
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public int intUrutanDetailTindakan { get; set; }
            public int intUrutanTindakan { get; set; }
        }

        //List<lstDaftarKomponenTarif> grpLstDaftarLengkapKomponenTarif = new List<lstDaftarKomponenTarif>();
        //data sementara untuk menghandle data yang akan di masukkan ke list.
        
        public List<lstDaftarKomponenTarif> grpLstTempTindakanDetail = new List<lstDaftarKomponenTarif>();
      

        public class lstDaftarTindakan
        {
            public int intNoUrut { get; set; }
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strTSMFTindakan { get; set; }
            public string strTempatLayanan { get; set; }
            public int intIdTempatLayanan { get; set; }
            public string strIdMRRuangan { get; set; }
            public DateTime dtTgl { get; set; }
            public int intUrutanTindakan { get; set; }
        }
        public List<lstDaftarTindakan> grpLstDaftarTindakan = new List<lstDaftarTindakan>();
        List<lstDaftarKomponenTarif> grpLstDaftarTindakanDetail = new List<lstDaftarKomponenTarif>();

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
            btnTampilDaftarTarif.Enabled = false;
            btnTambahTindakan.Enabled = false;
            cmbKomponenTarif.Enabled = false;
            btnTambahKompDokter.Enabled = false;
            btnBatalTindakan.Enabled = false;
            btnDaftarKompTarif.Enabled = false;
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
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Enabled = true);
            txtTempatLayanan.SafeControlInvoke(TextBox => txtTempatLayanan.Enabled = true);
            txtKodeTindakan.SafeControlInvoke(TextBox => txtKodeTindakan.Enabled = true);
            dtpTglTindakan.SafeControlInvoke(DateTimePicker => dtpTglTindakan.Enabled = true);
            btnTampilDaftarTarif.SafeControlInvoke(Button => btnTampilDaftarTarif.Enabled = true);

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
            modMain.pvUrutkanTab(btnTampilDaftarTarif, ref intNoUrutObject);

            modMain.pvUrutkanTab(lblKomponen, ref intNoUrutObject);
            modMain.pvUrutkanTab(cmbKomponenTarif, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnDaftarKompTarif, ref intNoUrutObject);

            modMain.pvUrutkanTab(lblDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtNamaDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnTambahKompDokter, ref intNoUrutObject);
            
            modMain.pvUrutkanTab(btnTambahTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnBatalTindakan, ref intNoUrutObject);

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

            txtKodeTindakan.Text = "";
            txtNamaDokter.Text = "";
            grpLstDaftarTindakan.Clear();
            //grpLstDaftarKomponenTarif.Clear();
            grpLstDaftarTindakanDetail.Clear();

            intUrutanTrans = 0;
            

        }

        #region CODE STATUS :  NEED REVIEW LATER
        public void pvLoadDetailTarif(string _strKodeTarif)
        {

            txtKodeTindakan.Text = _strKodeTarif;

            /*Cek kode tindakan di database*/

            String[] strKodePart = Regex.Split(txtKodeTindakan.Text.Trim().ToString(), "--");

            if (strKodePart.Count() <= 1)
            {
                MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                               "Informasi",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                btnTampilDaftarTarif.Enabled = true;
                txtKodeTindakan.Enabled = true;
                txtKodeTindakan.Text = "";
                txtKodeTindakan.Focus();
                return;
            }

            string strKode = strKodePart[0].Trim().ToString();
            string strUraian = strKodePart[1].Trim().ToString();

            fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];
            int intResultSearch = data.grpLstDaftarTarif.FindIndex(
                                    m => m.strKodeTarif == strKode);

            if (intResultSearch == -1) //dicek apakah tindakan tersebut ada di dalam database.
            {
                MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                btnTampilDaftarTarif.Enabled = true;
                txtKodeTindakan.Enabled = true;
                txtKodeTindakan.Focus();
            }
            else //jika tindakan tersebut ada maka proses selanjutnya.
            {
                #region CODE STATUS : NEED REVIEW LATER -> REASON : CHANGED TO DATABASE CONNECT
                ////Tampilkan detail komponen apa saja
                //var DetailKomponen = from x in grpLstDaftarLengkapKomponenTarif
                //                     where x.strKodeTarif == strKode
                //                     select x;

                //if (DetailKomponen.Count() > 0)
                //{
                //    cmbKomponenTarif.Items.Clear();
                //    cmbKomponenTarif.Enabled = true;
                //    grpLstTempTindakanDetail.Clear();
                //    foreach (lstDaftarKomponenTarif itemKomponen in DetailKomponen)
                //    {

                //        if(itemKomponen.strId_Komponen != "JASA SARANA") //komponen jasa sarana tidak perlu  ditammpilkan untuk dokter
                //            cmbKomponenTarif.Items.Add(itemKomponen.strId_Komponen);

                //        lstDaftarKomponenTarif itemKomponenX = new lstDaftarKomponenTarif();
                //        itemKomponenX.strKodeTarif = itemKomponen.strKodeTarif;
                //        itemKomponenX.strId_Komponen = itemKomponen.strId_Komponen;
                //        itemKomponenX.dblByKomponen = itemKomponen.dblByKomponen;
                //        itemKomponenX.dblHak1 = itemKomponen.dblHak1;
                //        itemKomponenX.dblHak2 = itemKomponen.dblHak2;
                //        itemKomponenX.dblHak3 = itemKomponen.dblHak3;
                //        itemKomponenX.intNoUrut = itemKomponen.intNoUrut;
                //        itemKomponenX.intPrioritasTunai = itemKomponen.intPrioritasTunai;
                //        itemKomponenX.strKodeDokter = "";
                //        itemKomponenX.strNamaDokter = "";
                //        grpLstTempTindakanDetail.Add(itemKomponenX);
                //    }
                //}
                //else
                //{
                //    //if result == 0 or less
                //    cmbKomponenTarif.Enabled = false;
                //}
                #endregion

                this.strErr = "";
                C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
                SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
                if (strErr != "")
                {
                    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    return;
                }

                this.strQuerySQL = "SELECT " +
                                        "idbl_tarip, " +        //0
                                        "idbl_komponen, " +      //1
                                        "bykomponen, " +         //2
                                        "Hak1, " +               //3
                                        "Hak2, " +               //4
                                        "Hak3, " +               //5
                                        "PrioritasTunai " +      //6
                                    "FROM BL_KOMPTARIP " +
                                    "WHERE idbl_tarip = '" + strKode + "'";
                SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    conn.Close();
                    return;
                }

                if (reader.HasRows)
                {
                    cmbKomponenTarif.Items.Clear();
                    cmbKomponenTarif.Enabled = true;
                    grpLstTempTindakanDetail.Clear();

                    while (reader.Read())
                    {
                        string strItemKompTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");

                        if (strItemKompTarif.Trim().ToString() != "JASA SARANA") //komponen jasa sarana tidak perlu  ditammpilkan untuk dokter
                            cmbKomponenTarif.Items.Add(strItemKompTarif.Trim().ToString());

                        lstDaftarKomponenTarif itemKomponenX = new lstDaftarKomponenTarif();
                        itemKomponenX.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                        itemKomponenX.strId_Komponen = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                        itemKomponenX.dblByKomponen = Convert.ToDouble(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                        itemKomponenX.dblHak1 = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                        itemKomponenX.dblHak2 = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                        itemKomponenX.dblHak3 = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                        itemKomponenX.intNoUrut = intUrutanTrans;
                        itemKomponenX.intPrioritasTunai = Convert.ToInt32(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                        itemKomponenX.strKodeDokter = "";
                        itemKomponenX.strNamaDokter = "";
                        grpLstTempTindakanDetail.Add(itemKomponenX);
                    }

                }
                else
                {
                    cmbKomponenTarif.Enabled = false;
                }

                reader.Close();
                conn.Close();

                lblBiayaTindakan.Text = data.grpLstDaftarTarif[intResultSearch].dblBiaya.ToString();
                lblDeskripsiTindakan.Text = data.grpLstDaftarTarif[intResultSearch].strUraianTarif;
                btnTampilDaftarTarif.Enabled = false;
                txtKodeTindakan.Enabled = false;
                if (cmbKomponenTarif.Enabled)
                {
                    lblKomponen.Focus();
                    //cmbKomponenTarif.Focus();
                }
                btnDaftarKompTarif.Enabled = true;
                txtNamaDokter.Enabled = true;
                btnTambahKompDokter.Enabled = true;
                btnTambahTindakan.Enabled = true;
                btnBatalTindakan.Enabled = true;

            }
        }
        #endregion

        private bool pvSimpanData(ref string _strNoBukti)
        {
            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

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


                this.strQuerySQL = "INSERT INTO BL_TRANSAKSI " +
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
                                          "', " + "'" + itemTindakan.dtTgl.ToString("MM/dd/yyyy HH:mm:ss") + "', " +
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


                //foreach (lstDaftarKomponenTarif itemKomponen in grpLstDaftarKomponenTarif)
                //{

                //    //if ((itemKomponen.strKodeTarif == itemTindakan.strKodeTarif) && (itemKomponen.intNoUrut == itemTindakan.intNoUrut))
                //        MessageBox.Show(itemKomponen.strKodeTarif.ToString() + "," + itemTindakan.strKodeTarif + 
                //                        " - " + itemKomponen.strId_Komponen.ToString() +
                //                    " - " + itemKomponen.intNoUrut.ToString() + "," + itemTindakan.intNoUrut.ToString());

                //}              

                var query = from i in grpLstDaftarTindakanDetail
                            where i.intUrutanTindakan == itemTindakan.intUrutanTindakan                                                             
                            select i;

                if (query.Count() == 0)
                {
                    MessageBox.Show("Ada Permasalah dalam proses penyimpanan data dengan kode Tarif  : " + itemTindakan.strKodeTarif + 
                                    ", hubungi Administrator", 
                                    "Informasi", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    trans.Rollback();
                    conn.Close();
                    return false;
                }

                foreach (lstDaftarKomponenTarif itemKomponen in query)
                {

                    //string strKodeDokter = itemTindakan.strKodeDokter;

                    //if (itemKomponen.strId_Komponen.Trim().ToString() != "JASA PELAYANAN")
                    //{
                    //    strKodeDokter = "";
                    //}

                    this.strQuerySQL = "INSERT INTO BL_TRANSAKSIDETAIL " +
                                           "(idmr_mutasipasien, idbl_transaksi, " +
                                           "idbl_komponen, idmr_dokter, " +
                                           "niltarip, niltamb, " +
                                           "nilai, nilaskes, " +
                                           "hak1, hak2, " +
                                           "hak3 ) VALUES " +
                                           "(" + strIdMutasiPasien + "," + dblIDTransaksi.ToString() + ",'" +
                                                   itemKomponen.strId_Komponen + "','" + itemKomponen.strKodeDokter +
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

        #region CODE STATUS : NEED REVIEW LATER
        //private void pvHapusList(string _strKodeTindakan, string _strNoUrut)
        //{
           
            //DialogResult msgDlg = MessageBox.Show("Apakah akan dihapus ?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (msgDlg == DialogResult.No)
            //    return;

            //string strKodeTarif = _strKodeTindakan;
            //string strNoUrut = _strNoUrut;

            //int intResult = grpLstDaftarTindakan.FindIndex(
            //                        m => m.strKodeTarif == strKodeTarif &&
            //                            m.intNoUrut.ToString() == strNoUrut);
            //if (intResult == -1)
            //{
            //    return;
            //}

            //grpLstDaftarTindakan.RemoveAt(intResult);

            ////List<lstDaftarKomponenTarif> grpDaftarHapus = new List<lstDaftarKomponenTarif>();

            //grpLstDaftarTindakanDetail.RemoveAll(m => m.strKodeTarif == strKodeTarif && m.intNoUrut.ToString() == strNoUrut);

            //lvDaftarTindakan.Items.Clear();

            //int intNoUrut = 1;

            //grpLstDaftarTindakan.ForEach(
            //        delegate(lstDaftarTindakan itemTindakanFetch)
            //        {

            //            lvDaftarTindakan.Items.Add(intNoUrut.ToString());
            //            lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strKodeTarif.ToString());
            //            lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strUraianTarif.ToString());
            //            lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.dblBiaya.ToString());
            //            lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strNamaDokter);
            //            lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.intNoUrut.ToString());

            //            intNoUrut++;

            //        });

            //lvDaftarTindakan.Focus();

            //if (lvDaftarTindakan.Items.Count > 0)
            //    lvDaftarTindakan.Items[0].Selected = true;            
        //}
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_strNoBukti"></param>
        private void pvCetakTindakan(string _strNoBukti)
        {           

            int intJumlahData = lvDaftarTindakan.Items.Count;

            if (!modPrint.pbboolBuka("Print Cetak Tindakan")) return;

            int intLastPrintID = 0;

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

            double dblTotalPerCetak = 0;

            int intMaxPerCetak = 4;
            int intJmlFetchKosong = intMaxPerCetak;

            string strInit = ((char)27).ToString() + "@";
            string strBarisBaru = ((char)10).ToString();
            string strCondensed = ((char)15).ToString();

            string strAwalBaris = modMain.karakter_spasi(0);

            string strBold = ((char)27).ToString() + ((char)30).ToString() + ((char)1).ToString();

            StringBuilder strbPrinterDefault = new StringBuilder(256);
            int length = 100;
            GetDefaultPrinter(strbPrinterDefault, ref length);
            modPrint.pbstrNamaPrinter = strbPrinterDefault.ToString();           

            /* inisialisasi variable do not care with this... */
            var queryResult = (from i in grpLstDaftarTindakan where i.intNoUrut == 0 select i).Take(0);

            //MessageBox.Show((intJumlahData % intMaxPerCetak).ToString());
            do
            {
                if (intLastPrintID > 0)
                {
                    modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                    modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                }

                modPrint.pbboolCetak(strInit + strCondensed + strAwalBaris + "     No Bukti : " + _strNoBukti + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(98) + lblRuangan.Text + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(35) + lblNamaPasien.Text + modMain.karakter_spasi(58) + txtNoBilling.Text + strBarisBaru);

                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

                dblTotalPerCetak = 0;                

                if(intLastPrintID > 0)
                   queryResult = (from i in grpLstDaftarTindakan
                                   where  (i.intNoUrut > intLastPrintID)
                                   select i).Take(intMaxPerCetak);
                else
                   queryResult = (from i in grpLstDaftarTindakan
                                   where (i.intNoUrut >= intLastPrintID) 
                                   select i).Take(intMaxPerCetak);


                intJmlFetchKosong = intMaxPerCetak;               

                foreach (lstDaftarTindakan itemTindakan in queryResult)
                {
                    strNominal = modMain.addPoint(itemTindakan.dblBiaya.ToString());
                    intSpaceNominal = intLenNominal - strNominal.Length;
                    strSpaceNominal = modMain.karakter_spasi(Convert.ToByte(intSpaceNominal));

                    intLenSpaceKode2Desc = intLenKode2Desc - (intLenFirstSpace + itemTindakan.strKodeTarif.Length);
                    intLenSpaceDesc2Nom = (intLenFirstSpace + itemTindakan.strKodeTarif.Length + intLenSpaceKode2Desc + intLenDesc2Nom)
                                    - (intLenFirstSpace + itemTindakan.strKodeTarif.Length + intLenSpaceKode2Desc + itemTindakan.strUraianTarif.Length);
                    modPrint.pbboolCetak(strAwalBaris +
                            modMain.karakter_spasi(Convert.ToByte(intLenFirstSpace)) + itemTindakan.strKodeTarif +
                            modMain.karakter_spasi(Convert.ToByte(intLenSpaceKode2Desc)) + itemTindakan.strUraianTarif +
                            modMain.karakter_spasi(Convert.ToByte(intLenSpaceDesc2Nom)) + strSpaceNominal +
                                modMain.addPoint(itemTindakan.dblBiaya.ToString()) +
                            strBarisBaru);

                    dblTotalPerCetak = dblTotalPerCetak + itemTindakan.dblBiaya;
                    intLastPrintID = itemTindakan.intNoUrut;
                    intJmlFetchKosong = intJmlFetchKosong - 1;
                }             


                for (int i = 0; i < intJmlFetchKosong; i++)
                {
                    modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                }

                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

                /* TOTAL */


                int intSpaceTotal = intLenNominal - modMain.addPoint(dblTotalPerCetak.ToString()).Length;
                string strSpaceTotal = modMain.karakter_spasi(Convert.ToByte(intSpaceTotal));

                modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(112) + strSpaceTotal +
                                        modMain.addPoint(dblTotalPerCetak.ToString()) +
                                        strBarisBaru);

                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

                /* TANGGAL */
                modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(102) +
                                halamanUtama.dtTglServer.ToString("dd-MM-yyyy HH:mm:ss") + strBarisBaru);

                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

                /* OPRATOR*/
                modPrint.pbboolCetak(strAwalBaris + modMain.karakter_spasi(98) + halamanUtama.strNamaUser + strBarisBaru);

                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
                modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

                intJumlahData = intJumlahData - 4;

            } while ((intJumlahData % intMaxPerCetak) > 0);


            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);
            modPrint.pbboolCetak(strAwalBaris + strBarisBaru);

            modPrint.pbboolTutup();
        }

        private void pvLoadLV()
        {
            int intUrutanLV = 1;
            int intUrutanTemp = 0;

            lvDaftarTindakan.Items.Clear();
            int intx = 0;
            grpLstDaftarTindakanDetail.ForEach(
                delegate(lstDaftarKomponenTarif x)
                {
                    if (intUrutanTemp != x.intUrutanTindakan)
                    {
                        lvDaftarTindakan.Items.Add((intUrutanLV.ToString()).ToString());
                        intUrutanLV++;
                        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strKodeTarif.ToString());
                        intx = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == x.strKodeTarif);
                        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                grpLstDaftarTindakan[intx].strUraianTarif);
                    }
                    else
                    {
                        lvDaftarTindakan.Items.Add("");
                        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add("");
                        intx = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == x.strKodeTarif);
                        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add("");
                    }

                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strId_Komponen.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.dblByKomponen.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strKodeDokter + " -- " + x.strNamaDokter);
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.intUrutanDetailTindakan.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.intUrutanTindakan.ToString());
                    intUrutanTemp = x.intUrutanTindakan;


                });

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 6);
        }

        /* EOF FUNCTION*/
        
        public inputTindakan()
        {
            InitializeComponent();

            this.pvCleanInput();
            this.pvIniSialisasiObject();
            this.pvDisableInput();

            
            this.bgWorkLoadDataInit.RunWorkerAsync();

            if (Debugger.IsAttached)
                txtNoBilling.Text = "1329274";
            else
                txtNoBilling.Text = "";

        }

        private void inputTindakan_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];
            lblPetugas.Text = fHalamanUtama.txtPetugas.Text;

            Screen screen = Screen.PrimaryScreen;
            intDefaultWidthScreen = screen.Bounds.Width;
            intDefaultHeightScreen = screen.Bounds.Height;

            if ((intDefaultWidthScreen < 1024) && (intDefaultHeightScreen < 768))
            {
                C4Module.Resolution modResolution = new C4Module.Resolution(1024, 768);
                isProsesRubahResolusi = true;
            }
        }

        private void txtNoBilling_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = modMain.allowOnlyNumeric(e.KeyChar);
            if (e.KeyChar == 13)
            {
                if (txtNoBilling.Text.Trim().ToString() == "")
                    return;

                this.bgWork.RunWorkerAsync();
            }
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        { 
            this.Close();
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
                    e.Cancel = true;
                    isProsesUpdate = false;                    
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (isProsesRubahResolusi)
                {
                    C4Module.Resolution modResolution = new C4Module.Resolution(intDefaultWidthScreen, intDefaultHeightScreen);
                }

                e.Cancel = false;
            }            
        }    

        private void txtTempatLayanan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtTempatLayanan.Text != ""))
            {
                int intResultSearch = data.grpLstTempatLayanan.FindIndex(
                                            m => m.strKodeRuang.Trim().ToString() == txtTempatLayanan.Text.Trim().ToString());
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
                int intResultSearch = data.grpLstTempatLayanan.FindIndex(
                                                m => m.strNamaRuang == lblRuangan.Text);
                if (intResultSearch == -1)
                    txtTempatLayanan.Text = lblRuangan.Text;
                else
                    txtTempatLayanan.Text = data.grpLstTempatLayanan[intResultSearch].strKodeRuang; 
                
                txtKodeTindakan.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
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
            txtNamaDokter.Enabled = true;

            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            btnTampilDaftarTarif.Enabled = true;
        }

        private void txtNamaDokter_Enter(object sender, EventArgs e)
        {
            txtNamaDokter.Text = "";
            txtNamaDokter.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtKodeTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKodeTindakan.Enabled = false;
                if (txtKodeTindakan.Text.Trim().ToString() != "")
                {
                    cmbKomponenTarif.Enabled = true;
                    cmbKomponenTarif.Focus();
                }
                else
                    btnTampilDaftarTarif.Focus();

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
                int intResultSearch = data.grpLstDaftarDokter.FindIndex(
                                        m => m.strKodeDokter == strKode);
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
                    btnTambahKompDokter.Focus();
                }
            }
        }

        private void txtKodeTindakan_Leave(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "") //cek apakah kode tindakan harus ada isinya..
            {
                btnTampilDaftarTarif.Enabled = true;
            }
            else //jika sudah terisi
            {
                /*Cek kode tindakan di database*/

                String[] strKodePart = Regex.Split(txtKodeTindakan.Text.Trim().ToString(), "--");

                if (strKodePart.Count() <= 1)
                {
                    MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                   "Informasi",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    btnTampilDaftarTarif.Enabled = true;
                    txtKodeTindakan.Enabled = true;
                    txtKodeTindakan.Text = "";
                    txtKodeTindakan.Focus();
                    return;
                }

                string strKode = strKodePart[0].Trim().ToString();
                string strUraian = strKodePart[1].Trim().ToString();

                fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];
                int intResultSearch = data.grpLstDaftarTarif.FindIndex(
                                        m => m.strKodeTarif == strKode);

                if (intResultSearch == -1) //dicek apakah tindakan tersebut ada di dalam database.
                {
                    MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnTampilDaftarTarif.Enabled = true;
                    txtKodeTindakan.Enabled = true;
                    txtKodeTindakan.Focus();
                }
                else //jika tindakan tersebut ada maka proses selanjutnya.
                {
                    #region CODE STATUS : NEED REVIEW LATER -> REASON : CHANGED TO DATABASE CONNECT
                    ////Tampilkan detail komponen apa saja
                    //var DetailKomponen = from x in grpLstDaftarLengkapKomponenTarif
                    //                     where x.strKodeTarif == strKode
                    //                     select x;

                    //if (DetailKomponen.Count() > 0)
                    //{
                    //    cmbKomponenTarif.Items.Clear();
                    //    cmbKomponenTarif.Enabled = true;
                    //    grpLstTempTindakanDetail.Clear();
                    //    foreach (lstDaftarKomponenTarif itemKomponen in DetailKomponen)
                    //    {

                    //        if(itemKomponen.strId_Komponen != "JASA SARANA") //komponen jasa sarana tidak perlu  ditammpilkan untuk dokter
                    //            cmbKomponenTarif.Items.Add(itemKomponen.strId_Komponen);

                    //        lstDaftarKomponenTarif itemKomponenX = new lstDaftarKomponenTarif();
                    //        itemKomponenX.strKodeTarif = itemKomponen.strKodeTarif;
                    //        itemKomponenX.strId_Komponen = itemKomponen.strId_Komponen;
                    //        itemKomponenX.dblByKomponen = itemKomponen.dblByKomponen;
                    //        itemKomponenX.dblHak1 = itemKomponen.dblHak1;
                    //        itemKomponenX.dblHak2 = itemKomponen.dblHak2;
                    //        itemKomponenX.dblHak3 = itemKomponen.dblHak3;
                    //        itemKomponenX.intNoUrut = itemKomponen.intNoUrut;
                    //        itemKomponenX.intPrioritasTunai = itemKomponen.intPrioritasTunai;
                    //        itemKomponenX.strKodeDokter = "";
                    //        itemKomponenX.strNamaDokter = "";
                    //        grpLstTempTindakanDetail.Add(itemKomponenX);
                    //    }
                    //}
                    //else
                    //{
                    //    //if result == 0 or less
                    //    cmbKomponenTarif.Enabled = false;
                    //}
                    #endregion 

                    this.strErr = "";
                    C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
                    SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
                    if (strErr != "")
                    {
                        lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                        modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                        return;
                    }
                        
                    this.strQuerySQL = "SELECT " +
                                            "idbl_tarip, " +        //0
                                            "idbl_komponen, " +      //1
                                            "bykomponen, " +         //2
                                            "Hak1, " +               //3
                                            "Hak2, " +               //4
                                            "Hak3, " +               //5
                                            "PrioritasTunai " +      //6
                                        "FROM BL_KOMPTARIP "+
                                        "WHERE idbl_tarip = '" + strKode + "'";
                    SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
                    if (strErr != "")
                    {
                        modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                        conn.Close();
                        return;
                    }

                    if (reader.HasRows)
                    {
                        cmbKomponenTarif.Items.Clear();
                        cmbKomponenTarif.Enabled = true;
                        grpLstTempTindakanDetail.Clear();

                        while (reader.Read())
                        {
                            string strItemKompTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");

                            if (strItemKompTarif.Trim().ToString() != "JASA SARANA") //komponen jasa sarana tidak perlu  ditammpilkan untuk dokter
                                cmbKomponenTarif.Items.Add(strItemKompTarif.Trim().ToString());

                            lstDaftarKomponenTarif itemKomponenX = new lstDaftarKomponenTarif();
                            itemKomponenX.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                            itemKomponenX.strId_Komponen = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                            itemKomponenX.dblByKomponen = Convert.ToDouble(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                            itemKomponenX.dblHak1 = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                            itemKomponenX.dblHak2 = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                            itemKomponenX.dblHak3 = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                            itemKomponenX.intNoUrut = intUrutanTrans;
                            itemKomponenX.intPrioritasTunai = Convert.ToInt32(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                            itemKomponenX.strKodeDokter = "";
                            itemKomponenX.strNamaDokter = "";
                            grpLstTempTindakanDetail.Add(itemKomponenX);
                        }

                    }
                    else
                    {
                        cmbKomponenTarif.Enabled = false;
                    }

                    reader.Close();
                    conn.Close();

                    lblBiayaTindakan.Text = data.grpLstDaftarTarif[intResultSearch].dblBiaya.ToString();
                    lblDeskripsiTindakan.Text = data.grpLstDaftarTarif[intResultSearch].strUraianTarif;
                    btnTampilDaftarTarif.Enabled = false;
                    txtKodeTindakan.Enabled = false;
                    if (cmbKomponenTarif.Enabled)
                    {
                        cmbKomponenTarif.Focus();
                    }
                    btnDaftarKompTarif.Enabled = true;
                    txtNamaDokter.Enabled = true;
                    btnTambahKompDokter.Enabled = true;
                    btnTambahTindakan.Enabled = true;
                    btnBatalTindakan.Enabled = true;

                }
            }
        }

        private void inputTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtTempatLayanan_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }            
        }       

        private void btnTampilDaftarTindakan_Click(object sender, EventArgs e)
        {
           
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

            String[] strSplitKode = Regex.Split(txtKodeTindakan.Text, "--");

            string strKodeTindakan = strSplitKode[0].Trim().ToString();
            string strUraianTindakan = strSplitKode[1].Trim().ToString();

            fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];

            if (!isProsesUpdate)
            {
                /* MASUKKAN PER TINDAKAN */
                lstDaftarTindakan itemTindakan = new lstDaftarTindakan();
                itemTindakan.strKodeTarif = strKodeTindakan;
                itemTindakan.intNoUrut = intUrutanTrans;
                itemTindakan.strUraianTarif = strUraianTindakan;
                itemTindakan.dblBiaya = Convert.ToDouble(lblBiayaTindakan.Text);
                itemTindakan.strTempatLayanan = txtTempatLayanan.Text;
                itemTindakan.intIdTempatLayanan = Convert.ToInt32(strIdMR_TempatLayanan);
                itemTindakan.dtTgl = dtpTglTindakan.Value;
                int intResult = data.grpLstDaftarTarif.FindIndex(m => m.strKodeTarif == strKodeTindakan);
                itemTindakan.strTSMFTindakan = data.grpLstDaftarTarif[intResult].strSMF;
                itemTindakan.intUrutanTindakan = intUrutanTindakan;
                /*increment for identified every input kode for twice..*/
                grpLstDaftarTindakan.Add(itemTindakan);
                /* EOF MASUKKAN PER TINDAKAN */

                foreach (lstDaftarKomponenTarif x in grpLstTempTindakanDetail)
                {
                    lstDaftarKomponenTarif itemKomponenTarif = new lstDaftarKomponenTarif();
                    itemKomponenTarif.strKodeTarif = x.strKodeTarif;
                    itemKomponenTarif.strId_Komponen = x.strId_Komponen;
                    itemKomponenTarif.dblByKomponen = x.dblByKomponen;
                    itemKomponenTarif.dblHak1 = x.dblHak1;
                    itemKomponenTarif.dblHak2 = x.dblHak2;
                    itemKomponenTarif.dblHak3 = x.dblHak3;
                    itemKomponenTarif.intPrioritasTunai = x.intPrioritasTunai;
                    itemKomponenTarif.intNoUrut = x.intNoUrut;
                    itemKomponenTarif.strKodeDokter = x.strKodeDokter;
                    itemKomponenTarif.strNamaDokter = x.strNamaDokter;
                    itemKomponenTarif.intUrutanDetailTindakan = intUrutanTindakanDetail;
                    itemKomponenTarif.intUrutanTindakan = intUrutanTindakan;
                    grpLstDaftarTindakanDetail.Add(itemKomponenTarif);
                    intUrutanTindakanDetail++;
                }
                intUrutanTindakan++;
            }
            else
            {
                //jika yang dilakukan adalah proses update...
                int intResult = grpLstDaftarTindakanDetail.FindIndex(m => m.intUrutanDetailTindakan == intIDDetailTindakanUpdate);

                string strKodeNamaDokter = txtNamaDokter.Text.Trim().ToString();
                string strKodeDokter = "";
                string strNamaDokter = "";

                if (strKodeNamaDokter.Trim().ToString() != "")
                {
                    strSplitKode = Regex.Split(txtNamaDokter.Text, "--");
                    strKodeDokter = strSplitKode[0].Trim().ToString();
                    strNamaDokter = strSplitKode[1].Trim().ToString();
                }
                grpLstDaftarTindakanDetail[intResult].strKodeDokter = strKodeDokter;
                grpLstDaftarTindakanDetail[intResult].strNamaDokter = strNamaDokter;
                btnTambahTindakan.Text = "&TAMBAH TINDAKAN";
            }

            #region CODE STATUS : NEED REVIEW LATER
            //grpLstTempTindakanDetail.Clear();

            //int intUrutanLV = 1;
            //int intUrutanTemp = 0;

            //lvDaftarTindakan.Items.Clear();

            //grpLstDaftarTindakanDetail.ForEach(
            //    delegate(lstDaftarKomponenTarif x)
            //    {
            //        if (intUrutanTemp != x.intUrutanTindakan)
            //        {
            //            lvDaftarTindakan.Items.Add((intUrutanLV.ToString()).ToString());
            //            intUrutanLV++;
            //        }
            //        else
            //            lvDaftarTindakan.Items.Add("");
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.strKodeTarif.ToString());
            //        int intx = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == x.strKodeTarif);
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                grpLstDaftarTindakan[intx].strUraianTarif);
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.strId_Komponen.ToString());
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.dblByKomponen.ToString());
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.strKodeDokter + " -- " + x.strNamaDokter);
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.intUrutanDetailTindakan.ToString());
            //        lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
            //                x.intUrutanTindakan.ToString());
            //        intUrutanTemp = x.intUrutanTindakan;

                    
            //    });           

            //modSQL.pvAutoResizeLV(lvDaftarTindakan, 6);
            #endregion

            this.pvLoadLV();

            intUrutanTrans++;
            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            
            lvDaftarTindakan.HideSelection = false;
            grpLstTempTindakanDetail.Clear();
            isProsesUpdate = false;

            txtKodeTindakan.Text = "";
            txtKodeTindakan.Enabled = true;
            txtKodeTindakan.Focus();
            btnTampilDaftarTarif.Enabled = true;

            cmbKomponenTarif.SelectedIndex = -1;
            cmbKomponenTarif.Enabled = false;
            cmbKomponenTarif.Items.Clear();
            btnDaftarKompTarif.Enabled = false;
            txtNamaDokter.Text = "";
            txtNamaDokter.Enabled = false;
            btnTambahKompDokter.Enabled = false;

            btnTambahTindakan.Enabled = false;
            btnBatalTindakan.Enabled = false;
        }

        private void txtTempatLayanan_Leave(object sender, EventArgs e)
        {
            if (txtTempatLayanan.Text != "")
            {
                int intResultSearch = data.grpLstTempatLayanan.FindIndex(m => m.strKodeRuang == txtTempatLayanan.Text);
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

                int intResultSearch = data.grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == lblRuangan.Text);
                if (intResultSearch == -1)
                    txtTempatLayanan.Text = lblRuangan.Text;
                else
                    txtTempatLayanan.Text = data.grpLstTempatLayanan[intResultSearch].strKodeRuang;

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
                //grpLstDaftarKomponenTarif.Clear();
                this.pvCleanInput();
                this.pvDisableInput();
                MessageBox.Show("Data sudah berhasil dimasukkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lvDaftarTindakan_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (lvDaftarTindakan.Items.Count > 0))
            {
                cmsDaftarTindakan.Show(this.lvDaftarTindakan, e.Location);

                if (isProsesUpdate)
                {
                    rubahToolStripMenuItem.Enabled = false;
                    hapusToolStripMenuItem.Enabled = false;
                }
                else
                {
                    rubahToolStripMenuItem.Enabled = true;
                    hapusToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void lvDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string strNoUrut = lvDaftarTindakan.SelectedItems[0].SubItems[5].Text;
            //string strKodeTarif = lvDaftarTindakan.SelectedItems[0].SubItems[1].Text;
            //this.pvHapusList(strKodeTarif, strNoUrut);
        }

        private void lvDaftarTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult msgbox = MessageBox.Show("Apakah anda akan menghapus daftar ?", "Informasi",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgbox == DialogResult.No)
                    return;

                int intIDDetailTindakanHapus = Convert.ToInt32(lvDaftarTindakan.SelectedItems[0].SubItems[7].Text);
                int intResult = grpLstDaftarTindakan.RemoveAll(m => m.intUrutanTindakan == intIDDetailTindakanHapus);
                intResult = grpLstDaftarTindakanDetail.RemoveAll(m => m.intUrutanTindakan == intIDDetailTindakanHapus);
                this.pvLoadLV();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSimpanIsiTindakan.Focus();
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

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {

            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);
            
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);

            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            string strNoBilling = "";
            txtNoBilling.SafeControlInvoke(TextBox => strNoBilling = txtNoBilling.Text.Trim().ToString() );


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
                                    "MR_MUTASIPASIEN.tanggal_mrs, " +            //9
                                    "MR_MUTASIPASIEN.idMr_Subsistem " +            //10
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
                                    "AND MR_MUTASIPASIEN.regbilling = '" + strNoBilling + "'";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();

                string strSubSistem = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                //string strKelas = modMain.pbstrgetCol(reader, 6, ref strErr, "");

                //MessageBox.Show(strKelas.ToString());

                if (strSubSistem.Trim().ToString() != "PAV")
                {

                    //timerBlink.Stop();
                    //timerBlink.Enabled = false;
                    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                    txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                    MessageBox.Show("Pengentrian Tindakan ini hanya untuk Pasien Instalasi Pelayanan Utama (IPU)", 
                                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    reader.Close();
                    conn.Close();
                    return;
                }

                lblMRPasien.SafeControlInvoke(Label => lblMRPasien.Text = modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                lblAlamatPasien.SafeControlInvoke(Label => lblAlamatPasien.Text = modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                lblRuangan.SafeControlInvoke(Label => lblRuangan.Text = modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                lblKelas.SafeControlInvoke(Label => lblKelas.Text = modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                lblStatusPasien.SafeControlInvoke(Label => lblStatusPasien.Text = modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                lblNamaPasien.SafeControlInvoke(Label => lblNamaPasien.Text = modMain.pbstrgetCol(reader, 0, ref strErr, ""));

                strIdMR_TempatLayanan = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                strIdMutasiPasien = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                strIdMR_TRuangan = modMain.pbstrgetCol(reader, 4, ref strErr, "");

                this.pvEnableInput();
                dtpTglTindakan.SafeControlInvoke(DateTimePicker => dtpTglTindakan.Focus());
                //btnKeluarIsiTindakan.SafeControlInvoke(Button => btnKeluarIsiTindakan.Text = "&BATAL");
            }
            else
            {

                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }


            conn.Close();

            //timerBlink.Stop();
            //timerBlink.Enabled = false;
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            if (lblInfoPencarian.ForeColor == Color.Black)
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.ForeColor = Color.Red);
            else
                lblInfoPencarian.SafeControlInvoke(Label =>  lblInfoPencarian.ForeColor = Color.Black);

        }

        private void bgWorkLoadDataInit_DoWork(object sender, DoWorkEventArgs e)
        {
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "");
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            SqlDataReader reader = null;

            if (data.grpLstTempatLayanan.Count <= 0)
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "LOADING DATA RUANGAN dari SERVER");

                this.strQuerySQL = "SELECT " +
                                      "ruangan, " +
                                      "idmr_truangan " +
                                  "FROM MR_TRUANGAN WITH (NOLOCK) " +
                                  "WHERE dipakai = 'Y' and SUBSTRING(ruangan,1,1) <> '-' " +
                                  "ORDER BY ruangan";
                reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    conn.Close();
                    return;
                }

                listTempatLayanan.Clear();
                data.grpLstTempatLayanan.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listTempatLayanan.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                        data.lstTempatLayanan itemTempatLayanan = new data.lstTempatLayanan();
                        itemTempatLayanan.strNamaRuang = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                        itemTempatLayanan.strKodeRuang = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                        data.grpLstTempatLayanan.Add(itemTempatLayanan);
                    }
                }

                reader.Close();
            }
            else
            {
                foreach (data.lstTempatLayanan x in data.grpLstTempatLayanan)
                {
                    listTempatLayanan.Add(x.strKodeRuang);
                }
            }

            txtTempatLayanan.SafeControlInvoke( TextBox => txtTempatLayanan.AutoCompleteCustomSource = listTempatLayanan);
            txtTempatLayanan.SafeControlInvoke( TextBox => txtTempatLayanan.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtTempatLayanan.SafeControlInvoke( TextBox => txtTempatLayanan.AutoCompleteSource = AutoCompleteSource.CustomSource);            

            if (data.grpLstDaftarDokter.Count <= 0)
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "LOADING DATA DOKTER dari SERVER");
                this.strQuerySQL = "SELECT " +
                                    "MR_DOKTER.idmr_dokter, " +                 //0
                                    "MR_DOKTER.nama, " +                        //1
                                    "MR_DOKTER.idmr_tsmf " +                    //2
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
                data.grpLstDaftarDokter.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listDokter.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                        data.lstDaftarDokter itemDaftarDokter = new data.lstDaftarDokter();
                        itemDaftarDokter.strKodeDokter = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                        itemDaftarDokter.strNamaDokter = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                        itemDaftarDokter.strNamaDokter = itemDaftarDokter.strNamaDokter.Trim().ToString();
                        itemDaftarDokter.strSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                        data.grpLstDaftarDokter.Add(itemDaftarDokter);
                    }
                }
                reader.Close();
            }
            else
            {
                foreach (data.lstDaftarDokter x in data.grpLstDaftarDokter)
                {
                    listDokter.Add(x.strKodeDokter + " -- " + x.strNamaDokter); 
                }
            }

            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteCustomSource = listDokter);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource);

            if (data.grpLstDaftarTarif.Count <= 0)
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "AMBIL DAFTAR TARIF dari SERVER");
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
                data.grpLstDaftarTarif.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listTarif.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                        data.lstDaftarTarif itemDaftarTarif = new data.lstDaftarTarif();
                        itemDaftarTarif.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                        itemDaftarTarif.strUraianTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                        itemDaftarTarif.dblBiaya = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                        itemDaftarTarif.strSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                        data.grpLstDaftarTarif.Add(itemDaftarTarif);

                    }
                }
                reader.Close();
            }
            else
            {
                foreach (data.lstDaftarTarif x in data.grpLstDaftarTarif)
                {
                    listTarif.Add(x.strKodeTarif + " -- " + x.strUraianTarif);
                }
            }
            txtKodeTindakan.SafeControlInvoke(TextBox => txtKodeTindakan.AutoCompleteCustomSource = listTarif);
            txtKodeTindakan.SafeControlInvoke(TextBox => txtKodeTindakan.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtKodeTindakan.SafeControlInvoke(TextBox => txtKodeTindakan.AutoCompleteSource = AutoCompleteSource.CustomSource);

            #region CODE STATUS : NEED REVIEW LATER
            ///* CEK DAFTAR JUMLAH TARIF */
            //double dblJumlahTarifDetailDB = 0;
            //double dblJumlahTarifDetailLocal = 0;

            ///*DATABASE SQL SERVER*/
            //strQuerySQL = "SELECT COUNT(idbl_tarip) " +
            //              "FROM BL_KOMPTARIP";
            //reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            //if (strErr != "")
            //{
            //    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
            //    conn.Close();
            //    return;
            //}
            //if (reader.HasRows)
            //{
            //    reader.Read();
            //    dblJumlahTarifDetailDB = Convert.ToDouble(modMain.pbstrgetCol(reader, 0, ref strErr, ""));
            //}
            //reader.Close();

            ///*DATABASE SQLITE*/
            //strQuerySQL = "SELECT COUNT(idbl_tarif) " +
            //              "FROM BL_KOMPTARIF";

            //commandLite = new SQLiteCommand(strQuerySQL, m_dbConnection);
            //readerLite = commandLite.ExecuteReader();
            //if (readerLite.HasRows)
            //{
            //    readerLite.Read();
            //    dblJumlahTarifDetailLocal = Convert.ToDouble(readerLite[0].ToString());
            //}
            //readerLite.Close();
            ///* EOF CEK DAFTAR JUMLAH TARIF */

            //if (dblJumlahTarifDetailDB != dblJumlahTarifDetailLocal)
            //{
            //    isSyncDB = true;
                
            //    /* DELETE FIRST BEFORE INSERT */
            //    this.strQuerySQL = "DELETE FROM BL_KOMPTARIF";
            //    SQLiteCommand command = new SQLiteCommand(strQuerySQL, m_dbConnection);
            //    command.ExecuteNonQuery();
            //}

            //if (isSyncDB)
            //{

            //    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "AMBIL DAFTAR KOMPONEN TARIF SERVER");
            //    grpLstDaftarLengkapKomponenTarif.Clear();
            //    this.strQuerySQL = "SELECT " +
            //                            "idbl_tarip, " +        //0
            //                            "idbl_komponen, " +      //1
            //                            "bykomponen, " +         //2
            //                            "Hak1, " +               //3
            //                            "Hak2, " +               //4
            //                            "Hak3, " +               //5
            //                            "PrioritasTunai " +      //6
            //                        "FROM BL_KOMPTARIP";
            //    reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            //    if (strErr != "")
            //    {
            //        modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
            //        conn.Close();
            //        return;
            //    }


            //    if (reader.HasRows)
            //    {

            //        int intTemp = 1;

            //        this.strQuerySQL = "INSERT INTO BL_KOMPTARIF (" +
            //                                   "idbl_tarif, " +
            //                                   "idbl_komponen, " +
            //                                   "bykomponen, " +
            //                                   "Hak1, " +
            //                                   "Hak2, " +
            //                                   "Hak3, " +
            //                                   "PrioritasTunai) " +
            //                               "VALUES ( "+
            //                                    "@idbl_tarif, "+
            //                                    "@idbl_komponen, "+
            //                                    "@bykomponen, "+
            //                                    "@Hak1, "+
            //                                    "@Hak2, "+
            //                                    "@Hak3, "+
            //                                    "@PrioritasTunai)";

            //        SQLiteCommand command = m_dbConnection.CreateCommand();
            //        command.CommandText = strQuerySQL;
            //        SQLiteTransaction transaction = m_dbConnection.BeginTransaction();

            //        command.Parameters.AddWithValue("@idbl_tarif", "");
            //        command.Parameters.AddWithValue("@idbl_komponen", "");
            //        command.Parameters.AddWithValue("@bykomponen", "");
            //        command.Parameters.AddWithValue("@Hak1", "");
            //        command.Parameters.AddWithValue("@Hak2", "");
            //        command.Parameters.AddWithValue("@Hak3", "");
            //        command.Parameters.AddWithValue("@PrioritasTunai", "");

            //        while (reader.Read())
            //        {

            //            lstDaftarKomponenTarif itemKomponenTarif = new lstDaftarKomponenTarif();
            //            itemKomponenTarif.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
            //            itemKomponenTarif.strId_Komponen = modMain.pbstrgetCol(reader, 1, ref strErr, "");
            //            itemKomponenTarif.dblByKomponen = Convert.ToDouble(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
            //            itemKomponenTarif.dblHak1 = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
            //            itemKomponenTarif.dblHak2 = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
            //            itemKomponenTarif.dblHak3 = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
            //            itemKomponenTarif.intPrioritasTunai = Convert.ToInt32(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
            //            itemKomponenTarif.strKodeDokter = "";
            //            itemKomponenTarif.strNamaDokter = "";
            //            itemKomponenTarif.intNoUrut = intUrutanTrans;
            //            grpLstDaftarLengkapKomponenTarif.Add(itemKomponenTarif);

            //            /* SAVE FROM SQLSERVER TO SQLITE */
            //            command.Parameters["@idbl_tarif"].Value = itemKomponenTarif.strKodeTarif;
            //            command.Parameters["@idbl_komponen"].Value = itemKomponenTarif.strId_Komponen;
            //            command.Parameters["@bykomponen"].Value = itemKomponenTarif.dblByKomponen;
            //            command.Parameters["@Hak1"].Value = itemKomponenTarif.dblHak1;
            //            command.Parameters["@Hak2"].Value = itemKomponenTarif.dblHak2;
            //            command.Parameters["@Hak3"].Value = itemKomponenTarif.dblHak3;
            //            command.Parameters["@PrioritasTunai"].Value = itemKomponenTarif.intPrioritasTunai;
            //            command.ExecuteNonQuery();

            //            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "INSERT DATA KOMPONEN TARIF : " + intTemp.ToString());
            //            intTemp++;

                        
            //        }

            //        transaction.Commit();
            //        command.Dispose();
            //    }
            //    reader.Close();
            //}
            //else
            //{

            //    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "AMBIL DAFTAR KOMPONEN TARIF LOCAL");

            //    /*READ ON LOCAL DB*/
            //    strQuerySQL = "SELECT idbl_tarif, " +        //0
            //                         "idbl_komponen, " +       //1
            //                         "bykomponen, " +         //2
            //                         "Hak1, " +              //3 " +
            //                         "Hak2, " +
            //                         "Hak3, " +
            //                         "PrioritasTunai " +
            //                  "FROM BL_KOMPTARIF";

            //    commandLite = new SQLiteCommand(strQuerySQL, m_dbConnection);
            //    readerLite = commandLite.ExecuteReader();
            //    if (readerLite.HasRows)
            //    {
            //        while (readerLite.Read())
            //        {
            //            lstDaftarKomponenTarif itemKomponenTarif = new lstDaftarKomponenTarif();
            //            itemKomponenTarif.strKodeTarif = readerLite[0].ToString();
            //            itemKomponenTarif.strId_Komponen = readerLite[1].ToString();
            //            itemKomponenTarif.dblByKomponen = Convert.ToDouble(readerLite[2].ToString());
            //            itemKomponenTarif.dblHak1 = Convert.ToDouble(readerLite[3].ToString());
            //            itemKomponenTarif.dblHak2 = Convert.ToDouble(readerLite[4].ToString());
            //            itemKomponenTarif.dblHak3 = Convert.ToDouble(readerLite[5].ToString());
            //            itemKomponenTarif.intPrioritasTunai = Convert.ToInt32(readerLite[6].ToString());
            //            itemKomponenTarif.strKodeDokter = "";
            //            itemKomponenTarif.strNamaDokter = "";
            //            itemKomponenTarif.intNoUrut = intUrutanTrans;
            //            grpLstDaftarLengkapKomponenTarif.Add(itemKomponenTarif);
            //        }

            //    }
            //    readerLite.Close();

            //}
            #endregion

            conn.Close();

            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "");
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Focus());
        }

        private void btnBatalTindakan_Click(object sender, EventArgs e)
        {
            txtKodeTindakan.Text = "";
            txtKodeTindakan.Enabled = true;

            cmbKomponenTarif.SelectedIndex = -1;
            cmbKomponenTarif.Items.Clear();
            cmbKomponenTarif.Enabled = false;

            btnDaftarKompTarif.Enabled = false;
            txtNamaDokter.Text = "";
            txtNamaDokter.Enabled = false;

            btnTambahKompDokter.Enabled = false;
            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            
            btnTambahTindakan.Text = "&TAMBAH TINDAKAN";
            btnTambahTindakan.Enabled = false;
            btnBatalTindakan.Enabled = false;

            grpLstTempTindakanDetail.Clear();
            txtKodeTindakan.Focus();

            isProsesUpdate = false;
            intUrutanTrans = 0;
        }

        private void btnTambahKompDokter_Click(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() != "") //jika kode tindakan yang di isi saja yang diproses...
            {
                if (txtKodeTindakan.Text.Trim().ToString() == "JASA SARANA")
                {
                    MessageBox.Show("Tidak bisa menambahkan Komponen JASA SARANA dengan Dokter", 
                                    "Informasi", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                    return;
                }

                string strKodeNama = txtNamaDokter.Text.Trim().ToString();

                string strKodeDokter = "";
                string strNamaDokter = "";

                String[] strSplitKode = null;

                /*
                 * 1. aturan pertama hanya tindakan yang satu smf dengan dokter tersebut yang bisa di inputkan oleh para penata rekening.
                 * 2. aturan kedua jika tindakan di OK-IRD maka dokter yang berlabel OK DAR. dan OK DARURAT saja yang bisa dimasukkan
                 *    oleh penata rekening.
                 */

                if ((strKodeNama != "") && (!boolBypassDokter))
                {
                    strSplitKode = Regex.Split(strKodeNama, "--");
                    strKodeDokter = strSplitKode[0].Trim().ToString();
                    strNamaDokter = strSplitKode[1].Trim().ToString();

                    int intPencarianDokter = data.grpLstDaftarDokter.FindIndex( m => m.strKodeDokter == strKodeDokter);

                    if (intPencarianDokter != -1)
                    {
                        strNamaDokter = data.grpLstDaftarDokter[intPencarianDokter].strNamaDokter;
                        strSMFDokter = data.grpLstDaftarDokter[intPencarianDokter].strSMF;

                        #region CODE STATUS : NEED REVIEW LATER
                        /////* Filter jika bukan pelayanan OK-IRD harus dicek tindakan harus sesuai dengan SMF dokter*/
                        //if (txtTempatLayanan.Text.Trim().ToString() != "OK-IRD") // Fitur Kelas 1
                        //{
                        //    /* UNTUK KELAS SATU DIRUANGAN DIPROSES DISINI */
                        //    /* MUNGKIN UNTUK PAVILIUN JUGA DISINI. Sesuai dengan tindakan dan SMF Dokter. */

                        //    /*Kode tindakan harus sesuai dengan kode pada SMF dokter tersebut//*/
                        //    if (strSMFDokter.Trim().ToString() != strSMFTindakan.Trim().ToString())
                        //    {
                        //        MessageBox.Show("Pengisian Kode Dokter harus sesuai Kode Tindakan pada SMF Dokter tersebut",
                        //                  "Informasi",
                        //                  MessageBoxButtons.OK,
                        //                  MessageBoxIcon.Information);
                        //        txtNamaDokter.Focus();
                        //        return;
                        //    }
                        //}
                        //else // Fitur Kelas 1 dan belum tahu apakah OK-PAV akan diperlakukan seperti ini juga.
                        //{
                        //    /*OK DAR.*/
                        //    //MUNGKIN AKAN DIPERLAKUKAN FILTER SEPERTI DI OK DARURAT, SEKARANG DI OK PAVILIUN.

                        //    string strChar = strSMFTindakan.Trim().Substring(6, 1).ToString();

                        //    string strNamaSMFTindakan = "";
                        //    if (strChar == ".")
                        //    {
                        //        /*OK DAR*/
                        //        strNamaSMFTindakan = strSMFTindakan.Trim().Substring(13, (strSMFTindakan.Length - 13));

                        //        /*ADDED bedah for matches from master*/
                        //        strNamaSMFTindakan = "BEDAH " + strNamaSMFTindakan;
                        //    }
                        //    else
                        //    {
                        //        /*OK DARURAT*/
                        //        strNamaSMFTindakan = strSMFTindakan.Trim().Substring(10, (strSMFTindakan.Length - 10));
                        //    }

                        //    if (strNamaSMFTindakan.Trim().ToString() != strSMFDokter.Trim().ToString())
                        //    {
                        //        MessageBox.Show("Pengisian Kode Dokter harus sesuai Kode Tindakan pada SMF Dokter tersebut",
                        //                  "Informasi",
                        //                  MessageBoxButtons.OK,
                        //                  MessageBoxIcon.Information);
                        //        txtNamaDokter.Focus();
                        //        return;
                        //    } /* EOF dari if (strNamaSMFTindakan.Trim().ToString() != strSMFDokter.Trim().ToString()) */
                        //} /* EOF dari if (txtTempatLayanan.Text.Trim().ToString() != "OK-IRD")*/
                        #endregion

                    } /* EOF dari if (intResultSearchDoctor != -1) */
                    else
                    {
                        MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                      "Informasi",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        txtNamaDokter.Focus();
                        return;
                    }/* EOF dari if (intResultSearchDoctor != -1) */

                } /* EOF  if ((strKodeNama != "") && (!boolBypassDokter)) */

                //bool isSelainJS = false; //digunakan untuk mengecek ada tindakan selain Jasa Sarana
                int intUrut = 0;
                string strKomponenTarif = cmbKomponenTarif.Text.Trim().ToString();
                cmbKomponenTarif.Items.Clear();

                //int intresult;

                foreach (lstDaftarKomponenTarif x in grpLstTempTindakanDetail)
                {
                    if (x.strId_Komponen.Trim().ToString() == strKomponenTarif)
                    {
                        grpLstTempTindakanDetail[intUrut].strKodeDokter = strKodeDokter;
                        grpLstTempTindakanDetail[intUrut].strNamaDokter = strNamaDokter;
                        cmbKomponenTarif.Items.Add(x.strId_Komponen);
                    }
                    else
                    {
                        if(x.strId_Komponen.Trim().ToString() != "JASA SARANA")
                            cmbKomponenTarif.Items.Add(x.strId_Komponen);

                        //if (x.strId_Komponen.Trim().ToString() != "JASA SARANA")
                        //    isSelainJS = true;
                    }

                    intUrut++;;
                }

                txtNamaDokter.Text = "";

                //if (isSelainJS) //jika masih ada komponen selain jasa sarana, harusnya diperlukan entry dokter lagi..               
                //{
                //    cmbKomponenTarif.Focus();
                //}

                //txtKodeTindakan.Focus();

            } /* EOF if (txtKodeTindakan.Text.Trim().ToString() != "")*/
        }

        private void btnKomponenTarif_Click(object sender, EventArgs e)
        {
            daftarKomponenPerTarif newForm = new daftarKomponenPerTarif();
            newForm.ShowDialog();
        }

        private void btnTampilDaftarTarif_Click(object sender, EventArgs e)
        {
            daftarTindakan fDaftarTindakan = new daftarTindakan();
            fDaftarTindakan.ShowDialog();
        }

        private void btnTampilDaftarTarif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                daftarTindakan fDaftarTindakan = new daftarTindakan();
                fDaftarTindakan.ShowDialog();
            }
        }

        private void cmbKomponenTarif_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cmbKomponenTarif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNamaDokter.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void rubahToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvDaftarTindakan.SelectedItems[0].SubItems[3].Text.ToUpper().Trim().ToString() == "JASA SARANA")
            {
                MessageBox.Show("Tidak bisa merubah Komponen JASA SARANA dengan dokter","Informasi",
                                MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            isProsesUpdate = true;
            intIDDetailTindakanUpdate = Convert.ToInt32(lvDaftarTindakan.SelectedItems[0].SubItems[6].Text);
            int intResult = grpLstDaftarTindakanDetail.FindIndex(m => m.intUrutanDetailTindakan == intIDDetailTindakanUpdate);            
            txtKodeTindakan.Enabled = false;
            string strKodeTarif = grpLstDaftarTindakanDetail[intResult].strKodeTarif;
            int intResult2 = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == strKodeTarif);
            txtKodeTindakan.Text = grpLstDaftarTindakanDetail[intResult].strKodeTarif + " -- " +
                                    grpLstDaftarTindakan[intResult2].strUraianTarif;            
            lblDeskripsiTindakan.Text = grpLstDaftarTindakan[intResult2].strUraianTarif;
            lblBiayaTindakan.Text = grpLstDaftarTindakan[intResult2].dblBiaya.ToString();
            cmbKomponenTarif.Items.Clear();
            cmbKomponenTarif.Items.Add(grpLstDaftarTindakanDetail[intResult].strId_Komponen);
            cmbKomponenTarif.SelectedIndex = 0;
            cmbKomponenTarif.Enabled = false;
            btnTampilDaftarTarif.Enabled = false;
            btnDaftarKompTarif.Enabled = false;
            btnTambahKompDokter.Enabled = false;
            txtNamaDokter.Text = grpLstDaftarTindakanDetail[intResult].strKodeDokter + " -- " +
                                    grpLstDaftarTindakanDetail[intResult].strNamaDokter;
            txtNamaDokter.Enabled = true;
            btnTambahTindakan.Text = "&UPDATE TINDAKAN";
            btnTambahTindakan.Enabled = true;
            btnBatalTindakan.Enabled = true;
        }     

        private void hapusToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DialogResult msgbox = MessageBox.Show("Apakah anda akan menghapus daftar ?", "Informasi", 
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgbox == DialogResult.No)
                return;

            int intIDDetailTindakanHapus = Convert.ToInt32(lvDaftarTindakan.SelectedItems[0].SubItems[7].Text);
            int intResult = grpLstDaftarTindakan.RemoveAll(m => m.intUrutanTindakan == intIDDetailTindakanHapus);
            intResult = grpLstDaftarTindakanDetail.RemoveAll(m => m.intUrutanTindakan == intIDDetailTindakanHapus);
            this.pvLoadLV();
        }

        private void cmsDaftarTindakan_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmbKomponenTarif_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isDataAda = false;
            foreach (lstDaftarKomponenTarif x in grpLstTempTindakanDetail)
            {
                if ((x.strKodeDokter.Trim().ToString() != "")
                    && (x.strId_Komponen.Trim().ToString() == cmbKomponenTarif.Text))
                {
                    txtNamaDokter.Text = x.strKodeDokter + " -- " + x.strNamaDokter;
                    isDataAda = true;
                }
            }

            if (!isDataAda)
            {
                txtNamaDokter.Text = "";
            }

        } 

      
    } /*EOF*/
}
