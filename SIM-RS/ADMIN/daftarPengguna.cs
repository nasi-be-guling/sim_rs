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
    public partial class daftarPengguna : Form
    {

        string strErr = "";
        string strQuerySQL = "";

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        bool isUpdate = false;

        /**/
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


            if(_strCari == "")

                strQuerySQL = "SELECT idPetugas,Petugas,UnitKerja,Dipakai "+
                                "FROM BILPETUGAS";
            else
                strQuerySQL = "SELECT idPetugas,Petugas,UnitKerja,Dipakai " +
                                "FROM BILPETUGAS WHERE Petugas LIKE '%" + _strCari + "%'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            string strStatusPakai = "";

            if (reader.HasRows)
            {
                lvDaftarPengguna.Items.Clear();
                while (reader.Read())
                {
                    lvDaftarPengguna.Items.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    lvDaftarPengguna.Items[lvDaftarPengguna.Items.Count - 1].SubItems.Add(
                        modMain.pbstrgetCol(reader, 2, ref strErr, ""));

                    string strKodeStatusPakai = modMain.pbstrgetCol(reader, 3, ref strErr, "");

                    if (strKodeStatusPakai.ToUpper() == "Y")
                        strStatusPakai = "DIPAKAI";
                    else if (strKodeStatusPakai.ToUpper() == "P")
                        strStatusPakai = "PENSIUN";
                    else
                        strStatusPakai = "TIDAK DIPAKAI";

                    lvDaftarPengguna.Items[lvDaftarPengguna.Items.Count - 1].SubItems.Add(strStatusPakai);
                    lvDaftarPengguna.Items[lvDaftarPengguna.Items.Count - 1].SubItems.Add(
                        modMain.pbstrgetCol(reader, 0, ref strErr, ""));

                }

                modSQL.pvAutoResizeLV(lvDaftarPengguna, 3);
                
            }

            reader.Close();
            conn.Close();
        }


        private bool pvCheckSandi(string _strSandi)
        {
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return false;
            }


            strQuerySQL = "SELECT idPetugas,Petugas,UnitKerja,Dipakai " +
                          "FROM BILPETUGAS WHERE idPetugas = '" + _strSandi + "'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return false;
            }

            bool isKetemu = false;
            if (reader.HasRows)
            {
                isKetemu = true;              
            }

            reader.Close();
            conn.Close();

            if (isKetemu)
                return true;
            else
                return false;
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

            string strKodeStatusPakai = "";

            if (cmbStatusID.Text.ToUpper() == "DIPAKAI")
                strKodeStatusPakai = "Y";
            else if (cmbStatusID.Text.ToUpper() == "TIDAK DIPAKAI")
                strKodeStatusPakai = "T";
            else
                strKodeStatusPakai = "P";

            if (!isUpdate)

                this.strQuerySQL = "INSERT INTO BILPETUGAS (idpetugas,Petugas,UnitKerja,Dipakai) " +
                                    "VALUES ('" + modMain.pbstrBersihkanInput(txtSandiPetugas.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(txtPetugas.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(cmbUnitKerja.Text.Trim().ToString()) +
                                    "','" + strKodeStatusPakai + "')";
            else

                this.strQuerySQL = "UPDATE BILPETUGAS "+
                                    "SET Petugas = '" + modMain.pbstrBersihkanInput(txtPetugas.Text.Trim().ToString()) +
                                    "',UnitKerja = '" + modMain.pbstrBersihkanInput(cmbUnitKerja.Text.Trim().ToString()) + 
                                    "', Dipakai = '" + strKodeStatusPakai +
                                    "' WHERE idPetugas = '" + modMain.pbstrBersihkanInput(txtSandiPetugas.Text.Trim().ToString()) + "'";


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

        private void pvHapusIsian()
        {
            txtPetugas.Text = "";
            txtSandiPetugas.Text = "";
            cmbStatusID.SelectedIndex = -1;
            cmbUnitKerja.Text = "";
            isUpdate = false;
            txtSandiPetugas.Enabled = true;
        }

        /**/

        public daftarPengguna()
        {
            InitializeComponent();

            this.pvLoadData();

        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void daftarPengguna_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCariSesuaiFilter_Click(object sender, EventArgs e)
        {
            this.pvLoadData(txtIsiFilter.Text.Trim().ToString());
        }

        private void lvDaftarPengguna_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (lvDaftarPengguna.Items.Count > 0))
            {
                cmsDaftarPengguna.Show(this.lvDaftarPengguna, e.Location);
            }
        }

        private void rubahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPetugas.Text = lvDaftarPengguna.SelectedItems[0].Text;
            cmbUnitKerja.Text = lvDaftarPengguna.SelectedItems[0].SubItems[1].Text;
            txtSandiPetugas.Text = lvDaftarPengguna.SelectedItems[0].SubItems[3].Text;
            cmbStatusID.Text = lvDaftarPengguna.SelectedItems[0].SubItems[2].Text;
            isUpdate = true;
            txtSandiPetugas.Enabled = false;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.pvHapusIsian();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(this.pvCheckSandi(txtSandiPetugas.Text.Trim().ToString()))
            {
                MessageBox.Show("ID Petugas sudah ada yang memakai.","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            
            if(!this.pvSimpanData())
            {
                MessageBox.Show("Data tidak bisa tersimpan, Mohon periksa kembali isian anda",
                                "Informasi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Data sudah tersimpan","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.pvHapusIsian();
            


        }

        private void daftarPengguna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUpdate)
            {
                DialogResult msgDlg =  MessageBox.Show("Anda masih melakukan proses update, apakah akan keluar ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (msgDlg == DialogResult.No)
                    e.Cancel = true;

            }
        }
    }
}
