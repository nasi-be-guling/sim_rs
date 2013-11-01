using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace SIM_RS.RAWAT_INAP
{
    public partial class inputKeringanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();

        string strQuerySQL = "";
        string strErr = "";
        bool isFirstDisplayCombo = false;

        string strTempKodeNamaDokter = "";
        string strTempKodeDetailTindakan = "";

        public class lstDetailTindakan
        {
            public string strNoUrut { get; set; }
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public DateTime dtTglInput { get; set; }
            public string strKomponen { get; set; }
            public double dblBiaya { get; set; }
            public double dblKeringanan { get; set; }
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strKodeTindakan { get; set; }
            public string strKodeDetailTindakan { get; set; }
        }
        List<lstDetailTindakan> grpDetailTindakan = new List<lstDetailTindakan>();

        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strSMF { get; set; }
        }
        List<lstDaftarDokter> grpLstDaftarDokter = new List<lstDaftarDokter>();

        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();

        public inputKeringanan()
        {
            InitializeComponent();
            this.bgWorkLoadDataInit.RunWorkerAsync();
            int intUrutan = 0;
            modMain.pvUrutkanTab(txtNoBilling, ref intUrutan);
            modMain.pvUrutkanTab(lvDaftarTindakan, ref intUrutan);
            modMain.pvUrutkanTab(txtNominalKeringanan, ref intUrutan);
            modMain.pvUrutkanTab(chkRubahDokter, ref intUrutan);
            modMain.pvUrutkanTab(txtNamaDokter, ref intUrutan);
            modMain.pvUrutkanTab(btnSimpan, ref intUrutan);
            modMain.pvUrutkanTab(btnBatal, ref intUrutan);
            modMain.pvUrutkanTab(btnKeluarIsiTindakan, ref intUrutan);
        }

        private void pvLoadData(string strKodeDetailTindakan)
        {
            int intResult = grpDetailTindakan.FindIndex(m => m.strKodeDetailTindakan == strKodeDetailTindakan);
            strTempKodeDetailTindakan = strKodeDetailTindakan;
            lblKodeTarif.Text = grpDetailTindakan[intResult].strKodeTarif;
            lblUraianTarif.Text = grpDetailTindakan[intResult].strUraianTarif;
            lblKomponenTarif.Text = grpDetailTindakan[intResult].strKomponen;
            lblNilaiTarif.Text = grpDetailTindakan[intResult].dblBiaya.ToString();
            txtNominalKeringanan.Text = grpDetailTindakan[intResult].dblKeringanan.ToString();

            if (grpDetailTindakan[intResult].strKodeDokter.Trim().ToString() != "" && 
                grpDetailTindakan[intResult].strKodeDokter.Trim().ToString() != "-")
            {
                txtNamaDokter.Text = grpDetailTindakan[intResult].strKodeDokter + " -- " + grpDetailTindakan[intResult].strNamaDokter;
                strTempKodeNamaDokter = grpDetailTindakan[intResult].strKodeDokter + " -- " + grpDetailTindakan[intResult].strNamaDokter;
            }
            else
            {
                txtNamaDokter.Text = "";
                strTempKodeNamaDokter = "";
            }

            chkRubahDokter.Checked = false;
            txtNamaDokter.Enabled = false;
            pnlDaftarTindakan.SendToBack();
            pnlDaftarTindakan.Visible = false;
        }      

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            isFirstDisplayCombo = true;
            
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            string strNoBilling = "";
            txtNoBilling.SafeControlInvoke(TextBox => strNoBilling = txtNoBilling.Text.Trim().ToString());

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "PROSES MENAMPILKAN DATA SOSIAL");
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
                if (strSubSistem.Trim().ToString() != "PAV")
                {
                    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                    txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);
                    MessageBox.Show("Pengentrian Tindakan ini hanya untuk Pasien pada Instalasi Pelayanan Utama (IPU)",
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
            }
            else
            {   lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);
                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reader.Close();
                conn.Close();
                return;
            }

            reader.Close();

            
            //LOAD DATA LISTVIEW.. 
            //this.pvLoadAllData();
            this.bgWorkLoadDallData.RunWorkerAsync();

            #region CODE STATUS : NEED REMOVE LATER
            /*
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "PROSES MENAMPILKAN DATA TINDAKAN");

            this.strQuerySQL = "SELECT "+
                                    "a.idbl_tarip, "+           //0
                                    "a.uraiantarip, "+          //1
                                    "a.tglTransaksi, "+         //2
                                    "b.idbl_komponen, "+        //3
                                    "b.nilai, "+                //4
                                    "b.ringan,  " +             //5
                                    "c.Nama, " +                //6
                                    "b.idtrdet, " +             //7
                                    "c.idmr_dokter " +          //8
                               "FROM BL_TRANSAKSI AS a "+
                               "LEFT JOIN BL_TRANSAKSIDETAIL AS b on a.idbl_transaksi = b.idbl_transaksi " +
                               "LEFT JOIN MR_DOKTER AS c on b.idmr_dokter = c.idmr_dokter "+
                               "WHERE RegBilling = '" + txtNoBilling.Text.Trim().ToString() +"'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            lvDaftarTindakan.Items.Clear();
            int intUrutan = 1;
            grpDetailTindakan.Clear();
            string strTgl = "";
            string strTglTemp = "";
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstDetailTindakan item = new lstDetailTindakan();
                    item.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    item.strUraianTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    item.dtTglInput = Convert.ToDateTime(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    item.strKomponen = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    item.dblBiaya = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    item.dblKeringanan = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    item.strNamaDokter = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    item.strKodeDetailTindakan = modMain.pbstrgetCol(reader, 7, ref strErr, "");
                    item.strKodeDokter = modMain.pbstrgetCol(reader, 8, ref strErr, "");
                    grpDetailTindakan.Add(item);

                    strTgl = item.dtTglInput.ToString();

                    if (strTglTemp != strTgl)
                    {
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(intUrutan.ToString()));
                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                    modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                    modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                    modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                        intUrutan++;
                    }
                    else
                    {
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(""));
                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                        lvDaftarTindakan.SafeControlInvoke(
                                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));
                    }

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 3, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 4, ref strErr, "")));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 5, ref strErr, "")));

                    double dblNominal = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    double dblNominalPengurangan = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    double dblNominalBersih = dblNominal - dblNominalPengurangan;

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                    dblNominalBersih.ToString()));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 6, ref strErr, "")));

                    //INVISIBLE idDetailTindakan
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 7, ref strErr, "")));



                    strTglTemp = strTgl;
                    
                }
            }

            reader.Close();*/
            #endregion

            conn.Close();
            
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            btnKeluarIsiTindakan.SafeControlInvoke(Button => btnKeluarIsiTindakan.Text = "&ISI BARU");

        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            if (!txtNoBilling.Enabled)
            {
                pnlInputKeringanan.SendToBack();
                txtNoBilling.Enabled = true;
                btnKeluarIsiTindakan.Text = "&KELUAR";
                txtNoBilling.Focus();
                lvDaftarTindakan.Items.Clear();
                lblMRPasien.Text = "...";
                lblNamaPasien.Text = "...";
                lblAlamatPasien.Text = "...";
                lblRuangan.Text = "...";
                lblKelas.Text = "...";
                lblStatusPasien.Text = "...";
            }else
            this.Close();
        }

        private void txtNoBilling_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = modMain.allowOnlyNumeric(e.KeyChar);

            if (e.KeyChar == 13)
            {
                if (txtNoBilling.Text.Trim().ToString() == "")
                    return;


                //timerBlink.Enabled = true;
                //timerBlink.Start();

                this.bgWork.RunWorkerAsync();

                //this.pvLoadDataPasien(txtNoBilling.Text.Trim());
            }
        }

        private void btnBatalTindakan_Click(object sender, EventArgs e)
        {
            pnlInputKeringanan.SendToBack();
            pnlInputKeringanan.Enabled = false;
            pnlDaftarTindakan.Visible = true;
        }

        private void lvDaftarTindakan_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && 
                (lvDaftarTindakan.Items.Count > 0))
            {
                
                cmsMenu.Show(this.lvDaftarTindakan, e.Location);

                if(lvDaftarTindakan.SelectedItems[0].SubItems[4].Text.ToUpper().Trim().ToString() == "JASA SARANA")
                    rubahDataToolStripMenuItem.Enabled = false;
                else
                    rubahDataToolStripMenuItem.Enabled = true;

            }
        }

        private void inputKeringanan_Load(object sender, EventArgs e)
        {


        }

        private void cmsMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void bgWorkLoadDataInit_DoWork(object sender, DoWorkEventArgs e)
        {
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

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "LOADING DATA DOKTER");
            this.strQuerySQL = "SELECT " +
                                "MR_DOKTER.idmr_dokter, " +                 //0
                                "MR_DOKTER.nama, " +                        //1
                                "MR_DOKTER.idmr_tsmf " +                    //2
                               "FROM MR_DOKTER WITH (NOLOCK) " +
                               "WHERE MR_DOKTER.dipakai = 'Y'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
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
                    itemDaftarDokter.strSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");

                    grpLstDaftarDokter.Add(itemDaftarDokter);
                }
            }



            reader.Close();

            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteCustomSource = listDokter);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource);

            conn.Close();

            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Focus());

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "");

        }

        private void rubahDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlInputKeringanan.Enabled = true;
            string strKodeDetailTindakan = lvDaftarTindakan.SelectedItems[0].SubItems[9].Text;

            this.pvLoadData(strKodeDetailTindakan);
        }

        private void chkRubahDokter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRubahDokter.Checked)
            {
                txtNamaDokter.Enabled = true;
            }
            else
            {
                txtNamaDokter.Enabled = false;
                txtNamaDokter.Text = strTempKodeNamaDokter;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int intResult = grpDetailTindakan.FindIndex(m => m.strKodeDetailTindakan == strTempKodeDetailTindakan);

            double dblNominalJasa = grpDetailTindakan[intResult].dblBiaya;
            double dblNominalKeringanan = Convert.ToDouble(txtNominalKeringanan.Text);

            if(dblNominalKeringanan > dblNominalJasa)
            {
                MessageBox.Show("Nominal keringanan tidak bisa lebih besar dari nominal jasa ", 
                                "Informasi", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                return;
            }

            /* jika sudah benar update dulu di list nya..*/
            grpDetailTindakan[intResult].dblKeringanan = dblNominalKeringanan;


            /* Load default value */
            String[] strKodeNamaDokterSplit = Regex.Split(strTempKodeNamaDokter,"--");
            
            string strKode = "-";
            string strNama = "-";
            if (strKodeNamaDokterSplit.Count() > 1)
            {

                strKode = strKodeNamaDokterSplit[0].Trim().ToString();
                strNama = strKodeNamaDokterSplit[1].Trim().ToString();
            }
            
            grpDetailTindakan[intResult].strKodeDokter = strKode;
            grpDetailTindakan[intResult].strNamaDokter = strNama;

            /* berarti ada rubah nama dan kode dokter */
            if (chkRubahDokter.Checked)
            {
                if (txtNamaDokter.Text.Trim().ToString() == "")
                {
                    strKodeNamaDokterSplit = Regex.Split(txtNamaDokter.Text.Trim().ToString(), "--");
                    if (strKodeNamaDokterSplit.Count() > 1)
                    {
                        strKode = strKodeNamaDokterSplit[0].Trim().ToString();
                        strNama = strKodeNamaDokterSplit[1].Trim().ToString();
                    }
                }

                grpDetailTindakan[intResult].strKodeDokter = strKode;
                grpDetailTindakan[intResult].strNamaDokter = strNama;
            }

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            /* UPDATE changes TO DATABASE */
            if(!chkRubahDokter.Checked)
                this.strQuerySQL =  "UPDATE BL_TRANSAKSIDETAIL "+
                                    "SET ringan = " + grpDetailTindakan[intResult].dblKeringanan.ToString() +
                                    " WHERE idtrdet = " + strTempKodeDetailTindakan;
            else
                this.strQuerySQL = "UPDATE BL_TRANSAKSIDETAIL " +
                                    "SET ringan = " + grpDetailTindakan[intResult].dblKeringanan.ToString() +
                                    ", idmr_dokter = " + strKode +
                                    " WHERE idtrdet = " + strTempKodeDetailTindakan;

            modDb.pbWriteSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            conn.Close();

            //load updated data on the listview..
            //this.pvLoadAllData();
            this.bgWorkLoadDallData.RunWorkerAsync();

            pnlInputKeringanan.SendToBack();
            pnlInputKeringanan.Enabled = false;
            pnlDaftarTindakan.Visible = true;


        }

        private void pnlInputKeringanan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inputKeringanan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void inputKeringanan_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void inputKeringanan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!txtNoBilling.Enabled)
            {
                DialogResult msgDlg = MessageBox.Show("Anda masih melakukan proses perubahan data, Apakah akan menutup menu ini ?", 
                                "Informasi", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question);


                if (msgDlg == DialogResult.No)
                    e.Cancel = true;

            }
        }

        private void txtNominalKeringanan_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtNominalKeringanan_TextChanged(object sender, EventArgs e)
        {
            double dblNilaiAwal = Convert.ToDouble(lblNilaiTarif.Text);
            double dblNilaiPengurangan = 0;

            if (txtNominalKeringanan.Text.Trim().ToString() != "")
                dblNilaiPengurangan = Convert.ToDouble(txtNominalKeringanan.Text);

            double dblNilaiAkhir = dblNilaiAwal - dblNilaiPengurangan;
            lblSisa.Text = dblNilaiAkhir.ToString();
        }

        private void cmbFilterNamaDokter_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFirstDisplayCombo = false;
            this.bgWorkLoadDallData.RunWorkerAsync();
        }

        private void bgWorkLoadDallData_DoWork(object sender, DoWorkEventArgs e)
        {
            #region STATUS CODE : NEED REVIEW LATER
            /*FAST METHOD*/
            /*
            string strTarif = "";
            string strTempTarif = "";
            int intUrutan = 1;

            lvDaftarTindakan.Items.Clear();

            foreach (lstDetailTindakan item in grpDetailTindakan)
            {
                strTarif = item.strKodeTarif;

                if (strTempTarif != strTarif)
                {
                    lvDaftarTindakan.Items.Add(intUrutan.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.strKodeTarif);
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.strUraianTarif);

                    intUrutan++;
                }
                else
                {
                    lvDaftarTindakan.Items.Add("");
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add("");
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add("");
                }

                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.dtTglInput.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.strKomponen);                
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.dblBiaya.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.dblKeringanan.ToString());

                double dblNominal = item.dblBiaya;
                double dblNominalPengurangan = item.dblKeringanan;
                double dblNominalBersih = dblNominal - dblNominalPengurangan;

                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                dblNominalBersih.ToString()));

                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.strNamaDokter);
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(item.strKodeDetailTindakan);

                strTempTarif = strTarif;
            }
            */
            #endregion

            /* LOAD DATA TINDAKAN YANG ADA.. */

            cmbFilterNamaDokter.SafeControlInvoke(ComboBox => cmbFilterNamaDokter.Enabled = false);

            int intJumlahData = 0;

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "PROSES MENAMPILKAN DATA");
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            lvDaftarTindakan.SafeControlInvoke(ListView => intJumlahData = lvDaftarTindakan.Items.Count);


            if (intJumlahData > 0)
                lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.Clear());

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            string strNoBilling = "";
            txtNoBilling.SafeControlInvoke(TextBox => strNoBilling = txtNoBilling.Text.Trim().ToString());

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "PROSES MENAMPILKAN DATA TINDAKAN");

            string strWhere = "";
            string[] strArrayDokter = null;
            string strNamaDokter = "";
            string strKodeDokter = "";
            cmbFilterNamaDokter.SafeControlInvoke(ComboBox => strArrayDokter = Regex.Split(cmbFilterNamaDokter.Text.Trim().ToString(), "--"));

            if (strArrayDokter.Count() > 1)
            {
                strKodeDokter = strArrayDokter[0].ToString();
                strNamaDokter = strArrayDokter[1].ToString();
                strWhere = " AND MR_DOKTER.idmr_dokter = '" + strKodeDokter + "' ";
            }

            //this.strQuerySQL = "SELECT " +
            //                        "a.idbl_tarip, " +           //0
            //                        "a.uraiantarip, " +          //1
            //                        "a.tglTransaksi, " +         //2
            //                        "b.idbl_komponen, " +        //3
            //                        "b.nilai, " +                //4
            //                        "b.ringan,  " +             //5
            //                        "c.Nama, " +                //6
            //                        "b.idtrdet, " +             //7
            //                        "c.idmr_dokter " +          //8
            //                   "FROM BL_TRANSAKSI AS a " +
            //                   "LEFT JOIN BL_TRANSAKSIDETAIL AS b " +
            //                        "on a.idbl_transaksi = b.idbl_transaksi " +
            //                   "LEFT JOIN MR_DOKTER AS c " +
            //                        "on b.idmr_dokter = c.idmr_dokter " +
            //                   "WHERE " +
            //                        "RegBilling = '" + strNoBilling + "' " + strWhere;

            this.strQuerySQL = "SELECT "+
                                "BL_TRANSAKSI.idbl_tarip, "+            //0
                                "BL_TRANSAKSI.uraiantarip, "+           //1  
                                "BL_TRANSAKSI.Tgltransaksi, "+          //2
                                "BL_TRANSAKSIDETAIL.Idbl_komponen, "+   //3
                                "BL_TRANSAKSIDETAIL.nilai, "+           //4
                                "BL_TRANSAKSIDETAIL.Ringan, "+          //5
                                "MR_DOKTER.Nama, "+                     //6
                                "BL_TRANSAKSIDETAIL.idtrdet, "+         //7
                                "MR_DOKTER.idmr_dokter " +              //8
                                "FROM BL_TRANSAKSI "+
                                    "LEFT JOIN BL_TRANSAKSIDETAIL "+
                                "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi "+
                                "LEFT JOIN MR_DOKTER "+
                                "ON BL_TRANSAKSIDETAIL.Idmr_dokter = MR_DOKTER.idmr_dokter "+
                                "GROUP BY "+
                                        "BL_TRANSAKSI.idbl_tarip, "+
                                        "BL_TRANSAKSI.uraiantarip,"+
                                        "BL_TRANSAKSI.Tgltransaksi,"+
                                        "BL_TRANSAKSI.Regbilling, "+
                                        "BL_TRANSAKSIDETAIL.Idbl_komponen, "+
                                        "BL_TRANSAKSIDETAIL.nilai, "+
                                        "BL_TRANSAKSIDETAIL.Ringan, "+
                                        "MR_DOKTER.Idmr_dokter, "+
                                        "BL_TRANSAKSIDETAIL.idtrdet, "+
                                        "MR_DOKTER.Nama " +
                                 "HAVING BL_TRANSAKSI.Regbilling= '" + strNoBilling + "' " + strWhere + 
                                 "ORDER BY BL_TRANSAKSIDETAIL.idtrdet, BL_TRANSAKSIDETAIL.Idbl_komponen ASC";


            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            lvDaftarTindakan.Items.Clear();
            int intUrutan = 1;
            grpDetailTindakan.Clear();
            string strTgl = "";
            string strTglTemp = "";

            double dblTotalBiayaKotor = 0;
            double dblTotalKeringanan = 0;
            double dblTotalBiayaBersih = 0;

            if (isFirstDisplayCombo)
            {
                cmbFilterNamaDokter.SafeControlInvoke(ComboBox => cmbFilterNamaDokter.Items.Clear());
                cmbFilterNamaDokter.SafeControlInvoke(ComboBox => cmbFilterNamaDokter.Items.Add(""));
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstDetailTindakan item = new lstDetailTindakan();
                    item.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    item.strUraianTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    item.dtTglInput = Convert.ToDateTime(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    item.strKomponen = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    item.dblBiaya = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    item.dblKeringanan = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    item.strNamaDokter = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    item.strKodeDetailTindakan = modMain.pbstrgetCol(reader, 7, ref strErr, "");
                    item.strKodeDokter = modMain.pbstrgetCol(reader, 8, ref strErr, "");
                    grpDetailTindakan.Add(item);

                    strTgl = item.dtTglInput.ToString();

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(intUrutan.ToString()));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                    

                    #region CODE STATUS : NEED REVIEW LATER
                    //if (item.strKomponen.ToUpper() == "JASA SARANA")
                    //{
                        
                    //}
                    //else
                    //{
                    //    if (strKodeDokter.Trim().ToString() == "")
                    //    {

                    //        lvDaftarTindakan.SafeControlInvoke(
                    //            ListView => lvDaftarTindakan.Items.Add(""));
                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));
                    //    }
                    //    else
                    //    {
                    //        lvDaftarTindakan.SafeControlInvoke(
                    //       ListView => lvDaftarTindakan.Items.Add(intUrutan.ToString()));
                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                    //                    modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                    //                    modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                    //        lvDaftarTindakan.SafeControlInvoke(
                    //                ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                    //                    modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                    //        intUrutan++;
                    //    }
                    //}
                    #endregion

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 3, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 4, ref strErr, "")));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 5, ref strErr, "")));

                    double dblNominal = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    double dblNominalPengurangan = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    double dblNominalBersih = dblNominal - dblNominalPengurangan;

                    dblTotalBiayaKotor = dblTotalBiayaKotor + dblNominal;
                    dblTotalKeringanan = dblTotalKeringanan + dblNominalPengurangan;
                    dblTotalBiayaBersih = dblTotalBiayaBersih + dblNominalBersih;

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                    dblNominalBersih.ToString()));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 6, ref strErr, "")));

                    /*INVISIBLE idDetailTindakan*/
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 7, ref strErr, "")));



                    strTglTemp = strTgl;

                    int intKetemu = -1;

                    if (isFirstDisplayCombo)
                    {
                        if ((item.strKodeDokter.Trim().ToString() != "") && (item.strKodeDokter.Trim().ToString() != "-"))
                        {

                            cmbFilterNamaDokter.SafeControlInvoke(
                                    ComboBox => intKetemu = cmbFilterNamaDokter.FindString(item.strKodeDokter.Trim().ToString() + " -- " +
                                                                                           item.strNamaDokter.Trim().ToString()));

                            if (intKetemu == -1)
                                cmbFilterNamaDokter.SafeControlInvoke(
                                    ComboBox => cmbFilterNamaDokter.Items.Add(item.strKodeDokter + " -- " +
                                                                                           item.strNamaDokter.Trim().ToString()));
                        }
                    }

                    intUrutan++;

                }

                lvDaftarTindakan.SafeControlInvoke(
                           ListView => lvDaftarTindakan.Items.Add(""));

                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add("TOTAL"));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(dblTotalBiayaKotor.ToString()));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(dblTotalKeringanan.ToString()));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(dblTotalBiayaBersih.ToString()));
                lvDaftarTindakan.SafeControlInvoke(
                        ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(""));

                

            }

            reader.Close();
            conn.Close();
            modSQL.pvAutoResizeLV(lvDaftarTindakan, 9);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            cmbFilterNamaDokter.SafeControlInvoke(ComboBox => cmbFilterNamaDokter.Enabled = true);

        }

       
        
    }
}
