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


        bool isUserSelected = false;

        List<ListViewItem> lviDaftarTindakan = new List<ListViewItem>();

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
                                "BL_TARIP.nilai, "+             //3
                                "BL_KOMPTARIP.idbl_komponen, "+ //4
                                "BL_KOMPTARIP.bykomponen "+     //5
                           "FROM BL_TARIP WITH (NOLOCK) "+
                           "INNER JOIN BL_KOMPTARIP WITH (NOLOCK) "+
                                "ON BL_TARIP.IdBl_tarip = BL_KOMPTARIP.idbl_tarip "+
                           "WHERE BL_TARIP.idbl_tarip LIKE '%" + strKodeTarif + "%' "+
                                "AND BL_TARIP.nilai > 0 "+
                                "AND BL_TARIP.dipakai = 'Y'";

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
            modSQL.pvAutoResizeLV(lvDaftarTindakan, 4);
        }

        public daftarTindakan()
        {
            InitializeComponent();

            //this.pvTampilDataTindakan();
        }

        private void daftarTindakan_Load(object sender, EventArgs e)
        {
            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];

            

            fInputTindakan.grpLstDaftarTarif.ForEach(
            delegate(inputTindakan.lstDaftarTarif itemTarif)
            {

                ListViewItem itemList = new ListViewItem(itemTarif.strKodeTarif);
                itemList.SubItems.Add(itemTarif.strUraianTarif);
                itemList.SubItems.Add(itemTarif.strSMF);
                itemList.SubItems.Add(itemTarif.dblBiaya.ToString());

                lviDaftarTindakan.Add(itemList);

            });

            lvDaftarTindakan.BeginUpdate();
            lvDaftarTindakan.Items.Clear();
            lvDaftarTindakan.Items.AddRange(lviDaftarTindakan.ToArray());
            lvDaftarTindakan.EndUpdate();


            modSQL.pvAutoResizeLV(lvDaftarTindakan, 4);

        }

        private void lvDaftarTindakan_DoubleClick(object sender, EventArgs e)
        {
            string strKodeTarif = lvDaftarTindakan.SelectedItems[0].Text;

            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];

            fInputTindakan.pvLoadDetailTarif(strKodeTarif);

            isUserSelected = true;
            
            this.Close();

        }

        private void daftarTindakan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isUserSelected)
            {
                inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];
                fInputTindakan.btnTampilDaftarTindakan.Enabled = false;
                fInputTindakan.txtNamaDokter.Select();


            }
        }

        private void lvDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strKodeTarif = lvDaftarTindakan.SelectedItems[0].Text;

            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];

            fInputTindakan.pvLoadDetailTarif(strKodeTarif);

            isUserSelected = true;

            this.Close();
        }
    }
}
