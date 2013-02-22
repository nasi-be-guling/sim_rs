using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIM_RS
{
    public partial class login : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /*Private Variable*/

        string strSqlQuery = "";
        string strErr = "";
        string strNamaPetugas = "";
        bool isLoginSuccess = false;

        /*EOF Private Variable*/

        /*LOAD OTHER FORM       */
        /*IF NEEDED             */

        halamanUtama fHalamanUtama = new halamanUtama();

        /*EOF LOAD OTHER FORM   */

        public login()
        {
            InitializeComponent();
        }      

        private void txtIdPetugas_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != 13)
                return;

            bool boolPetugasAda = false;

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            string strPetugas = modMain.pbstrBersihkanInput(txtIdPetugas.Text);

            strSqlQuery = "SELECT "+
                                "Petugas "+
                          "FROM BILPETUGAS "+
                          "WHERE idPetugas = '" + strPetugas + "'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strSqlQuery, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {

                reader.Read();
                strNamaPetugas = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                boolPetugasAda = true;
            }



            reader.Close();

            cmbUnitKerja.Items.Clear();

            if (boolPetugasAda)
            {

                strSqlQuery = "SELECT Grup FROM BILHAKAKSES WHERE idPetugas = '" + strPetugas + "' GROUP BY Grup";

                reader = modDb.pbreaderSQL(conn, strSqlQuery, ref strErr);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                    conn.Close();
                    return;
                }

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        cmbUnitKerja.Items.Add(modMain.pbstrgetCol(reader,0,ref strErr,cmbUnitKerja.Name.ToString()));
                    }

                }

                cmbUnitKerja.Text = cmbUnitKerja.Items[0].ToString();
                cmbUnitKerja.Focus();
                txtIdPetugas.Enabled = false;

            }
            else
            {
                MessageBox.Show("ID Petugas yang anda masukkan tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdPetugas.Focus();
            }

            conn.Close();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!isLoginSuccess)
            {
                DialogResult msgDialog = MessageBox.Show("Apakah anda akan membatalkan login dan keluar dari program",
                                                            "Informasi",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                if (msgDialog == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (!isLoginSuccess)
            {
                halamanUtama fTCN = (halamanUtama)Application.OpenForms["halamanUtama"];
                fTCN.isForceQuit = true;
                fTCN.Close();
            }
            else
            {
                /*CALL / LOAD INFO IN MAIN FORM..*/

                halamanUtama fTCN = (halamanUtama)Application.OpenForms["halamanUtama"];

                fTCN.txtPetugas.Text = strNamaPetugas;
                fTCN.txtUnitKerja.Text = cmbUnitKerja.Text.Trim().ToString();
                fTCN.txtShift.Text = cmbShift.Text.Trim().ToString();

                fTCN.pvLoadInfoUser(txtIdPetugas.Text.Trim().ToString());
                fTCN.lbDaftarMenu.Select();
                   
            }
        }

        private void cmbUnitKerja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnitKerja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (cmbUnitKerja.Text.Trim().ToString() != ""))
            {

                cmbShift.Text = cmbShift.Items[0].ToString();
                cmbShift.Focus();
                cmbUnitKerja.Enabled = false;
            }
        }

        private void cmbShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (cmbShift.Text.Trim().ToString() != ""))
            {
                isLoginSuccess = true;
                this.Close();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

    }
}
