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
    public partial class inputKeringanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();

        string strQuerySQL = "";
        string strErr = "";

        public inputKeringanan()
        {
            InitializeComponent();
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

                //strIdMR_TempatLayanan = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                //strIdMutasiPasien = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                //strIdMR_TRuangan = modMain.pbstrgetCol(reader, 4, ref strErr, "");

                //this.pvEnableInput();
                //dtpTglTindakan.SafeControlInvoke(DateTimePicker => dtpTglTindakan.Focus());
                btnKeluarIsiTindakan.SafeControlInvoke(Button => btnKeluarIsiTindakan.Text = "&BATAL");
            }
            else
            {

                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            reader.Close();

            /* LOAD DATA TINDAKAN YANG ADA.. */

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "PROSES MENAMPILKAN DATA TINDAKAN");

            this.strQuerySQL = "SELECT "+
                                    "a.idbl_tarip, "+
                                    "a.uraiantarip, "+
                                    "a.tglTransaksi, "+
                                    "b.idbl_komponen, "+
                                    "b.nilai, "+
                                    "b.ringan,  " +
                                    "c.Nama " +
                               "FROM BL_TRANSAKSI AS a "+
                               "LEFT JOIN BL_TRANSAKSIDETAIL AS b on a.idbl_transaksi = b.idbl_transaksi " +
                               "LEFT JOIN MR_DOKTER AS c on b.idmr_dokter = c.idmr_dokter "+
                               "WHERE RegBilling = '" + txtNoBilling.Text.Trim().ToString() +"'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
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

            lvDaftarTindakan.Items.Clear();

            int intUrutan = 1;

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(intUrutan.ToString()));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count-1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                    
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count-1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                    
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 2, ref strErr, "")));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 3, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 4, ref strErr, "")));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 5, ref strErr, "")));

                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                                modMain.pbstrgetCol(reader, 6, ref strErr, "")));

                    

                    intUrutan++;
                }
            }

            reader.Close();

            conn.Close();

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 8);

            //timerBlink.Stop();
            //timerBlink.Enabled = false;
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
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

        
    }
}
