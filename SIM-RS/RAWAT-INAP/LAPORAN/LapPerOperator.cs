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
    public partial class LapPerOperator : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();


        string strQuerySQL = "";
        string strErr = "";

        string strIdUser = "";


        private void pvLoadData()
        {

           

        }

        public LapPerOperator()
        {
            InitializeComponent();
        }

        private void LapPerOperator_Load(object sender, EventArgs e)
        {

            //this.reportViewer.RefreshReport();
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            //this.pvLoadData();

            timerBlink.Enabled = true;
            timerBlink.Start();

            this.bgWork.RunWorkerAsync();
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            if (lblInfoPencarian.ForeColor == Color.Black)
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.ForeColor = Color.Red);
            else
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.ForeColor = Color.Black);
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = false);

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;


            strIdUser = halamanUtama.strNamaUser;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                timerBlink.Enabled = false;
                timerBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = true);

                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            string strTglAwal = "";
            string strTglAkhir = "";

            dtpPeriodeTgl.SafeControlInvoke(DateTimePicker => strTglAwal = dtpPeriodeTgl.Value.ToString("MM/dd/yyyy 00:00:00"));
            dtpPeriodeTgl.SafeControlInvoke(DateTimePicker => strTglAkhir = dtpPeriodeTgl.Value.ToString("MM/dd/yyyy 23:59:59"));

            strQuerySQL = "SELECT " +
                            "BL_TRANSAKSI.regbilling, " +                //0
                            "BL_TRANSAKSI.tgltransaksi, " +             //1
                            "BL_TRANSAKSI.nobukti, " +                   //2
                            "BL_TRANSAKSI.idbl_tarip, " +                //3
                            "BL_TRANSAKSI.uraiantarip, " +              //4
                            "BL_TRANSAKSI.tglkelrwt, " +                 //5
                            "BL_TRANSAKSI.harirwt, " +                   //6
                            "BL_TRANSAKSI.jumlah, " +                    //7
                            "BL_TRANSAKSI.subsidi, " +                  //8
                            "MR_PASIEN.nama, " +                         //9
                            "MR_TRUANGAN.ruangan, " +                    //10
                            "MR_MUTASIPASIEN.idmr_mutasipasien, " +      //11
                            "(SELECT TOP 1 idmr_dokter " +
                              "FROM BL_TRANSAKSIDETAIL " +
                              "WHERE BL_TRANSAKSIDETAIL.idbl_transaksi = BL_TRANSAKSI.idbl_transaksi " +
                                "AND BL_TRANSAKSIDETAIL.idbl_komponen = 'JASA PELAYANAN') " +
                           "FROM BL_TRANSAKSI With (Nolock) " +
                           "INNER JOIN MR_MUTASIPASIEN on " +
                            "BL_TRANSAKSI.idmr_mutasipasien = MR_MUTASIPASIEN.idmr_mutasipasien " +
                           "INNER JOIN MR_PASIEN on MR_MUTASIPASIEN.idmr_pasien = MR_PASIEN.idmr_pasien " +
                           "INNER JOIN MR_TRUANGAN on BL_TRANSAKSI.idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                           "WHERE BL_TRANSAKSI.sistem = 'IRNA' and BL_TRANSAKSI.batal = '' " +
                            "AND BL_TRANSAKSI.petugas = '" + strIdUser + "' " +
                            "AND (BL_TRANSAKSI.tgltransaksi BETWEEN '" + strTglAwal +
                                    "' AND  '" + strTglAkhir + "') " +
                            "ORDER BY BL_TRANSAKSI.idbl_transaksi";

            //"(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) IS NULL OR " +
            //                "(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) <> a.jumlah";


            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {

                timerBlink.Enabled = false;
                timerBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = true);

                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }


            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.Clear());

            int intNoUrut = 1;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(intNoUrut.ToString()));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 9, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 10, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 4, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 7, ref strErr, "")));
                    lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 12, ref strErr, "")));
                    intNoUrut++;
                }
            }

            reader.Close();
            conn.Close();

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 8);

            timerBlink.Enabled = false;
            timerBlink.Stop();
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = true);

        }
      
    }
}
