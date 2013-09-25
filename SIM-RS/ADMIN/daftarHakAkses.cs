using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIM_RS.ADMIN
{
    public partial class daftarHakAkses : Form
    {

        string strErr = "";
        string strQuerySQL = "";

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        bool isUpdate = false;

        public daftarHakAkses()
        {
            InitializeComponent();
        }


        /* PRIVATE FUNCTION */

        private void pvLoadData(string _strCari = "")
        {
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            if (_strCari == "")

                strQuerySQL = "SELECT idpetugas, idprogram, grup, Urut " +
                                "FROM BILHAKAKSES";
            else
                strQuerySQL = "SELECT idpetugas, idprogram, grup, Urut " +
                                "FROM BILHAKAKSES WHERE idprogram LIKE '%" + _strCari + "%'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                lvDaftarMenu.Items.Clear();
                while (reader.Read())
                {
                    lvDaftarMenu.Items.Add(modMain.pbstrgetCol(reader, 0, ref strErr, ""));
                    lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                        modMain.pbstrgetCol(reader, 1, ref strErr, ""));

                    lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                        modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    lvDaftarMenu.Items[lvDaftarMenu.Items.Count - 1].SubItems.Add(
                        modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                }
                modSQL.pvAutoResizeLV(lvDaftarMenu, 3);
            }

            reader.Close();
            conn.Close();
        }

        private bool pvSimpanData()
        {
            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);

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


            modDb.pbWriteSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return false;
            }

            conn.Close();
            return true;

        }

        /* EOF PRIVATE FUNCTION */


    }
}
