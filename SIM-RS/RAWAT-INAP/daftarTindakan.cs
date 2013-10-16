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
        List<ListViewItem> lviDaftarTindakanDB = new List<ListViewItem>();


        private void pvTampilDataTindakanNonDB()
        {

            //inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];

            halamanUtama fHalamanUtama = (halamanUtama)Application.OpenForms["halamanUtama"];

            fHalamanUtama.grpLstDaftarTarif.ForEach(
           delegate(halamanUtama.lstDaftarTarif itemTarif)
           {

               ListViewItem itemList = new ListViewItem(itemTarif.strKodeTarif);
               itemList.SubItems.Add(itemTarif.strUraianTarif);
               itemList.SubItems.Add(itemTarif.strSMF);
               itemList.SubItems.Add(itemTarif.dblBiaya.ToString());

               lviDaftarTindakan.Add(itemList);

           });

            this.bgWork.RunWorkerAsync();

        }

        private void pvTampilDataTindakanDB( string _strFilter, string _strValue )
        {
            string strPartWhere = "";

            if (_strFilter.Trim().ToString() == "Kode Tarif")
            {
                strPartWhere = " BL_TARIP.idbl_tarip LIKE '%" + _strValue + "%' ";
            }else if(_strFilter.Trim().ToString() == "Nama Tarif")
            {
                strPartWhere = " BL_TARIP.uraiantarip LIKE '%" + _strValue + "%' ";
            }else
            {
                /* Nama SMF */
                strPartWhere = " BL_TARIP.idmr_tsmf LIKE '%" + _strValue + "%' ";
            }

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            //string strKodeTarif = "";

            strQuerySQL = "SELECT "+
                                "BL_TARIP.idbl_tarip, "+        //0
                                "BL_TARIP.uraiantarip, "+       //1
                                "BL_TARIP.idmr_tsmf, "+         //2
                                "BL_TARIP.nilai "+             //3
                           "FROM BL_TARIP WITH (NOLOCK) "+
                           "WHERE  "+ strPartWhere +
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

            lviDaftarTindakanDB.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    ListViewItem itemLV = new ListViewItem(modMain.pbstrgetCol(reader, 0, ref strErr, ""));
                    itemLV.SubItems.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    itemLV.SubItems.Add(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    itemLV.SubItems.Add(modMain.pbstrgetCol(reader, 3, ref strErr, ""));

                    lviDaftarTindakanDB.Add(itemLV);

                }
            }

            conn.Close();


            this.bgWork2.RunWorkerAsync();
        }


        private void pvPencarian()
        {
            if (txtIsiFilter.Text.Trim().ToString() == "")
                this.pvTampilDataTindakanNonDB();
            else
                this.pvTampilDataTindakanDB(cmbPilihanFilter.Text,txtIsiFilter.Text);

        }

        public daftarTindakan()
        {
            InitializeComponent();

            //this.pvTampilDataTindakan();
        }

        private void daftarTindakan_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;

            cmbPilihanFilter.SelectedIndex = 1;

            this.pvTampilDataTindakanNonDB();

        }

        private void lvDaftarTindakan_DoubleClick(object sender, EventArgs e)
        {
            string strKodeTarif = lvDaftarTindakan.SelectedItems[0].Text + " -- " + lvDaftarTindakan.SelectedItems[0].SubItems[1].Text;
            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];
            //fInputTindakan.pvLoadDetailTarif(strKodeTarif);
            isUserSelected = true;
            this.Close();
        }

        private void daftarTindakan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isUserSelected)
            {
                inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];
                fInputTindakan.btnTampilDaftarTarif.Enabled = false;
                fInputTindakan.txtNamaDokter.Select();


            }
        }

        private void lvDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strKodeTarif = lvDaftarTindakan.SelectedItems[0].Text + " -- " + lvDaftarTindakan.SelectedItems[0].SubItems[1].Text;
            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];
            //fInputTindakan.pvLoadDetailTarif(strKodeTarif);
            isUserSelected = true;
            this.Close();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.BeginUpdate());
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.Clear());
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.AddRange(lviDaftarTindakan.ToArray()));
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.EndUpdate());


            lvDaftarTindakan.SafeControlInvoke(ListView => modSQL.pvAutoResizeLV(lvDaftarTindakan, 4));
        }

        private void daftarTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtIsiFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.pvPencarian();
            }
        }

        private void btnCariSesuaiFilter_Click(object sender, EventArgs e)
        {
            this.pvPencarian();
        }

        private void bgWork2_DoWork(object sender, DoWorkEventArgs e)
        {
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.BeginUpdate());
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.Clear());
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.AddRange(lviDaftarTindakanDB.ToArray()));
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.EndUpdate());

            lvDaftarTindakan.SafeControlInvoke(ListView => modSQL.pvAutoResizeLV(lvDaftarTindakan, 4));
        }
    }
}
