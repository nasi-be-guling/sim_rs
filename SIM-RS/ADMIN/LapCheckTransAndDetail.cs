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

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }
           

            strQuerySQL = "SELECT a.regbilling, a.idbl_tarip, a.jumlah,  "+
                            "(SELECT SUM(niltarip) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) "+
                          "FROM BL_TRANSAKSI AS a "+
                          "WHERE a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
                          "' AND  '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "' ";

            strQuerySQL = "SELECT a.regbilling, a.idbl_tarip, a.jumlah,  " +
                            "(SELECT SUM(niltarip) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) " +
                            "FROM BL_TRANSAKSI AS a " +
                            "INNER JOIN BL_TARIP AS C ON a.idbl_tarip = c.IdBl_tarip " +
                            "WHERE (a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
                                    "' AND  ''" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "') " +
                            "AND c.Idmr_jeniskelas = 'SATU'";


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
                    //lbDaftarMenu.Items.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                }
            }

            reader.Close();
            conn.Close();

        }

        private void LapCheckTransAndDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            this.pvCariData();
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
    }
}
