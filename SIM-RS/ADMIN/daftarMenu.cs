﻿using System;
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
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            if (_strCari == "")

                strQuerySQL = "SELECT id, nama, dipakai, form " +
                                "FROM HIS_DAFTAR_MENU";
            else
                strQuerySQL = "SELECT id, nama, dipakai, form " +
                                "FROM HIS_DAFTAR_MENU WHERE (nama LIKE '%" + _strCari + "%') or (form LIKE '%" + _strCari + "%')";

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

        /*
     *  NAME        : simpan menu
     *  FUNCTION    : proses simpan menu, yaitu mengambil id terakhir kemudian simpan semua data menu
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 16-02-2013
     */

        private bool pvSimpanData()
        {
            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);

            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return false;
            }

            if (!isUpdate)
            {
                /* INSERTING MENU DATA TO DATABASE */
                this.strQuerySQL = "INSERT INTO HIS_DAFTAR_MENU (nama, dipakai, form) " +
                                    "VALUES ('" + modMain.pbstrBersihkanInput(txtNamaMenu.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(cmbDipakai.SelectedIndex.ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(txtNamaAppBaru.Text.Trim().ToString()) +
                                    "')";
            }

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
            txtNamaAppBaru.Text = "";
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
            //txtNamaMenu.Text = lvDaftarMenu.SelectedItems[0].Text.Trim().ToString();
            txtNamaMenu.Text = lvDaftarMenu.SelectedItems[0].SubItems[1].Text.Trim().ToString();
            txtNamaAppBaru.Text = lvDaftarMenu.SelectedItems[0].SubItems[3].Text.Trim().ToString();
            cmbDipakai.SelectedIndex = Convert.ToInt16(lvDaftarMenu.SelectedItems[0].SubItems[2].Text.Trim().ToString());
            txtNamaMenu.Focus();
            txtNamaMenu.SelectAll();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if ((txtNamaMenu.Text.Trim().ToString() != "") && (txtNamaAppBaru.Text.Trim().ToString() != ""))
            {
                if (!this.pvSimpanData())
                {
                    MessageBox.Show("Data tidak bisa tersimpan, Mohon periksa kembali isian anda",
                                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Data sudah tersimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.pvBersihkanForm();            
            }
            else MessageBox.Show("cek inputan");
        }

        private void btnCariMenu_Click(object sender, EventArgs e)
        {
            this.pvLoadData(txtCariMenu.Text.Trim());
        }

        private void txtNamaMenu_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtNamaMenu.Text.Trim().ToString() != ""))
            {
                txtNamaAppBaru.Focus();
            }
        }

        private void txtNamaAppBaru_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtNamaMenu.Text.Trim().ToString() != ""))
            {
                txtNamaAppBaru.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
