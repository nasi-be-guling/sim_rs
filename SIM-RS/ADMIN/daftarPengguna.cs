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

        public class lstSemuaAnggota
        {
            public string strIdAnggota { get; set; }
            public string strNamaAnggota { get; set; }
            public string strNipNbi { get; set; }
            public string strIdUnitKerja { get; set; }
            public string strUnitKerja { get; set; }
            public string strStatus { get; set; }
            public string strSandi { get; set; }
        }

    
        List<lstSemuaAnggota> grpSemuaAnggota = new List<lstSemuaAnggota>();

        AutoCompleteStringCollection listUnitKerja = new AutoCompleteStringCollection();
        bool isUpdate = false;

        /**/
        /* PRIVATE FUNCTION */

        private void pvLoadAllAnggota()
        {

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            strQuerySQL = "SELECT "+
                            "a.id,"+                        //0
                            "a.nama,"+                      //1
                            "a.nip_nbi,"+                   //2
                            "b.id,"+                        //3
                            "b.nama as UnitKerja,"+         //4
                            "a.dipakai, "+                  //5
                            "a.sandi  " +                   //6
                          "FROM HIS_DAFTAR_USER a " +
                          "LEFT JOIN HIS_DAFTAR_UNITKERJA b ON a.id_unitKerja = b.id " +
                          "ORDER BY a.nama ";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            string strStatusPakai = "";
            grpSemuaAnggota.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lstSemuaAnggota itemAnggota = new lstSemuaAnggota();
                    itemAnggota.strIdAnggota = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemAnggota.strNamaAnggota = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemAnggota.strNipNbi = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemAnggota.strIdUnitKerja = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    itemAnggota.strUnitKerja = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                    string strKodeStatusPakai = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                    listUnitKerja.Add(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    if (Convert.ToInt32(strKodeStatusPakai) == 1)
                        strStatusPakai = "DIPAKAI";
                    else
                        strStatusPakai = "TIDAK DIPAKAI";
                    itemAnggota.strStatus = strStatusPakai;
                    itemAnggota.strSandi = modEncrypt.DecryptString(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    grpSemuaAnggota.Add(itemAnggota);
                }
            }

            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteCustomSource = listUnitKerja);
            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteSource = AutoCompleteSource.CustomSource);
            reader.Close();
            conn.Close();

        }

        private void pvFilterSearchUser(string _strFilter)
        {
            var items = new List<ListViewItem>();

            if (_strFilter.Trim().ToString().ToUpper() != "")
            {

                if (cbPilihan.Text == "Nama")
                {
                    var resultLinQ = from c in grpSemuaAnggota
                                     where c.strNamaAnggota.Contains(_strFilter.ToUpper())
                                     select c;

                    foreach (lstSemuaAnggota itemUser in resultLinQ)
                    {
                        ListViewItem lvItem = new ListViewItem(itemUser.strNamaAnggota);
                        lvItem.SubItems.Add(itemUser.strNipNbi);
                        lvItem.SubItems.Add(itemUser.strUnitKerja);
                        lvItem.SubItems.Add(itemUser.strStatus);
                        lvItem.SubItems.Add(itemUser.strIdAnggota);
                        lvItem.SubItems.Add(itemUser.strIdUnitKerja);
                        lvItem.SubItems.Add(itemUser.strSandi);
                        items.Add(lvItem);

                    }
                }
                else if (cbPilihan.Text == "Unit Kerja")
                {
                    var resultLinQ = from c in grpSemuaAnggota
                                     where c.strUnitKerja.Contains(_strFilter.ToUpper())
                                     select c;

                    foreach (lstSemuaAnggota itemUser in resultLinQ)
                    {
                        ListViewItem lvItem = new ListViewItem(itemUser.strNamaAnggota);
                        lvItem.SubItems.Add(itemUser.strNipNbi);
                        lvItem.SubItems.Add(itemUser.strUnitKerja);
                        lvItem.SubItems.Add(itemUser.strStatus);
                        lvItem.SubItems.Add(itemUser.strIdAnggota);
                        lvItem.SubItems.Add(itemUser.strIdUnitKerja);
                        lvItem.SubItems.Add(itemUser.strSandi);
                        items.Add(lvItem);

                    }
                }

                else
                {
                    var resultLinQ = from c in grpSemuaAnggota
                                     where c.strNipNbi.Contains(_strFilter)
                                     select c;

                    foreach (lstSemuaAnggota itemUser in resultLinQ)
                    {
                        ListViewItem lvItem = new ListViewItem(itemUser.strNamaAnggota);
                        lvItem.SubItems.Add(itemUser.strNipNbi);
                        lvItem.SubItems.Add(itemUser.strUnitKerja);
                        lvItem.SubItems.Add(itemUser.strStatus);
                        lvItem.SubItems.Add(itemUser.strIdAnggota);
                        lvItem.SubItems.Add(itemUser.strIdUnitKerja);
                        lvItem.SubItems.Add(itemUser.strSandi);
                        items.Add(lvItem);

                    }
                }

            }

            else
            {
                var resultLinQ = from c in grpSemuaAnggota
                                 select c;

                foreach (lstSemuaAnggota itemUser in resultLinQ)
                {
                    ListViewItem lvItem = new ListViewItem(itemUser.strNamaAnggota);
                    lvItem.SubItems.Add(itemUser.strNipNbi);
                    lvItem.SubItems.Add(itemUser.strUnitKerja);
                    lvItem.SubItems.Add(itemUser.strStatus);
                    lvItem.SubItems.Add(itemUser.strIdAnggota);
                    lvItem.SubItems.Add(itemUser.strIdUnitKerja);
                    lvItem.SubItems.Add(itemUser.strSandi);
                    items.Add(lvItem);

                }
            }



            lvDaftarPengguna.BeginUpdate();
            lvDaftarPengguna.Items.Clear();
            lvDaftarPengguna.Items.AddRange(items.ToArray());
            lvDaftarPengguna.EndUpdate();

            modSQL.pvAutoResizeLV(lvDaftarPengguna, 4);

        }

        private bool pvCheckNIP(string _strNIP)
        {
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return false;
            }

            String Nomor = modMain.pbstrBersihkanInput(_strNIP);

            strQuerySQL = "SELECT * " +
                          "FROM HIS_DAFTAR_USER WHERE nip_nbi = '" + Nomor + "'";

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

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);

                return false;
            }

            int strKodeStatusPakai = 0;

            if (cmbStatusID.Text.ToUpper() == "DIPAKAI")
                strKodeStatusPakai = 1;
            else
                strKodeStatusPakai = 0;


            if (!isUpdate)
            {

                if (this.pvCheckNIP(txtNIPNBI.Text.Trim().ToString()))
                {
                    MessageBox.Show("NIP / NBI Sudah Terdaftar", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                this.strQuerySQL = "INSERT INTO HIS_DAFTAR_USER (nama,nip_nbi,sandi,dipakai,id_unitKerja) " +
                                    "VALUES ('" + modMain.pbstrBersihkanInput(txtPetugas.Text.Trim().ToString()) +
                                    "','" + modMain.pbstrBersihkanInput(txtNIPNBI.Text.Trim().ToUpper().ToString()) +
                                    "','" + modEncrypt.EncryptToString(modMain.pbstrBersihkanInput(txtSandiPetugas.Text.Trim().ToString())) +
                                    "','" + strKodeStatusPakai +
                                    "','" + modMain.pbstrBersihkanInput(lblUnitKerja.Text.Trim().ToString()) +
                                    "' )";
            }
            else
            {

                this.strQuerySQL = "UPDATE HIS_DAFTAR_USER " +
                                    "SET nama = '" + modMain.pbstrBersihkanInput(txtPetugas.Text.Trim().ToString()) +
                                    "',nip_nbi = '" + modMain.pbstrBersihkanInput(txtNIPNBI.Text.Trim().ToString()) +
                                    "',sandi = '" + modEncrypt.EncryptToString(modMain.pbstrBersihkanInput(txtSandiPetugas.Text.Trim().ToString())) +
                                    "',id_unitKerja = '" + modMain.pbstrBersihkanInput(lblUnitKerja.Text.Trim().ToString()) +
                                    "', Dipakai = '" + strKodeStatusPakai +
                                    "' WHERE id = '" + modMain.pbstrBersihkanInput(lblIdPetugas.Text.Trim().ToString()) + "'";
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

        private void pvHapusIsian()
        {
            txtPetugas.Text = "";
            txtSandiPetugas.Text = "";
            cmbStatusID.SelectedIndex = -1;
            lblUnitKerja.Text = "";
            isUpdate = false;
            txtNIPNBI.Text = "";
            txtUnitKerja.Text = "";
            lblIdPetugas.Text = "";

        }

        /**/

        public daftarPengguna()
        {
            InitializeComponent();

            this.pvLoadAllAnggota();
            this.pvFilterSearchUser("");

        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }  

        private void btnCariSesuaiFilter_Click(object sender, EventArgs e)
        {
            this.pvFilterSearchUser(txtIsiFilter.Text.Trim().ToString());
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
            txtNIPNBI.Focus();
            txtPetugas.Text = lvDaftarPengguna.SelectedItems[0].Text;
            txtNIPNBI.Text = lvDaftarPengguna.SelectedItems[0].SubItems[1].Text;
            txtUnitKerja.Text = lvDaftarPengguna.SelectedItems[0].SubItems[2].Text;
            cmbStatusID.Text = lvDaftarPengguna.SelectedItems[0].SubItems[3].Text;
            lblIdPetugas.Text = lvDaftarPengguna.SelectedItems[0].SubItems[4].Text;
            lblUnitKerja.Text = lvDaftarPengguna.SelectedItems[0].SubItems[5].Text;
            txtSandiPetugas.Text = lvDaftarPengguna.SelectedItems[0].SubItems[6].Text;
            isUpdate = true;
           
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.pvHapusIsian();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
            if(!this.pvSimpanData())
            {
                MessageBox.Show("Data tidak bisa tersimpan, Mohon periksa kembali isian anda",
                                "Informasi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Data sudah tersimpan","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.pvHapusIsian();
            this.pvLoadAllAnggota();
            this.pvFilterSearchUser("");
            txtNIPNBI.Focus();

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

        private void lvDaftarPengguna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cbPilihan.Focus();
                cbPilihan.Text = "Nama";
            }
        }

        private void cbPilihan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIsiFilter.Focus();
            }
        }

        private void txtIsiFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCariSesuaiFilter.Focus();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.pvLoadAllAnggota();
            this.pvFilterSearchUser("");
        }

        private void pvCariUnitKerja(String _UnitKerja)
        {

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            strQuerySQL = "SELECT id "+                       
                          "FROM HIS_DAFTAR_UNITKERJA a " +
                          "WHERE dipakai = 1 AND nama = '" + _UnitKerja.ToUpper() + "' " ;

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
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
                  
                    lblUnitKerja.Text = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    
                }
            }
            else
            {
                MessageBox.Show("Pilih Unit Kerja yang Lain");    
            }

            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteCustomSource = listUnitKerja);
            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtUnitKerja.SafeControlInvoke(TextBox => txtUnitKerja.AutoCompleteSource = AutoCompleteSource.CustomSource);
            reader.Close();
            conn.Close();

        }

        private void txtUnitKerja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.pvCariUnitKerja(txtUnitKerja.Text);
                btnCariSesuaiFilter.Focus();
                txtSandiPetugas.Focus();
            }
                       
        }

        private void txtNIPNBI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPetugas.Focus();
            }
        }

        private void txtPetugas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitKerja.Focus();
            }
        }

        private void txtSandiPetugas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbStatusID.Focus();
            }
        }


        private bool Nomor(System.Windows.Forms.KeyPressEventArgs e)
        {
            string strValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if (strValid.IndexOf(e.KeyChar) < 0 && !(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                return true; // not valid
            }
            else
            {
                return false; // valid
            }

        }

        private void txtNIPNBI_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Nomor(e);
        }

        private void cmbStatusID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan.Focus();
            }
        }
    }
}
