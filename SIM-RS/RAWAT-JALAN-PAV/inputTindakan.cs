using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIM_RS.RAWAT_JALAN_PAV
{
    public partial class inputTindakan : Form
    {
        public inputTindakan()
        {
            InitializeComponent();
        }

        private void lblNamaPasien_Click(object sender, EventArgs e)
        {

        }

        private void inputTindakan_Load(object sender, EventArgs e)
        {
            int intDeskHeight = Screen.PrimaryScreen.Bounds.Height;
            int intDeskWidth = Screen.PrimaryScreen.Bounds.Width;

            

            if (intDeskWidth < 1024 || intDeskHeight < 768)
            {
                MessageBox.Show(intDeskWidth.ToString() + " x " + intDeskHeight.ToString());
                this.Close();
                return;
            }

        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
