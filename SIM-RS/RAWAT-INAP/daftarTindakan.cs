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
    public partial class daftarTindakan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();


        string strQuerySQL = "";
        string strErr = "";

        private void pvTampilDataTindakan()
        {

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            string strKodeTarif = "";
            strQuerySQL = "SELECT "+
                                "BL_TARIP.idbl_tarip, "+        //0
                                "BL_TARIP.uraiantarip, "+       //1
                                "BL_TARIP.idmr_tsmf, "+         //2
                                "BL_TARIF.nilai, "+             //3
                                "BL_KOMPTARIP.idbl_komponen, "+ //4
                                "BL_KOMPTARIP.bykomponen "+     //5
                           "FROM BL_TARIP WITH (NOLOCK) "+
                           "INNER JOIN BL_KOMPTARIF "+
                                "ON BL_TARIF.IdBl_tarif = BL_KOMPTARIP.idbl_tarip "+
                           "WHERE BL_TARIF.idbl_tarif LIKE '%" + strKodeTarif + "%' "+
                                "AND BL_TARIF.nilai > 0 "+
                                "AND BL_TARIF.dipakai = 'Y';";

            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            lvDaftarTindakan.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lvDaftarTindakan.Items.Add(modMain.pbstrgetCol(reader,0,ref strErr,""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count -1 ].SubItems.Add(
                            modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            modMain.pbstrgetCol(reader, 3, ref strErr, ""));


                }
            }

            conn.Close();


        }

        public daftarTindakan()
        {
            InitializeComponent();

            this.pvTampilDataTindakan();
        }

        private void daftarTindakan_Load(object sender, EventArgs e)
        {

        }
    }
}
