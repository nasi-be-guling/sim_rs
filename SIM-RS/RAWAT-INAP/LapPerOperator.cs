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
    public partial class LapTindPerOperator : Form
    {
        public LapTindPerOperator()
        {
            InitializeComponent();
        }

        private void LapPerOperator_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
