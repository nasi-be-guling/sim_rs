using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SIM_RS.ADMIN;

namespace SIM_RS
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new RAWAT_JALAN_PAV.rekamMedis());             
=======
            Application.Run(new RAWAT_INAP.JasaPelayanan());
>>>>>>> 25a2cd9f69d4d6b452a300099c4fec092dda4569
        }
    }

}
