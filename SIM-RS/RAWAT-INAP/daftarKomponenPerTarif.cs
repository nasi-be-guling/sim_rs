using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIM_RS.RAWAT_INAP
{
    public partial class daftarKomponenPerTarif : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();

        public daftarKomponenPerTarif()
        {
            InitializeComponent();

            

        }       

        private void daftarKomponenPerTarif_Load(object sender, EventArgs e)
        {
            inputTindakan fInputTindakan = (inputTindakan)Application.OpenForms["inputTindakan"];


            lvDaftarTindakan.Items.Clear();
            foreach (inputTindakan.lstDaftarKomponenTarif itemx in fInputTindakan.grpLstTempTindakanDetail)
            {
                lvDaftarTindakan.Items.Add(itemx.strKodeTarif);
                int intResult = fInputTindakan.grpLstDaftarTarif.FindIndex(m => m.strKodeTarif == itemx.strKodeTarif);
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                    fInputTindakan.grpLstDaftarTarif[intResult].strUraianTarif);
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemx.strId_Komponen);
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemx.dblByKomponen.ToString());
                lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemx.strKodeDokter + "--" + itemx.strNamaDokter);
            }

            lblKodeNamaTarif.Text = fInputTindakan.txtKodeTindakan.Text;

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 5);
        }

        private void daftarKomponenPerTarif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
    }
}
