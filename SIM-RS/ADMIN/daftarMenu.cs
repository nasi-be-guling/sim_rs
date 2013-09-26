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
    public partial class daftarMenu : Form
    {

        string strErr = "";
        string strQuerySQL = "";

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        bool isUpdate = false;

        public daftarMenu()
        {
            InitializeComponent();
            this.pvLoadData("");
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

                strQuerySQL = "SELECT idProgram,NamaForm,Kelompok,NamaFormERD " +
                                "FROM BILPROGRAM";
            else
                strQuerySQL = "SELECT idProgram,NamaForm,Kelompok,NamaFormERD " +
                                "FROM BILPROGRAM WHERE (idProgram LIKE '%" + _strCari + "%') or (NamaFormERD LIKE '%" + _strCari + "%')";

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
                modSQL.pvAutoResizeLV(lvDaftarMenu, 4);
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

            if (!isUpdate)                
                this.strQuerySQL = "INSERT INTO BILPROGRAM (idProgram,Kelompok,NamaFormERD) " +
                                    "VALUES ('" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(txtKelompok.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
                                    "')";
            else
                /* JIKA BUKAN MENU DARI APLIKASI LAMA MAKA BISA MENGUPDATE JUGA NAMA MENU DAN NAMA FORM */
                if(txtNamaAppLama.Text.Trim().ToString() == "")
                    this.strQuerySQL = "UPDATE BILPROGRAM " +
                                        "SET idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) + 
                                        "', NamaFormERD = '" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
                                        "' WHERE idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) + "'";
                else
                    this.strQuerySQL = "UPDATE BILPROGRAM " +
                                        "SET NamaFormERD = '" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
                                        "' WHERE idProgram = '" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) + "'";


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

        private void pvBersihkanForm()
        {
            txtNamaMenu.Text = "";
            txtNamaAppLama.Text = "";
            txtNamaAppBaru.Text = "";
            txtKelompok.Text = "";
            txtNamaMenu.Enabled = true;
            isUpdate = false;
        }

        /*EOF PRIVATE FUNCTION*/

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void daftarMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void lvDaftarMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && 
                (lvDaftarMenu.Items.Count > 0))
            {
                cmsDaftarMenu.Show(this.lvDaftarMenu, e.Location);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.pvBersihkanForm();
        }

        private void rubahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            txtNamaMenu.Text = lvDaftarMenu.SelectedItems[0].Text.Trim().ToString();
            txtNamaAppLama.Text = lvDaftarMenu.SelectedItems[0].SubItems[1].Text.Trim().ToString();
            txtKelompok.Text = lvDaftarMenu.SelectedItems[0].SubItems[2].Text.Trim().ToString();
            txtNamaAppBaru.Text = lvDaftarMenu.SelectedItems[0].SubItems[3].Text.Trim().ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            this.pvSimpanData();
        }

        private void btnCariMenu_Click(object sender, EventArgs e)
        {
            this.pvLoadData(txtCariMenu.Text.Trim());
        }
    }
}
