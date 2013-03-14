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
    public partial class LapCheckTransAndDetail : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /* PRIVATE VARIABLE */

        string strQuerySQL = "";
        string strErr = "";

        /* EOF PRIVATE VARIABLE */      
        
        public LapCheckTransAndDetail()
        {
            InitializeComponent();
        }


        private void pvCariData()
        {

            btnCari.Enabled = false;

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            MessageBox.Show(conn.ConnectionTimeout.ToString());

            //strQuerySQL = "SELECT a.regbilling, a.idbl_tarip, a.jumlah,  "+
            //                "(SELECT SUM(niltarip) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) "+
            //              "FROM BL_TRANSAKSI AS a "+
            //              "WHERE a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
            //              "' AND  '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "' ";

            strQuerySQL = "SELECT "+
                                "a.regbilling, "+
                                "a.idbl_tarip, "+
                                "a.jumlah,  "+
                                "(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi), "+
                                "a.idbl_transaksi, a.TglTransaksi "+
                            "FROM BL_TRANSAKSI AS a " +
                                "INNER JOIN BL_TARIP AS C ON a.idbl_tarip = c.IdBl_tarip " +
                            "WHERE (a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
                                    "' AND  '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "') " +
                            "AND c.Idmr_jeniskelas = 'SATU' AND a.Batal = '' AND "+
                            "(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) IS NULL";


            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }


            lvDaftarTindakan.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lvDaftarTindakan.Items.Add(modMain.pbstrgetCol(reader, 0, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 4, ref strErr, ""));

                    //lbDaftarMenu.Items.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                }
            }
            else
            {
                MessageBox.Show("Data tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            reader.Close();
            conn.Close();

            btnCari.Enabled = true;

        }

        private void LapCheckTransAndDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.cmbPilihanKelas.SelectedIndex = 0;
            //this.pvCariData();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LapCheckTransAndDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {  
                this.Close();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            this.pvCariData();
        }

        private void lvDaftarTindakan_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (lvDaftarTindakan.Items.Count > 0))
            {
                cmsPerbaikan.Show(this.lvDaftarTindakan, e.Location);
            }
        }

        private void rubahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvDaftarTindakan.Height = 157;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            lvDaftarTindakan.Height = 431;
        }
    }
}
