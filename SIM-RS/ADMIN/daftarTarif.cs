using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIM_RS.ADMIN
{
    public partial class daftarTarif : Form
    {
        public daftarTarif()
        {
            InitializeComponent();
        }


        /*OWNED FUNCTION*/

        private void pvEnableSatuanForm()
        {
            txtKode.Enabled = true;
            txtKelompok.Enabled = true;
            cmbKelas.Enabled = true;
            txtUraian.Enabled = true;
            txtSMF.Enabled = true;            
            chkDipakai.Enabled = true;

            txtNamaFileExcel.Enabled = false;
            btnLoadExcel.Enabled = false;


        }

        private void pvDisableSatuanForm()
        {
            txtKode.Enabled = false;
            txtKelompok.Enabled = false;
            cmbKelas.Enabled = false;
            txtUraian.Enabled = false;
            txtSMF.Enabled = false;
            chkDipakai.Enabled = false;

            txtNamaFileExcel.Enabled = true;
            btnLoadExcel.Enabled = true;
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void daftarTarif_Load(object sender, EventArgs e)
        {

        }
    }
}
