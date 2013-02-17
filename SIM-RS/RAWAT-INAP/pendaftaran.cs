using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIM_RS.RAWAT_INAP
{
    public partial class pendaftaran : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /* PRIVATE VARIABLE */

        string strQuerySQL = "";
        string strErr = "";

        bool isUpdateData = false;

        string strNoRMPasien = "";



        /* EOF PRIVATE VARIABLE*/

        /* PRIVATE FUNCTION */


        /*
     *  NAME        : pvSimpanDataPasien
     *  FUNCTION    : a group saving process to a database with transaction method.
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 16-02-2013
     */
        private void pvSimpanDataPasien()
        {

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            SqlTransaction trans = conn.BeginTransaction();


            /* CREATE AUTONUMBERING MEDICAL RECORD AND TRANSACTION */


            /* INSERTING PATIENT DATA TO DATABASE */
            this.strQuerySQL = "INSERT MR_PASIEN ( "+
                                    "idmr_pasien, "+
                                    "nama, "+
                                    "alamat, "+
                                    "telp, "+
                                    "kelurahan, "+
                                    "kecamatan, "+
                                    "kabupaten, "+
                                    "kodya, "+
                                    "propinsi, "+
                                    "tanggal_lahir, "+
                                    "jenis_kelamin, "+
                                    "statusperkawinan, "+
                                    "bangsa, "+
                                    "agama, "+
                                    "idmr_pendidikan, "+
                                    "idmr_pekerjaan, "+
                                    "kota, "+
                                    "suku, "+
                                    "tglreg, "+
                                    "KartuIdentitas, "+
                                    "batal) "+
                               "VALUES ()";

            modDb.pbWriteSQLTrans(conn, strQuerySQL, ref strErr, trans);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                trans.Rollback();
                conn.Close();
                return;
            }



            trans.Commit();
            conn.Close();

        }

        /*
    *  NAME        : pvLoadDataSosialPasien
    *  FUNCTION    : displaying data from database to textbox
    *  RESULT      : -
    *  CREATED     : Eka Rudito (eka@rudito.web.id)
    *  DATE        : 16-02-2013
    */
        private void pvLoadDataSosialPasien(
                string _strNama,             
                string _strAlamat,          
                string _strTelp,            
                string _strKelurahan, 
                string _strKecamatan, 
                string _strKabupaten, 
                string _strKota,              
                string _strPropinsi, 
                string _strJenisKelamin, 
                string _strSuku, 
                string _strStatusPerkawinan, 
                string _strBangsa, 
                string _strAgama, 
                string _strPendidikan, 
                string _strPekerjaan, 
                string _strTglLahir, 
                string _strKartuIdentitas )
        {
            txtPasienNama.Text = _strNama;
            txtPasienAlamat.Text = _strAlamat;
            txtPasienTelp.Text = _strTelp;
            txtPasienKelurahan.Text = _strKelurahan;
            txtPasienKecamatan.Text = _strKecamatan;
            txtPasienKab.Text = _strKabupaten;
            txtPasienKota.Text = _strKota;
            txtPasienProp.Text = _strPropinsi;
            cmbPasienJK.Text = _strJenisKelamin;
            txtPasienSuku.Text = _strSuku;
            cmbPasienStatKawin.Text = _strStatusPerkawinan;
            txtPasienKebangsaan.Text = _strBangsa;
            cmbPasienAgama.Text = _strAgama;
            cmbPasienStatPend.Text = _strPendidikan;
            cmbPasienPekerjaan.Text = _strPekerjaan;

            /* DATE FORMAT FROM DATABASE dd-MM-yyyy, CONVERT TO DATETIMEPICKER {FIXME} */
            //dtpPasienTglLahir.Value = Convert.ToDateTime(_strTglLahir);
            txtPasienKartuIden.Text = _strKartuIdentitas;

        }

        /*
          *  NAME        : pvDisableInput
          *  FUNCTION    : disable input to all textbox,combobox
          *  RESULT      : -
          *  CREATED     : Eka Rudito (eka@rudito.web.id)
          *  DATE        : 16-02-2013
          */
        private void pvDisableInput()
        {

            txtPasienRM.Enabled = true;
            txtPasienNama.Enabled = false;
            txtPasienAlamat.Enabled = false;
            txtPasienTelp.Enabled = false;
            txtPasienKelurahan.Enabled = false;
            txtPasienKecamatan.Enabled = false;
            txtPasienKota.Enabled = false;
            txtPasienKab.Enabled = false;
            txtPasienProp.Enabled = false;
            cmbPasienJK.Enabled = false;
            cmbPasienStatKawin.Enabled = false;
            cmbPasienStatPend.Enabled = false;
            cmbPasienPekerjaan.Enabled = false;
            cmbPasienAgama.Enabled = false;
            txtPasienSuku.Enabled = false;
            txtPasienKebangsaan.Enabled = false;
            txtPasienKartuIden.Enabled = false;
            dtpPasienTglLahir.Enabled = false;
            txtPasienUmurThn.Enabled = false;
            txtPasienUmurBln.Enabled = false;
            txtPasienUmurHr.Enabled = false;
               
              



        }

        /*
         *  NAME        : pvEnableInput
         *  FUNCTION    : disable input to all textbox,combobox
         *  RESULT      : -
         *  CREATED     : Eka Rudito (eka@rudito.web.id)
         *  DATE        : 16-02-2013
         */
        private void pvEnableInput()
        {

            txtPasienRM.Enabled = true;
            txtPasienNama.Enabled = false;


        }

        /* EOF PRIVATE FUNCTION */


        public pendaftaran()
        {
            InitializeComponent();
        }

        private void pendaftaran_Load(object sender, EventArgs e)
        {

        }

        private void txtPasienRM_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if pressed enter*/
            if (e.KeyChar != 13)
            {
                return;
            }
                
            /* if user not fill patient RM / new registration */
            if (txtPasienRM.Text.Trim().ToString() == "")
            {

                DialogResult msgDlg = MessageBox.Show("No Rekam Medik kosong, Apakah melakukan pendaftaran Baru ?",
                                                        "Konfirmasi",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                if (msgDlg == System.Windows.Forms.DialogResult.Yes)
                {
                    isUpdateData = false;
                }


            }
            else
            {
                /* if user fill patient RM */
                C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;
                SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    return;
                }

                strNoRMPasien = txtPasienRM.Text.Trim().ToString();

                this.strQuerySQL = "SELECT " +
                                        "IDMR_PASIEN, " +           //0
                                        "Nama, " +                  //1     x1
                                        "Alamat, " +                //2     x2
                                        "Telp, " +                  //3     x3
                                        "Kelurahan, " +             //4     x4
                                        "Kecamatan, " +             //5     x5
                                        "Kabupaten, " +             //6     x6
                                        "Kota, "+                   //7     x7
                                        "Kodya, "+                  //8
                                        "Propinsi, "+               //9     x8
                                        "JenisKelamin, "+           //10    x9
                                        "Suku, "+                   //11    x10
                                        "StatusPerkawinan, "+       //12    x11
                                        "Bangsa, "+                 //13    x12
                                        "Agama, "+                  //14    x13
                                        "IDMR_PENDIDIKAN, "+        //15    x14
                                        "IDMR_PEKERJAAN, "+         //16    x15
                                        "tanggal_lahir, "+          //17    x16
                                        "KartuIdentitas, "+         //18    x17
                                        "Batal " +                  //19
                                    "FROM MR_PASIEN " +
                                    "WHERE  IDMR_PASIEN = '" + strNoRMPasien + "'";
                SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref this.strErr);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    conn.Close();
                    return;
                }

                /*if data found on the database*/
                if (reader.HasRows)
                {
                    reader.Read();
                    isUpdateData = true;

                    /*LOAD social data patient from DB */

                    this.pvLoadDataSosialPasien(
                                modMain.pbstrgetCol(reader, 1, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 2, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 3, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 4, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 5, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 6, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 7, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 9, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 10, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 11, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 12, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 13, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 14, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 15, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 16, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 17, ref strErr, ""),
                                modMain.pbstrgetCol(reader, 18, ref strErr, ""));

                }
                else
                {
                    /*if data NOT found on the database, ASK the user for new registration or NOT*/
                    DialogResult msgDlg = MessageBox.Show("No Rekam Medik tidak ada, Apakah melakukan pendaftaran Baru ?",
                                                        "Konfirmasi",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (msgDlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        /* if yes, then this is new registration process. */
                        isUpdateData = false;
                    }
                    else
                    {
                        /* if not, then try to focus on MR number to entry MR number again..*/
                        txtPasienRM.Focus();
                        txtPasienRM.SelectAll();
                    }

                }

                reader.Close();
                conn.Close();


                

            }
        }




    }
}
